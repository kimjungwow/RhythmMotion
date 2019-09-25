using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickR3: MonoBehaviour
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
            this.transform.Translate(0, 0, 20f * Time.deltaTime);
        }

        else
        {
            this.transform.position = new Vector3(9, -15.43f, -3.66f);
        }
    }
}
