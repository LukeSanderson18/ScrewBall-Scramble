using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour {

    Rigidbody rb;
    public BoxCollider bc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Flip();
            Invoke("Kill", 0.2f);
        }
    }
    void Flip()
    {
        rb.AddForceAtPosition(Vector3.up * 9000, transform.GetChild(0).position);
    }

    void Kill()
    {
        bc.enabled = false;
    }
}
