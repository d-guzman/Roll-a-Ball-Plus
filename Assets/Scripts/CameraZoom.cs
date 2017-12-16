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

    void LateUpdate () {
        RaycastHit hitInfo;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (Physics.Raycast(camPivot.position, -camPivot.forward, out hitInfo, 10.0f, layerMask))
        {
            transform.localPosition = new Vector3(0, 0, -hitInfo.distance);
        }
        else
        {
            transform.localPosition = originalDist;
        }
    }
}
