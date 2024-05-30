using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCollider : MonoBehaviour
{
    public float push_speed = 10f;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) {
            GameObject.Find("Player").GetComponent<Rigidbody>().AddForce(Vector2.right * push_speed);
            return;
        }   
        if (other.gameObject.GetComponent<Rigidbody>() == null) {
            return;
        }
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector2.right * push_speed * 3);
    }
}
