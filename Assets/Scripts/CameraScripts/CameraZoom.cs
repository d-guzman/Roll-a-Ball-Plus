using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    public Transform camPivot;
    private Vector3 originalDist;

    void Start()
    {
        originalDist = transform.localPosition;
    }

    void FixedUpdate () {
        RaycastHit hitInfo;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        
        if (Physics.Raycast(camPivot.position, -camPivot.forward, out hitInfo, 10.0f, layerMask))
        {
            Debug.DrawRay(camPivot.position, -camPivot.forward * hitInfo.distance, Color.red, .1f);
            Vector3 CurrentPosition = transform.localPosition;
            Vector3 NextPosition = new Vector3(0, 0, -hitInfo.distance);
            transform.localPosition = Vector3.Lerp(CurrentPosition, NextPosition, .15f);
            //transform.localPosition = new Vector3(0, 0, -hitInfo.distance);
        }
        else
        {
            Vector3 CurrentPosition = transform.localPosition;
            transform.localPosition = Vector3.Lerp(CurrentPosition, originalDist, .1f);
            //transform.localPosition = originalDist;
        }
    }
}
