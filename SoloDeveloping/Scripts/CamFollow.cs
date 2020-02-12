using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //Floats meant to =be editable for best result
    public float camSpeed = 120f;
    public float angle = 57f;
    public float sensitivity = 150f;

    //Floats to do with axis
    public float camDistX;
    public float camDistY;
    public float camDistZ;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    public float rotX;
    public float rotY;

    //GameObjects
    public GameObject camTarget;
    public GameObject cam;
    public GameObject Player;

    Vector3 followPos;


    void Start()
    {
        //Get the rotations of the camera
        Vector3 rot = transform.localRotation.eulerAngles;
        //set rotations to the variables
        rotX = rot.x;
        rotY = rot.y;
        //Locks mouse in center of screen and makes cursor invisable
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Make new float and set to the joystick axisses (edit > project settings > input)
        float inputX = Input.GetAxis("RightStickHor");
        float inputZ = Input.GetAxis("RightStickVer");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        //
        rotX += finalInputZ * sensitivity * Time.deltaTime;
        rotY += finalInputX * sensitivity * Time.deltaTime;

        //Locks the angle (clamps it)
        rotX = Mathf.Clamp(rotX, -angle, angle);
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = localRotation;
    }

    private void LateUpdate()
    {
        CamUpdater();
    }
    void CamUpdater()
    {
        // Set the target position that you follow
        Transform target = camTarget.transform;

        //Moves to target
        float step = camSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
