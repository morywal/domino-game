using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAndOn : MonoBehaviour
{

    public GameObject On;
    public GameObject Off;
    public GameObject TriggerObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(TriggerObject == other.gameObject)
        {
            On.SetActive(true);
            Off.SetActive(false);  
        }
        

    }
    void OnTriggerEnter(Collider other)
    {
        if (TriggerObject == other.gameObject)
        {
            On.SetActive(true);
            Off.SetActive(false);
        }
    }
    
}
