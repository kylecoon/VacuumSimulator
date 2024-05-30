using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    public Tutorial toot;
    public AudioClip unlock;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lock" && door.GetComponent<Rigidbody>().isKinematic == true) {
            AudioSource.PlayClipAtPoint(unlock, Camera.main.transform.position);
            door.GetComponent<Rigidbody>().isKinematic = false;
            toot.UpdateTutorial(1);
        }
    }
}
