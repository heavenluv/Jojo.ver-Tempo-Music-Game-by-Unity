using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private NoteLaunch note_launch;
    private GameObject button;
    private Text combo;
    private GameObject checkline;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        checkline = GameObject.Find("Checkline");
        checkline.transform.localScale = new Vector3(8f, 0.1f, 1f);
        note_launch = GameObject.Find("NoteLauncher").GetComponent<NoteLaunch>();
        note_launch.GameStart = true;
        button = GameObject.Find("StartButton");
        button.transform.localScale =new Vector3(0f, 1f, 1f);
        combo = GameObject.Find("Combo").GetComponent<Text>();
        combo.text = "Combo:0";
    }
}
