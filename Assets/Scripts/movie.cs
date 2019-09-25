using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class movie : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
        
    }
    
}
