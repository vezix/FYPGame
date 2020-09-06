﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    public bool useoffsetvalues;
    public float rotatespeed;
    public Transform pivot;
    public float maxViewAngle;
    public float minViewAngle;
    public bool invertY;

    void Start()
    {
        if (!useoffsetvalues)
        {
            offset = target.position - transform.position;
        }
        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform; //OGCODE
        pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {   if (Cursor.lockState == CursorLockMode.Locked)
        {
            pivot.transform.position = target.transform.position; //Not OG

            //get x position of the mouse n rotate target
            float horizontal = Input.GetAxis("Mouse X") * rotatespeed;
            //target.Rotate(0,horizontal, 0); //OGCODE
            pivot.Rotate(0, horizontal, 0);
            //get y position of the mouse and rotate the pivot
            float vertical = Input.GetAxis("Mouse Y") * rotatespeed;
            if (invertY)
            {
                pivot.Rotate(vertical, 0, 0);
            }
            else
            {
                pivot.Rotate(-vertical, 0, 0);
            }
            //limit up/down camera rotation
            if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180.0f)
            {
                pivot.rotation = Quaternion.Euler(maxViewAngle, pivot.eulerAngles.y, 0.0f);
            }

            if (pivot.rotation.eulerAngles.x > 180.0f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
            {
                pivot.rotation = Quaternion.Euler(360.0f + minViewAngle, pivot.eulerAngles.y, 0.0f);
            }
            // move the camera based n the target's rotation and original offset.
            //float desiredYAngle = target.eulerAngles.y; //OG
            float desiredYAngle = pivot.eulerAngles.y;
            float desiredXAngle = pivot.eulerAngles.x;
            Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
            transform.position = target.position - (rotation * offset);
            //transform.position = target.position - offset;

            if (transform.position.y < target.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
            }
            transform.LookAt(target);
        }
    }
}
