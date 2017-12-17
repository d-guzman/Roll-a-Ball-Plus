using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleRotator : MonoBehaviour {
	void Update () {
        transform.Rotate(new Vector3(10,35,45) * Time.deltaTime);
	}
}
