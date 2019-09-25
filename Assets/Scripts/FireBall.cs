using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //public UIText scoreText;
    public int frame = 0;
    public string timerReset = "y";
    public Transform noteObj;
    public Transform noteObj2;

    private int NoteMark = 0;
    private int note1 = 0;
    private int note2 = 0;
    private int score;
    private float xPos;
    //music 과 beat는 밑에 spawnNote함수의 변수명으로 쓰기때문에 숫자를 달아주거나 다른이름으로 쓰는게 나음.
    private List<float> music1 = new List<float>() { 3, 0, 2, 1, 3, 0, 2, 1, 0, 0, 3, 3, 1, 1, 2, 2, 1, 3, 0, 2, 1, 3, 0, 3};
    private List<float> beat1 = new List<float>() { 0.93f, 0.93f, 0.93f, 0.93f, 0.91f, 0.91f, 0.91f, 0.91f, 0.89f, 0.89f, 0.89f, 0.89f, 0.89f, 0.89f, 0.89f, 0.89f, 0.87f, 0.87f, 0.87f, 0.87f, 0.9f, 0.9f, 0.9f, 0.9f};

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
        if (frame > 340 && frame < 3540)
        {
            for (int i = 0; i < 62; i++)
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
                beat1.Add(0.45f);
            }

            for (int i = 0; i < 65; i++)
            {
                if (music1[music1.Count - 1] == 1 || music1[music1.Count - 1] == 2)
                {
                    if (random.Next(0, 2) == 0)
                    {
                        note1 = 0;
                    }
                    else
                    {
                        note1 = 3;
                    }
                }
                else
                {
                    note1 = random.Next(4);
                }
                music1.Add(note1);
                beat1.Add(0.9f);
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

        if (NoteMark < 24)
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
        else if (NoteMark >= 24 && NoteMark < 89)
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
            Instantiate(noteObj2, new Vector3(xPos, 7.1f, 1f), noteObj2.rotation);
        }

    }

    /*public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }


    void UpdateScore()
    {
        //scoreText.text = "Score: " + score;
    }
    */
}
