using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CountNumber : MonoBehaviour
{
    public int PerfectCount = 0;
    public int GoodCount = 0;
    public int ComboCount = 0;
    public int MissCount = 0;
    public GameObject note_launcher;
    private Text result;
    private Text perfect;
    private Text good;
    private Text miss;
    private GameObject back_button;
    private Text combo_off;
    private Text judge_off;
    private GameObject checkline;
    private new AudioSource audio;
    private VideoPlayer video;

    // Start is called before the first frame update
    void Start()
    {
        checkline = GameObject.Find("Checkline");
        note_launcher = GameObject.Find("NoteLauncher");
        result = GameObject.Find("TitleofResult").GetComponent<Text>();
        perfect= GameObject.Find("PerfectNumber").GetComponent<Text>();
        good= GameObject.Find("GoodNumber").GetComponent<Text>();
        miss= GameObject.Find("MissNumber").GetComponent<Text>();
        back_button = GameObject.Find("BacktoStartButton");
        combo_off= GameObject.Find("Combo").GetComponent<Text>();
        judge_off= GameObject.Find("JudgeDisplay").GetComponent<Text>();
        audio = GameObject.Find("Background").GetComponent<AudioSource>();
        video = GameObject.Find("Background").GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (note_launcher.GetComponent<NoteLaunch>().GameOver)
        {
            audio.Stop();
            video.Stop();
            combo_off.text = " ";
            judge_off.text = " ";
            result.text = "Result";
            perfect.text = "Perfect:" + PerfectCount;
            good.text = "Good:" + GoodCount;
            miss.text = "Miss:" + MissCount;
            back_button.transform.localScale = new Vector3(1, 1, 1);
            checkline.transform.localScale = new Vector3(0, 1, 1);
        }
    }

    public void OnClickBack()
    {
        note_launcher.GetComponent<NoteLaunch>().GameOver = false;
        result.text = " ";
        perfect.text = " ";
        good.text = " ";
        miss.text = " ";
        back_button.transform.localScale = new Vector3(0, 1, 1);
        GameObject start_button=GameObject.Find("StartButton");
        start_button.transform.localScale = new Vector3(1, 1, 1);
    }
}
