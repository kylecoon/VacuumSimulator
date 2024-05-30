using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    private bool in_wall = false;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Surface")) {
            in_wall = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Surface")) {
            in_wall = false;
        }
    }

    public bool Check_in_wall() {
        return in_wall;
    }

}
