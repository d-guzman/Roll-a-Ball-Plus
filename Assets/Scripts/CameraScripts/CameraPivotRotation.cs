using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotRotation : MonoBehaviour {
    public float rotateSpeed;
    public float rotateDamp;

    private float camHori;
    private float camVert;

    private const float Y_ANGLE_MAX = 89.5f;
    private const float Y_ANGLE_MIN = -89.5f;

    private Quaternion nextRotation;

    void LateUpdate () {
        camHori += Input.GetAxisRaw("CamHorizontal") * rotateSpeed;
        camVert += Input.GetAxisRaw("CamVertical") * rotateSpeed;
        camVert = Mathf.Clamp(camVert, Y_ANGLE_MIN, Y_ANGLE_MAX);

        nextRotation = Quaternion.Euler(camVert, camHori, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, nextRotation, rotateDamp);
    }
}
