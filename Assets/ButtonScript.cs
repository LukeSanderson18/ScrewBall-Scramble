using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public enum ButtonType { Bridge, Crane, Bars , Maze };

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
    public float craneSpeed = 1000f;

    //

    public Transform[] bars;
    public float barSpeed = 5f;
    public float barDistnace = 5f;

    //

    public Transform[] mazes;

    void Update()
    {

        switch (myButtonType)
        {
            case ButtonType.Bridge:
                Bridge();
                break;
            case ButtonType.Crane:
                Crane();
                break;
            case ButtonType.Bars:
                Bars();
                break;
            case ButtonType.Maze:
                Maze();
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
        if (Vector3.Distance(craneMagnet.position, metalBall.transform.position) < magnetDistance)       //if close enough, do magnetism.
        {
            metalBall.AddExplosionForce(magnetForce * -1, craneMagnet.position, magnetDistance);
            //(Vector3.Lerp(metalBall.transform.position, craneMagnet.position, Time.deltaTime));
            //metalBall.AddForce((craneMagnet.position - metalBall.transform.position) * magnetForce);
            //magnetForce = Vector3.Distance(craneMagnet.position, metalBall.transform.position) * 250;
            //magforce =  1 divided by the distance between the two squared.
        }

        crane.AddTorque(Vector3.up * Input.GetAxis("Horizontal") * craneSpeed);

    }

    void Bars()
    {

        if (Input.GetButton("Jump"))
        {
            bars[0].rotation = Quaternion.Lerp(bars[0].rotation, Quaternion.Euler(new Vector3(0, 180 + barDistnace, 0)), Time.deltaTime * barSpeed);
            bars[1].rotation = Quaternion.Lerp(bars[1].rotation, Quaternion.Euler(new Vector3(0, 180 - barDistnace, 0)), Time.deltaTime * barSpeed);
        }
        else for (int i = 0; i < bars.Length; i++)
        {
            bars[i].rotation = Quaternion.Lerp(bars[i].rotation, Quaternion.Euler(new Vector3(0, 180, 0)), Time.deltaTime * barSpeed);
        }

    }

    void Maze()
    {
        float tiltAngle = 12f;
        foreach (Transform maze in mazes)
        {
            float tiltAroundZ = -Input.GetAxis("Horizontal") * tiltAngle;
            float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

            maze.transform.rotation = Quaternion.Slerp(maze.transform.rotation, target, Time.deltaTime * 8);

            //old code that didnt like playing nice.

            // maze.transform.rotation = Quaternion.Lerp(maze.transform.rotation, Quaternion.EulerAngles(new Vector3(-90,10* hor,0)), Time.deltaTime * 8);
            //maze.transform.rotation = Quaternion.Lerp(maze.transform.localRotation,Quaternion.Euler(new Vector3((-90 + ver * 10) + (hor*10),0 ,0)),Time.deltaTime * barSpeed);
            /*
            curRot.x += Input.GetAxis("Vertical") * Time.deltaTime * tiltSpeed;
            curRot.y += Input.GetAxis("Horizontal") * Time.deltaTime * tiltSpeed;
            // Restrict rotation along x and z axes to the limit angles:
            curRot.x = Mathf.Clamp(curRot.x, minX, maxX);
            curRot.y = Mathf.Clamp(curRot.z, minZ, maxZ);

            // Set the object rotation
            */
            // maze.transform.eulerAngles = curRot;
        }

    }
}
