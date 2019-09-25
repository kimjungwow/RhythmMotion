using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl : MonoBehaviour
{
    public Transform successBurst;
    public Transform failBurst;
    public int scoreValue;
    //private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "FailCollider")
        {
            Instantiate(failBurst, transform.position, failBurst.rotation);
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Success1" || other.gameObject.name == "Success1_2" || other.gameObject.name == "Success1_3" || other.gameObject.name == "Success2" || other.gameObject.name == "Success2_2" || other.gameObject.name == "Success2_3" || other.gameObject.name == "Success3" || other.gameObject.name == "Success3_2" || other.gameObject.name == "Success3_3" || other.gameObject.name == "Success4" || other.gameObject.name == "Success4_2" || other.gameObject.name == "Success4_3")
        {
            Instantiate(successBurst, transform.position, successBurst.rotation);
            Destroy(gameObject);
        }



    }


}
