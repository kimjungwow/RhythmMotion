using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            this.transform.position = new Vector3(9, -14.22f, -3.39f);
        }

        else
        {
            this.transform.position = new Vector3(9, -16.31f, -3.82f);
        }
    }
}
