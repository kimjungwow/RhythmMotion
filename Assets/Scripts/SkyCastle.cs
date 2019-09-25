using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyCastle : MonoBehaviour
{
    //public UIText scoreText;
    public int frame = 0;
    public string timerReset = "y";
    public Transform noteObj;

    private int NoteMark = 0;
    private int note2 = 0;
    private int score;
    private float xPos;
    //music 과 beat는 밑에 spawnNote함수의 변수명으로 쓰기때문에 숫자를 달아주거나 다른이름으로 쓰는게 나음.
    private List<float> music1 = new List<float>() { 3, 0, 2, 1, 3, 0, 2, 1 };
    private List<float> beat1 = new List<float>() {1.2f, 1.2f, 1.2f, 1.2f, 1.2f, 1.2f, 1.2f, 1.2f };


    public System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
       
        //MusicSource.Play();
        if (frame > 340 && frame < 10600)
        {
            for (int i = 0; i < 300; i++)
            {
                //music1.Add(3);
                //float rInt = (float)random.Next(13, 20);
                //float beats = rInt * (float)0.05;
                if (music1[music1.Count - 1] == 1 || music1[music1.Count - 1] == 2)
                {
                    if (random.Next(0, 2) == 0)
                    {
                        note2 = 0;
                    }
                    else
                    {
                        note2 = 3;
                    }
                }
                else
                {
                    note2 = random.Next(4);
                }
                music1.Add(note2);
                beat1.Add(1.2f);
            }
            if (timerReset == "y")
            {
                StartCoroutine(spawnNote(music1, beat1));
                timerReset = "n";
            }
        }
        frame++;
    }
    
    //, List<float> time
    IEnumerator spawnNote(List<float> music, List<float> beat)
    {
        yield return new WaitForSeconds(beat[NoteMark]);
        //yield return new WaitForSeconds(.41f);  //절대 두께 이하로 내려가면 안됨 (ex: 0.4)

        if (NoteMark < 300)
        {
            if (music[NoteMark] == 0)
            {
                xPos = -9f;
            }
            if (music[NoteMark] == 1)
            {
                xPos = -3f;
            }
            if (music[NoteMark] == 2)
            {
                xPos = 3f;
            }
            if (music[NoteMark] == 3)
            {
                xPos = 9f;
            }

            NoteMark += 1;
            timerReset = "y";
            Instantiate(noteObj, new Vector3(xPos, 7.1f, 1f), noteObj.rotation);
        }
    }
}
