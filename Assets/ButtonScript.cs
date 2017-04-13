using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public enum ButtonType { Bridge };

    public ButtonType myButtonType;

    //

    public Rigidbody[] bridges;
    public float bridgeForce = 200f;
	
	void Update () {

        switch (myButtonType)
        {
            case ButtonType.Bridge:
                Bridge();
                break;
            default:
                print("forgot to assign button type to " + gameObject.name);
                break;
        }

    }

    void Bridge()
    {
        foreach (Rigidbody rb in bridges)
        {
           // bool jump = Input.GetButton("Jump");

            if (Input.GetButton("Jump"))
            {
                rb.AddTorque(Vector3.right * bridgeForce);
            }
            else
            {
                rb.AddTorque(-Vector3.right * bridgeForce);
            }
        }
        
    }
}
