using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPostition = new Vector3(target.position.x*0.25f,
                                        target.transform.position.y *0.25f,
                                        target.position.z *0.25f);
        transform.LookAt(targetPostition);
        //transform.LookAt(target);
	}
}
