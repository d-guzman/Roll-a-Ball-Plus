﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotPosition : MonoBehaviour {
    [Tooltip("Whatever transform is here is will be the point that the camera moves around.")]
    public Transform camFocus;

    //private Vector3 offset;

	void Start () {
        //offset = transform.position;	
	}
	
	void LateUpdate () {
        // transform.position = camFocus.position + offset;
        transform.position = camFocus.position;
    }
}
