using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadmainmenu : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        PhoneCamera.backCam.Stop();
        
        SceneManager.LoadScene(sceneIndex);
        


    }
}
