using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        if (sceneIndex == 0)
        {
            PhoneCamera.backCam.Stop();
            SceneManager.LoadScene(sceneIndex);
        }
        else if (sceneIndex == 99)
        {
            SceneManager.LoadScene(0);
        }
        else
        {

            SceneManager.LoadScene(sceneIndex);
        }
    }
}
