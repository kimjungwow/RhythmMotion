using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickE3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Translate(0, 0, 23f * Time.deltaTime);
        }

        else
        {
            this.transform.position = new Vector3(3, -15.43f, -3.66f);
        }
        
    }
}
