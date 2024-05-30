using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    public StateController s;
    
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Surface") || other.CompareTag("Object")) {
            s.against_surface = true;
        }
        if (other.GetComponent<Rigidbody>() != null) {
            if (s.GetState() == 1) {
                other.GetComponent<Rigidbody>().AddForce(transform.up * 15f);
            }
            if (s.GetState() == 2) {
                other.GetComponent<Rigidbody>().AddForce(-transform.up * 15f);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Surface") || other.CompareTag("Object")) {
            s.against_surface = false;
        }
    }

}
