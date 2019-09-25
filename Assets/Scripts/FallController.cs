using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour
{
    public int NoteMark = 0;

    public Transform noteObj;

    public string timerReset = "y";

    public float xPos;

    public List<float> music1 = new List<float>() { };
    public List<float> beat1 = new List<float>() { };
   

    public System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 100; i++)
        {
            //music1.Add(3);
            music1.Add(random.Next(4));
            float rInt = (float)random.Next(13, 20);
            //float beats = rInt * (float)0.08;
            float beats = rInt * (float)0.02;
            beat1.Add(beats);
        }

        if (timerReset == "y")
        {
            StartCoroutine(spawnNote(music1, beat1));
            timerReset = "n";
        }
    }

    //, List<float> time
    IEnumerator spawnNote(List<float> list, List<float> time)
    {
        yield return new WaitForSeconds(time[NoteMark]);
        //yield return new WaitForSeconds(.41f);  //절대 두께 이하로 내려가면 안됨 (ex: 0.4)

        if (list[NoteMark] == 0)
        {
            xPos = -9f;
        }
        if (list[NoteMark] == 1)
        {
            xPos = -3f;
        }
        if (list[NoteMark] == 2)
        {
            xPos = 3f;
        }
        if (list[NoteMark] == 3)
        {
            xPos = 9f;
        }

        NoteMark += 1;
        timerReset = "y";
        Instantiate(noteObj, new Vector3(xPos, 7.1f, 1f), noteObj.rotation);
    }
}
