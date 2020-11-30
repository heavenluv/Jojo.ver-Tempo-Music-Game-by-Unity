using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteResponse : MonoBehaviour
{
    public float speed = 10.0f;
    private Text judge;
    private Text combo;
    private CountNumber count_object;
    private float starttime;
    private AudioSource beat_sound;
    private NoteLaunch note_launch;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, -speed, 0);
        judge = GameObject.Find("JudgeDisplay").GetComponent<Text>();
        combo = GameObject.Find("Combo").GetComponent<Text>();
        count_object = GameObject.Find("Counter").GetComponent<CountNumber>();
        beat_sound = GameObject.Find("Checkline").GetComponent<AudioSource>();
        note_launch= GameObject.Find("NoteLauncher").GetComponent<NoteLaunch>();
    }

    // Update is called once per frame

    void Update()
    {
        if (!note_launch.JudgebyTime)
        {
            if (!note_launch.AutoPlay)
            {
                float currenty = gameObject.transform.position.y;
                float currentx = gameObject.transform.position.x;
                if ((currenty < 1f && currenty > -2.9f) || (currenty < -3.1f && currenty > -4f))
                {
                    if (HitNote(currentx) && IsBeating(currenty, currentx))
                    {
                        beat_sound.Play(0);
                        count_object.ComboCount++;
                        count_object.GoodCount++;
                        judge.text = "Good";
                        combo.text = "Combo:" + count_object.ComboCount;
                        Destroy(gameObject);
                    }
                }
                if (currenty <= -2.9f && currenty >= -3.1f)
                {
                    if (HitNote(currentx) && IsBeating(currenty, currentx))
                    {
                        beat_sound.Play(0);
                        count_object.ComboCount++;
                        count_object.PerfectCount++;
                        judge.text = "Perfect";
                        combo.text = "Combo:" + count_object.ComboCount;
                        Destroy(gameObject);
                    }
                }
                if (currenty >= 1f)
                {
                    if (HitNote(currentx) && IsBeating(currenty, currentx))
                    {
                        count_object.ComboCount = 0;
                        count_object.MissCount++;
                        judge.text = "Miss";
                        combo.text = "Combo:" + count_object.ComboCount;
                        Destroy(gameObject);

                    }
                }
                else if (currenty <= -4f)
                {
                    count_object.MissCount++;
                    count_object.ComboCount = 0;
                    judge.text = "Miss";
                    combo.text = "Combo:" + count_object.ComboCount;
                    Destroy(gameObject);
                }
            }
            else
            {
                float currenty = gameObject.transform.position.y;
                if (Mathf.Abs(currenty + 3f) <= 0.1)
                {
                    beat_sound.Play(0);
                    Destroy(gameObject);
                }
            }
        }

        bool HitNote(float current_x)
        {
            if (current_x == -3f)
            {
                if (Input.GetKeyDown(KeyCode.D))
                    return true;
                else return false;
            }
            if (current_x == -1f)
            {
                if (Input.GetKeyDown(KeyCode.F))
                    return true;
                else return false;
            }
            if (current_x == 1f)
            {
                if (Input.GetKeyDown(KeyCode.J))
                    return true;
                else return false;
            }
            if (current_x == 3f)
            {
                if (Input.GetKeyDown(KeyCode.K))
                    return true;
                else return false;
            }
            else return false;
        }

        bool IsBeating(float current_y, float current_x)
        {
            GameObject[] other_note;
            other_note = GameObject.FindGameObjectsWithTag("Note");
            foreach (GameObject unit_other_note in other_note)
            {
                if (unit_other_note.transform.position.y < current_y && unit_other_note.transform.position.x == current_x)
                    return false;
            }
            return true;
        }
    }     
}
