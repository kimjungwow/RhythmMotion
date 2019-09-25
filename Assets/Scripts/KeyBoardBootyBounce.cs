using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardBootyBounce : MonoBehaviour
{
    //public UIText scoreText;
    public int frame = 0;
    public string timerReset = "y";
    public Transform noteObj;
    public Transform noteObj2;
    public Transform noteObj3;

    private int NoteMark = 0;
    private int note1 = 0;
    private float xPos;
    //music 과 beat는 밑에 spawnNote함수의 변수명으로 쓰기때문에 숫자를 달아주거나 다른이름으로 쓰는게 나음.
    private List<float> music1 = new List<float>() { 1, 1, 2, 2, 1, 3, 0, 2, 1, 3, 0, 2, 0, 3, 3, 1, 0, 2, 3, 1,};
    private List<float> beat1 = new List<float>() { 0.23f, 0.23f, 0.23f, 0.23f, 0.23f, 0.23f, 0.23f, 0.23f, 0.23f, 0.23f};

    public System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (frame < 2500)
        {
            for (int i = 0; i < 10; i++)
            {
                note1 = random.Next(4);
                music1.Add(note1);
                beat1.Add(0.3f);
            }
            music1.Add(3);
            beat1.Add(0.21f);
            for (int i = 0; i < 124; i++)
            {
                note1 = random.Next(4);
                music1.Add(note1);
                beat1.Add(0.225f);
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

        if (NoteMark < 68)
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
        else if (NoteMark >= 68 && NoteMark < 78)
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

        else
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
            Instantiate(noteObj3, new Vector3(xPos, 7.1f, 1f), noteObj3.rotation);
        }
    }

}
