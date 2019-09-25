//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class loadload : MonoBehaviour
//{
//    public void LoadByIndex(int sceneIndex)
//    {

//        SceneManager.LoadScene(sceneIndex);



//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadload : MonoBehaviour
{

    private bool maincamAvailable;
    public static WebCamTexture mainbackCam;
    private Texture maindefaultBackground;
    public RawImage mainmenucam;




    private void Start()
    {


        maindefaultBackground = mainmenucam.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected;");
            maincamAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            {
                mainbackCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                print(Screen.width + " " + Screen.height);
            }

        }
        if (mainbackCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }



        mainbackCam.Play();
        //print("WIDTH : " + mainbackCam.width + " HEIGHT :  " + mainbackCam.height);
        mainmenucam.texture = mainbackCam;



    }


    public void LoadByIndex(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);
        mainbackCam.Stop();


    }
}
