using UnityEngine;
using UnityEngine.UI;

//3D


public class PhoneCamera : MonoBehaviour
{

    float cut = 10f;

    private bool camAvailable;
    public static WebCamTexture backCam;

    private Texture defaultBackground;
    private Color color;

    public RawImage background;
    public Image rf, rh, lf, lh, ready, go;
    public AspectRatioFitter fit;
    public Transform c1, c2;
    private GameObject click1, click2, click3, click4, success1, success1_2, success1_3, success2, success2_2, success2_3, success3, success3_2, success3_3,success4, success4_2, success4_3;
    int rf_index, lf_index, rh_index, lh_index;
    int allindex = 25; // Interval to visualize hands & feet
    int detect_width, detect_height, detect_index, detect_borderindex;
    int lf_x, lf_y, lh_x, lh_y, rf_x, rf_y, rh_x, rh_y;
    Color[] rh_prevarr, rh_newarr, rf_prevarr, rf_newarr, lh_prevarr, lh_newarr, lf_prevarr, lf_newarr, border_arr;

    int cutindex = 0;


    private void Start()
    {
        Debug.Log("Start!!");
        


        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected;");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                print(Screen.width + " " + Screen.height);
            }

        }
        if (backCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }



        backCam.Play();
        print("WIDTH : " + backCam.width + " HEIGHT :  " + backCam.height);
        background.texture = backCam;

        camAvailable = true;
        Vars();

        ready.enabled = true;
        go.enabled = false;


    }

    private void Update()
    {
        
        if (rf_index < allindex) rf_index++;
        else rf.enabled = true;

        if (lf_index < allindex) lf_index++;
        else lf.enabled = true;

        if (rh_index < allindex) rh_index++;
        else rh.enabled = true;

        if (lh_index < allindex) lh_index++;
        else lh.enabled = true;


        if (cutindex == 270)
        {
            ready.enabled = false;
            go.enabled = true;
        }
        if (cutindex == 350)
        {
            go.enabled = false;
            cut = 0.2f;
        }
        cutindex++;
        //if (DetectPixels(rf_x, rf_y, detect_width, detect_height, 1) > cut)
        if (Detect_Borders(rf_x, rf_y, 3) > cut)
        {
            if (rf.enabled)
            {
                rf.enabled = false;
                rf_index = 0;

                click3.transform.position = new Vector3(3, -14.22f, -3.39f);
                success3.transform.position = new Vector3(3, -14.22f, -3.39f);
                success3_2.transform.position = new Vector3(3, -14.75f, -3.49f);
                success3_3.transform.Translate(0, 0, 28f * Time.deltaTime);

            }
            else
            {
                click3.transform.position = new Vector3(3, -16.31f, -3.82f);
                success3.transform.position = new Vector3(3, -16.31f, -3.82f);
                success3_2.transform.position = new Vector3(3, -16.31f, -3.82f);
                success3_3.transform.position = new Vector3(3, -15.43f, -3.66f);
            }


        }
        else
        {
            click3.transform.position = new Vector3(3, -16.31f, -3.82f);
            success3.transform.position = new Vector3(3, -16.31f, -3.82f);
            success3_2.transform.position = new Vector3(3, -16.31f, -3.82f);
            success3_3.transform.position = new Vector3(3, -15.43f, -3.66f);
        }

        //if (DetectPixels(lf_x, lf_y, detect_width, detect_height, 2) > cut)
        if (Detect_Borders(lf_x, lf_y, 2) > cut)
        {
            if (lf.enabled)
            {
                lf.enabled = false;
                lf_index = 0;

                click2.transform.position = new Vector3(-3, -14.22f, -3.39f);
                success2.transform.position = new Vector3(-3, -14.22f, -3.39f);
                success2_2.transform.position = new Vector3(-3, -14.75f, -3.49f);
                success2_3.transform.Translate(0, 0, 28f * Time.deltaTime);

            }
            else
            {

                click2.transform.position = new Vector3(-3, -16.31f, -3.82f);
                success2.transform.position = new Vector3(-3, -16.31f, -3.82f);
                success2_2.transform.position = new Vector3(-3, -16.31f, -3.82f);
                success2_3.transform.position = new Vector3(-3, -15.43f, -3.66f);
            }
        }
        else
        {
            click2.transform.position = new Vector3(-3, -16.31f, -3.82f);
            success2.transform.position = new Vector3(-3, -16.31f, -3.82f);
            success2_2.transform.position = new Vector3(-3, -16.31f, -3.82f);
            success2_3.transform.position = new Vector3(-3, -15.43f, -3.66f);
        }

        //if (DetectPixels(rh_x, rh_y, detect_width, detect_height, 3) > cut)
        if (Detect_Borders(rh_x, rh_y, 4) > cut)
        {
            if (rh.enabled)
            {
                rh.enabled = false;
                rh_index = 0;
                click4.transform.position = new Vector3(9, -14.22f, -3.39f);
                success4.transform.position = new Vector3(9, -14.22f, -3.39f);
                success4_2.transform.position = new Vector3(9, -14.75f, -3.49f);
                success4_3.transform.Translate(0, 0, 25f * Time.deltaTime);

            }
            else
            {
                click4.transform.position = new Vector3(9, -16.31f, -3.82f);
                success4.transform.position = new Vector3(9, -16.31f, -3.82f);
                success4_2.transform.position = new Vector3(9, -16.31f, -3.82f);
                success4_3.transform.position = new Vector3(9, -15.43f, -3.66f);
            }
        }
        else
        {
            click4.transform.position = new Vector3(9, -16.31f, -3.82f);
            success4.transform.position = new Vector3(9, -16.31f, -3.82f);
            success4_2.transform.position = new Vector3(9, -16.31f, -3.82f);
            success4_3.transform.position = new Vector3(9, -15.43f, -3.66f);
        }

        //if (DetectPixels(lh_x, lh_y, detect_width, detect_height, 4) > cut)
        if (Detect_Borders(lh_x, lh_y, 1) > cut)
        {

            if (lh.enabled)
            {
                lh.enabled = false;
                lh_index = 0;

                click1.transform.position = new Vector3(-9, -14.22f, -3.39f);
                success1.transform.position = new Vector3(-9, -14.22f, -3.39f);
                success1_2.transform.position = new Vector3(-9, -14.75f, -3.49f);
                success1_3.transform.Translate(0, 0, 25f * Time.deltaTime);

            }
            else
            {
                click1.transform.position = new Vector3(-9, -16.31f, -3.82f);
                success1.transform.position = new Vector3(-9, -16.31f, -3.82f);
                success1_2.transform.position = new Vector3(-9, -16.31f, -3.82f);
                success1_3.transform.position = new Vector3(-9, -15.43f, -3.66f);

            }
        }
        else
        {
            click1.transform.position = new Vector3(-9, -16.31f, -3.82f);
            success1.transform.position = new Vector3(-9, -16.31f, -3.82f);
            success1_2.transform.position = new Vector3(-9, -16.31f, -3.82f);
            success1_3.transform.position = new Vector3(-9, -15.43f, -3.66f);
        }



        if (!camAvailable)
            return;
        float ratio = (float)backCam.width / (float)backCam.height;
        //fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }






    float Distance(Color a, Color b)
    {
        return Mathf.Sqrt(Mathf.Pow(Mathf.Abs(a.r - b.r), 2) + Mathf.Pow(Mathf.Abs(a.g - b.g), 2) + Mathf.Pow(Mathf.Abs(a.b - b.b), 2));
    }

    float Detect_Borders(int x, int y, int choose)
    {
        int up = 0, i;
        switch (choose)
        {

            case 1:
                lh_prevarr = (Color[])lh_newarr.Clone();
                for (i = 0; i < detect_width; i++)
                {
                    lh_newarr[up] = backCam.GetPixel(x + i, y);
                    if (Distance(lh_prevarr[up], lh_newarr[up]) > cut) return Distance(lh_prevarr[up], lh_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_height; i++)
                {
                    lh_newarr[up] = backCam.GetPixel(x + detect_width - 1, y + i);
                    if (Distance(lh_prevarr[up], lh_newarr[up]) > cut) return Distance(lh_prevarr[up], lh_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_width; i++)
                {
                    lh_newarr[up] = backCam.GetPixel(x + detect_width - 1 - i, y + detect_height - 1);
                    if (Distance(lh_prevarr[up], lh_newarr[up]) > cut) return Distance(lh_prevarr[up], lh_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_height; i++)
                {
                    lh_newarr[up] = backCam.GetPixel(x, y + detect_height - 1 - i);
                    if (Distance(lh_prevarr[up], lh_newarr[up]) > cut) return Distance(lh_prevarr[up], lh_newarr[up]);
                    up++;
                }

                break;
            case 2:
                lf_prevarr = (Color[])lf_newarr.Clone();
                for (i = 0; i < detect_width; i++)
                {
                    lf_newarr[up] = backCam.GetPixel(x + i, y);
                    if (Distance(lf_prevarr[up], lf_newarr[up]) > cut) return Distance(lf_prevarr[up], lf_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_height; i++)
                {
                    lf_newarr[up] = backCam.GetPixel(x + detect_width - 1, y + i);
                    if (Distance(lf_prevarr[up], lf_newarr[up]) > cut) return Distance(lf_prevarr[up], lf_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_width; i++)
                {
                    lf_newarr[up] = backCam.GetPixel(x + detect_width - 1 - i, y + detect_height - 1);
                    if (Distance(lf_prevarr[up], lf_newarr[up]) > cut) return Distance(lf_prevarr[up], lf_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_height; i++)
                {
                    lf_newarr[up] = backCam.GetPixel(x, y + detect_height - 1 - i);
                    if (Distance(lf_prevarr[up], lf_newarr[up]) > cut) return Distance(lf_prevarr[up], lf_newarr[up]);
                    up++;
                }
                break;
            case 3:
                rf_prevarr = (Color[])rf_newarr.Clone();
                for (i = 0; i < detect_width; i++)
                {
                    rf_newarr[up] = backCam.GetPixel(x + i, y);
                    if (Distance(rf_prevarr[up], rf_newarr[up]) > cut) return Distance(rf_prevarr[up], rf_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_height; i++)
                {
                    rf_newarr[up] = backCam.GetPixel(x + detect_width - 1, y + i);
                    if (Distance(rf_prevarr[up], rf_newarr[up]) > cut) return Distance(rf_prevarr[up], rf_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_width; i++)
                {
                    rf_newarr[up] = backCam.GetPixel(x + detect_width - 1 - i, y + detect_height - 1);
                    if (Distance(rf_prevarr[up], rf_newarr[up]) > cut) return Distance(rf_prevarr[up], rf_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_height; i++)
                {
                    rf_newarr[up] = backCam.GetPixel(x, y + detect_height - 1 - i);
                    if (Distance(rf_prevarr[up], rf_newarr[up]) > cut) return Distance(rf_prevarr[up], rf_newarr[up]);
                    up++;
                }
                break;
            case 4:
                rh_prevarr = (Color[])rh_newarr.Clone();
                for (i = 0; i < detect_width; i++)
                {
                    rh_newarr[up] = backCam.GetPixel(x + i, y);
                    if (Distance(rh_prevarr[up], rh_newarr[up]) > cut) return Distance(rh_prevarr[up], rh_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_height; i++)
                {
                    rh_newarr[up] = backCam.GetPixel(x + detect_width - 1, y + i);
                    if (Distance(rh_prevarr[up], rh_newarr[up]) > cut) return Distance(rh_prevarr[up], rh_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_width; i++)
                {
                    rh_newarr[up] = backCam.GetPixel(x + detect_width - 1 - i, y + detect_height - 1);
                    if (Distance(rh_prevarr[up], rh_newarr[up]) > cut) return Distance(rh_prevarr[up], rh_newarr[up]);
                    up++;
                }
                for (i = 0; i < detect_height; i++)
                {
                    rh_newarr[up] = backCam.GetPixel(x, y + detect_height - 1 - i);
                    if (Distance(rh_prevarr[up], rh_newarr[up]) > cut) return Distance(rh_prevarr[up], rh_newarr[up]);
                    up++;
                }
                break;
            default:
                break;
        }


        return 0;


    }



    void Vars()
    {
        detect_height = (backCam.height * 4) / 16;
        detect_width = detect_height;
        //detect_width = (backCam.width * 1) / 16;
        detect_index = detect_height * detect_width;
        detect_borderindex = (2 * detect_height) + (2 * detect_width);

        rh_newarr = new Color[detect_borderindex];
        rf_newarr = new Color[detect_borderindex];
        lh_newarr = new Color[detect_borderindex];
        lf_newarr = new Color[detect_borderindex];

        lf_x = 0 + 3; lf_y = 0 + 3;
        rf_x = 0 + 3; rf_y = backCam.height - detect_height - 3;
        lh_x = backCam.width - detect_width - 3; lh_y = 0 + 3;
        rh_x = backCam.width - detect_width - 3; rh_y = backCam.height - detect_height - 3;
        //rf_x = 0 + 3; rf_y = 0 + 3;
        //rh_x = 0 + 3; rh_y = backCam.height - detect_height - 3;
        //lf_x = backCam.width - detect_width - 3; lf_y = 0 + 3;
        //lh_x = backCam.width - detect_width - 3; lh_y = backCam.height - detect_height - 3;

        rf_index = allindex;
        lf_index = allindex;
        rh_index = allindex;
        lh_index = allindex;
        click1 = GameObject.Find("Click1");
        click2 = GameObject.Find("Click2");
        click3 = GameObject.Find("Click3");
        click4 = GameObject.Find("Click4");
        success1 = GameObject.Find("Success1");
        success1_2 = GameObject.Find("Success1_2");
        success1_3 = GameObject.Find("Success1_3");
        success2 = GameObject.Find("Success2");
        success2_2 = GameObject.Find("Success2_2");
        success2_3 = GameObject.Find("Success2_3");
        success3 = GameObject.Find("Success3");
        success3_2 = GameObject.Find("Success3_2");
        success3_3 = GameObject.Find("Success3_3");
        success4 = GameObject.Find("Success4");
        success4_2 = GameObject.Find("Success4_2");
        success4_3 = GameObject.Find("Success4_3");
        rf.enabled = true;
        lf.enabled = true;
        rh.enabled = true;
        lh.enabled = true;
    }




    private float DetectPixels(int x, int y, int w, int h, int ind)
    {
        float answer;

        switch (ind)
        {
            case 1:
                rf_prevarr = (Color[])rf_newarr.Clone();
                rf_newarr = backCam.GetPixels(x, y, w, h);
                for (int i = 0; i < rf_newarr.Length; i++)
                {
                    answer = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(rf_prevarr[i].r - rf_newarr[i].r), 2) + Mathf.Pow(Mathf.Abs(rf_prevarr[i].g - rf_newarr[i].g), 2) + Mathf.Pow(Mathf.Abs(rf_prevarr[i].b - rf_newarr[i].b), 2));
                    if (answer > cut)
                    {
                        return answer;
                    }
                }

                break;
            case 2:
                lf_prevarr = (Color[])lf_newarr.Clone();
                lf_newarr = backCam.GetPixels(x, y, w, h);
                for (int i = 0; i < lf_newarr.Length; i++)
                {
                    answer = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(lf_prevarr[i].r - lf_newarr[i].r), 2) + Mathf.Pow(Mathf.Abs(lf_prevarr[i].g - lf_newarr[i].g), 2) + Mathf.Pow(Mathf.Abs(lf_prevarr[i].b - lf_newarr[i].b), 2));
                    if (answer > cut)
                    {
                        return answer;
                    }
                }

                break;

            case 3:
                rh_prevarr = (Color[])rh_newarr.Clone();
                rh_newarr = backCam.GetPixels(x, y, w, h);
                for (int i = 0; i < rh_newarr.Length; i++)
                {
                    answer = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(rh_prevarr[i].r - rh_newarr[i].r), 2) + Mathf.Pow(Mathf.Abs(rh_prevarr[i].g - rh_newarr[i].g), 2) + Mathf.Pow(Mathf.Abs(rh_prevarr[i].b - rh_newarr[i].b), 2));
                    if (answer > cut)
                    {
                        return answer;
                    }
                }

                break;
            case 4:
                lh_prevarr = (Color[])lh_newarr.Clone();
                lh_newarr = backCam.GetPixels(x, y, w, h);
                for (int i = 0; i < lh_newarr.Length; i++)
                {
                    answer = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(lh_prevarr[i].r - lh_newarr[i].r), 2) + Mathf.Pow(Mathf.Abs(lh_prevarr[i].g - lh_newarr[i].g), 2) + Mathf.Pow(Mathf.Abs(lh_prevarr[i].b - lh_newarr[i].b), 2));
                    if (answer > cut)
                    {
                        return answer;
                    }
                }

                break;

            default:
                break;


        }



        return 0;
    }



}