using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NoteLaunch : MonoBehaviour
{
    public GameObject Note;
    private TextAsset song_info;
    public float[] timing=new float[800];
    public float fall_delta_time = 0f;
    public bool GameStart = false;
    private bool First_start_time = true;
    private bool First_over_time = true;
    public float music_start_time=0f;
    private float beat_over_time;
    private int beat_count;
    private GetKeyType get_key_type;
    public float wait_for_quit_time = 2f;
    public bool GameOver=false;
    public bool Trivial_Mod = true;
    public bool AutoPlay = false;
    public bool JudgebyTime = false;



    // Start is called before the first frame update
    void Start()
    {
        Readinfo();
        get_key_type = GameObject.Find("KeyType").GetComponent<GetKeyType>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart)
        {
            if (First_start_time)
            {
                beat_count = 0;
                AudioSource mainmusic = GameObject.Find("Background").GetComponent<AudioSource>();
                VideoPlayer videoPlayer = GameObject.Find("Background").GetComponent<VideoPlayer>();
                mainmusic.Play(0);
                mainmusic.volume = 0.1f;
                videoPlayer.Play();
                music_start_time = Time.time;
                First_start_time = false;
            }
            if(timing[beat_count] != 0f)
            {
                if (Mathf.Abs(Time.time - music_start_time + fall_delta_time - timing[beat_count]) <= 0.05f)
                {
                    if (Trivial_Mod)
                    {
                        Vector3 note_position = new Vector3(GetRandomNote_x(), 2.6f, 0f);
                        GameObject new_note=Instantiate(Note, note_position, Quaternion.identity);
                        new_note.GetComponentInChildren<Text>().text = ""+beat_count;
                        beat_count++;
                    }
                    else
                    {
                        int seed = UnityEngine.Random.Range(1, 15);
                        get_key_type.Generator(seed);
                        beat_count++;
                    }
                }
            }
            else
            {
                if (First_over_time)
                {
                    beat_over_time = Time.time;
                    First_over_time = false;
                }
                if ((Time.time-beat_over_time) >= wait_for_quit_time)
                {
                    GameStart = false;
                    GameOver = true;
                    First_over_time = First_start_time = true;
                }
            }
        }
    }
    
    void Readinfo()
    {
        int count = 0;
        string hit_point = song_info.text;
        string[] hit_point_Array = hit_point.Split('\n');
        foreach (string unit_hit in hit_point_Array)
        {
            string[] real_hit_point = unit_hit.Split(',');
            float raw_timing= float.Parse(real_hit_point[2]);
            timing[count] = raw_timing / 1000f;
            count++;
        }
        timing[count] = 0f;
    }

    float GetRandomNote_x()
    {
        float position_x = UnityEngine.Random.Range(-4f, 4f);
        if (position_x >= -4f && position_x < -2f)
            return -3f;
        if (position_x >= -2f && position_x < 0f)
            return -1f;
        if (position_x >=0f && position_x < 2f)
            return 1f;
        if (position_x >= 2f && position_x <= 4f)
            return 3f;
        else return 0f;
    }
}
