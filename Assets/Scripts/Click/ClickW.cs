using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickW : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position = new Vector3(-3, -14.22f, -3.39f);
        }

        else
        {
            this.transform.position = new Vector3(-3, -16.31f, -3.82f);
        }
    }
}
