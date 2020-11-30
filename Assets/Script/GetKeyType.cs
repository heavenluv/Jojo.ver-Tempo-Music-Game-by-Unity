using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyType : MonoBehaviour
{
    public GameObject Note;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generator(int seed)
    {
        Vector3 note_position1 = new Vector3(-3f, 2.6f, 0f);
        Vector3 note_position2 = new Vector3(-1f, 2.6f, 0f);
        Vector3 note_position3 = new Vector3(1f, 2.6f, 0f);
        Vector3 note_position4 = new Vector3(3f, 2.6f, 0f);
        switch (seed)
        {
            case 1:
                {
                    Instantiate(Note, note_position1, Quaternion.identity);
                    break;
                }
            case 2:
                {
                    Instantiate(Note, note_position2, Quaternion.identity);
                    break;
                }
            case 3:
                {
                    Instantiate(Note, note_position3, Quaternion.identity);
                    break;
                }
            case 4:
                {
                    Instantiate(Note, note_position4, Quaternion.identity);
                    break;
                }
            case 5:
                {
                    Instantiate(Note, note_position1, Quaternion.identity);
                    Instantiate(Note, note_position2, Quaternion.identity);
                    break;
                }
            case 6:
                {
                    Instantiate(Note, note_position1, Quaternion.identity);
                    Instantiate(Note, note_position3, Quaternion.identity);
                    break;
                }
            case 7:
                {
                    Instantiate(Note, note_position1, Quaternion.identity);
                    Instantiate(Note, note_position4, Quaternion.identity);
                    break;
                }
            case 8:
                {
                    Instantiate(Note, note_position2, Quaternion.identity);
                    Instantiate(Note, note_position3, Quaternion.identity);
                    break;
                }
            case 9:
                {
                    Instantiate(Note, note_position2, Quaternion.identity);
                    Instantiate(Note, note_position4, Quaternion.identity);
                    break;
                }
            case 10:
                {
                    Instantiate(Note, note_position3, Quaternion.identity);
                    Instantiate(Note, note_position4, Quaternion.identity);
                    break;
                }
            case 11:
                {
                    Instantiate(Note, note_position1, Quaternion.identity);
                    Instantiate(Note, note_position2, Quaternion.identity);
                    Instantiate(Note, note_position3, Quaternion.identity);
                    break;
                }
            case 12:
                {
                    Instantiate(Note, note_position1, Quaternion.identity);
                    Instantiate(Note, note_position3, Quaternion.identity);
                    Instantiate(Note, note_position4, Quaternion.identity);
                    break;
                }
            case 13:
                {
                    Instantiate(Note, note_position2, Quaternion.identity);
                    Instantiate(Note, note_position3, Quaternion.identity);
                    Instantiate(Note, note_position4, Quaternion.identity);
                    break;
                }
            case 14:
                {
                    Instantiate(Note, note_position1, Quaternion.identity);
                    Instantiate(Note, note_position2, Quaternion.identity);
                    Instantiate(Note, note_position4, Quaternion.identity);
                    break;
                }
            case 15:
                {
                    Instantiate(Note, note_position1, Quaternion.identity);
                    Instantiate(Note, note_position2, Quaternion.identity);
                    Instantiate(Note, note_position3, Quaternion.identity);
                    Instantiate(Note, note_position4, Quaternion.identity);
                    break;
                }
        }
    }
}
