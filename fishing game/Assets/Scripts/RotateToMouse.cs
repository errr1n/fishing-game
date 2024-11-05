using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public Transform flashlight; 
    public float rotateSpeed;
    float flashlightAngle; 
    float flashlightAngle2; 

    public Vector2 turn;

    // Update is called once per frame
    void Update()
    {
        RotateFlashlightUp();
        RotateFlashlightSide();

        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");

        // // turn.y = Mathf.Clamp(turn.y, 90, 270);
        // flashlight.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }

    void RotateFlashlightUp()
    {
        flashlightAngle += Input.GetAxis("Mouse X") * rotateSpeed * -Time.deltaTime;
        // flashlightAngle = Mathf.Clamp(flashlightAngle, 270, 360);
        flashlight.localRotation = Quaternion.AngleAxis(flashlightAngle, Vector3.forward); //rotate on Y
    }

    void RotateFlashlightSide()
    {
        flashlightAngle2 += Input.GetAxis("Mouse Y") * rotateSpeed * -Time.deltaTime;
        flashlightAngle2 = Mathf.Clamp(flashlightAngle2, 85, 92);
        flashlight.localRotation = Quaternion.AngleAxis(flashlightAngle2, Vector3.right); //rotate on X

        // transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

    }
}
