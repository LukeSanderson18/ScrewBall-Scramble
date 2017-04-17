using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour {

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Flip();
        }
    }
    void Flip()
    {
        rb.AddForceAtPosition(Vector3.up * 3000, transform.GetChild(0).position);
    }
}
