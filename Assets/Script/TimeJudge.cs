using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeJudge : MonoBehaviour
{
    private NoteLaunch notelauncher;
    private float[] timing_point;
    private float music_start;
    private float real_time;
    private int beat_point = 0;
    private Text judge;
    private Text combo;
    private CountNumber count_object;
    private AudioSource beat_sound;

    // Start is called before the first frame update
    void Start()
    {
        notelauncher = GameObject.Find("NoteLauncher").GetComponent<NoteLaunch>();
        timing_point = notelauncher.timing;
        judge = GameObject.Find("JudgeDisplay").GetComponent<Text>();
        combo = GameObject.Find("Combo").GetComponent<Text>();
        count_object = GameObject.Find("Counter").GetComponent<CountNumber>();
        beat_sound = GameObject.Find("Checkline").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (notelauncher.JudgebyTime)
        {
            music_start = notelauncher.music_start_time;
            if (music_start != 0f)
            {
                real_time = Time.time - music_start;
                if (notelauncher.AutoPlay && Mathf.Abs(real_time - timing_point[beat_point]) <= 0.01f)
                {
                    GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
                    foreach (GameObject note in notes)
                    {
                        string tag = note.GetComponentInChildren<Text>().text;
                        int mark = int.Parse(tag);
                        if (mark == beat_point)
                        {
                            beat_sound.Play(0);
                            Destroy(note);
                            beat_point++;
                            break;
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.D) && Mathf.Abs(real_time - timing_point[beat_point]) <= 0.5f)
                {
                    GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
                    foreach (GameObject note in notes)
                    {
                        if (note.transform.position.x == -3f)
                        {
                            string tag = note.GetComponentInChildren<Text>().text;
                            int mark = int.Parse(tag);
                            if (mark == beat_point)
                            {
                                beat_sound.Play(0);
                                if (real_time - timing_point[beat_point] <= 0.1f)
                                {
                                    count_object.ComboCount++;
                                    count_object.PerfectCount++;
                                    judge.text = "Perfect";
                                    combo.text = "Combo:" + count_object.ComboCount;
                                }
                                else
                                {
                                    count_object.ComboCount++;
                                    count_object.GoodCount++;
                                    judge.text = "Good";
                                    combo.text = "Combo:" + count_object.ComboCount;
                                }
                                Destroy(note);
                                beat_point++;
                                break;
                            }
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.F) && Mathf.Abs(real_time - timing_point[beat_point]) <= 0.5f)
                {
                    GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
                    foreach (GameObject note in notes)
                    {
                        if (note.transform.position.x == -1f)
                        {
                            string tag = note.GetComponentInChildren<Text>().text;
                            int mark = int.Parse(tag);
                            if (mark == beat_point)
                            {
                                beat_sound.Play(0);
                                if (real_time - timing_point[beat_point] <= 0.1f)
                                {
                                    count_object.ComboCount++;
                                    count_object.PerfectCount++;
                                    judge.text = "Perfect";
                                    combo.text = "Combo:" + count_object.ComboCount;
                                }
                                else
                                {
                                    count_object.ComboCount++;
                                    count_object.GoodCount++;
                                    judge.text = "Good";
                                    combo.text = "Combo:" + count_object.ComboCount;
                                }
                                Destroy(note);
                                beat_point++;
                                break;
                            }
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.J) && Mathf.Abs(real_time - timing_point[beat_point]) <= 0.5f)
                {
                    GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
                    foreach (GameObject note in notes)
                    {
                        if (note.transform.position.x == 1f)
                        {
                            string tag = note.GetComponentInChildren<Text>().text;
                            int mark = int.Parse(tag);
                            if (mark == beat_point)
                            {
                                beat_sound.Play(0);
                                if (real_time - timing_point[beat_point] <= 0.1f)
                                {
                                    count_object.ComboCount++;
                                    count_object.PerfectCount++;
                                    judge.text = "Perfect";
                                    combo.text = "Combo:" + count_object.ComboCount;
                                }
                                else
                                {
                                    count_object.ComboCount++;
                                    count_object.GoodCount++;
                                    judge.text = "Good";
                                    combo.text = "Combo:" + count_object.ComboCount;
                                }
                                Destroy(note);
                                beat_point++;
                                break;
                            }
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.K) && Mathf.Abs(real_time - timing_point[beat_point]) <= 0.5f)
                {
                    GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
                    foreach (GameObject note in notes)
                    {
                        if (note.transform.position.x == 3f)
                        {
                            string tag = note.GetComponentInChildren<Text>().text;
                            int mark = int.Parse(tag);
                            if (mark == beat_point)
                            {
                                beat_sound.Play(0);
                                if (real_time - timing_point[beat_point] <= 0.1f)
                                {
                                    count_object.ComboCount++;
                                    count_object.PerfectCount++;
                                    judge.text = "Perfect";
                                    combo.text = "Combo:" + count_object.ComboCount;
                                }
                                else
                                {
                                    count_object.ComboCount++;
                                    count_object.GoodCount++;
                                    judge.text = "Good";
                                    combo.text = "Combo:" + count_object.ComboCount;
                                }
                                Destroy(note);
                                beat_point++;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (Mathf.Abs(real_time - timing_point[beat_point]) >= 0.3f)
                    {
                        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
                        foreach (GameObject note in notes)
                        {
                            string tag = note.GetComponentInChildren<Text>().text;
                            int mark = int.Parse(tag);
                            if (mark == beat_point&&note.transform.position.y<=-3f)
                            {
                                count_object.MissCount++;
                                count_object.ComboCount = 0;
                                judge.text = "Miss";
                                combo.text = "Combo:" + count_object.ComboCount;
                                Destroy(note);
                                beat_point++;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
