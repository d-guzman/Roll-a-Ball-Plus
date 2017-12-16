using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPadScript : MonoBehaviour {
    public float BoostStrength;
    private Rigidbody otherRigidbody;

    void OnTriggerEnter(Collider other) {
        otherRigidbody = other.GetComponent<Rigidbody>();
        if (otherRigidbody != null) {
            otherRigidbody.velocity = transform.forward;
            otherRigidbody.AddForce(transform.forward * BoostStrength, ForceMode.Impulse);
        }
    }
	
}
