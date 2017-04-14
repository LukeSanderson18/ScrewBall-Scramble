using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetStopper : MonoBehaviour {

    public GameObject magnet;
    public GameObject magnetStopperObj;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == magnetStopperObj)
        {
            print("hit");
            magnet.transform.position = Vector3.one * 100;  
        }
    }
}
