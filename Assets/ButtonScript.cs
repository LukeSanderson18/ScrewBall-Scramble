using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public enum ButtonType { Bridge , Crane };

    public ButtonType myButtonType;

    //

    public Rigidbody[] bridges;
    public float bridgeForce = 200f;

    //

    public Transform craneMagnet;
    public Rigidbody crane;
    public Rigidbody metalBall;
    public float magnetForce = 100f;
    public float magnetDistance = 2f;

    //
	
	void Update () {

        switch (myButtonType)
        {
            case ButtonType.Bridge:
                Bridge();
                break;
            case ButtonType.Crane:
                Crane();
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

    void Crane()
    {
        if (Vector3.Distance(craneMagnet.position,metalBall.transform.position) < magnetDistance)       //if close enough, do magnetism.
        {
            print("do it");
            metalBall.AddExplosionForce(magnetForce * -1, craneMagnet.position, magnetDistance);
            //(Vector3.Lerp(metalBall.transform.position, craneMagnet.position, Time.deltaTime));
            //metalBall.AddForce((craneMagnet.position - metalBall.transform.position) * magnetForce);
            //magnetForce = Vector3.Distance(craneMagnet.position, metalBall.transform.position) * 250;
            //magforce =  1 divided by the distance between the two squared.
        }

        crane.AddTorque(Vector3.up * Input.GetAxis("Horizontal") * 2);

    }
}
