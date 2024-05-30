using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    public AudioClip unlock_snd;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.name == "Key(Clone)" && door.GetComponent<Rigidbody>().isKinematic == true) {
            door.GetComponent<Rigidbody>().isKinematic = false;
            AudioSource.PlayClipAtPoint(unlock_snd, Camera.main.transform.position);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
        if (other.gameObject.name == "Key(Clone)" && door.GetComponent<Rigidbody>().isKinematic == true) {
            door.GetComponent<Rigidbody>().isKinematic = false;
            AudioSource.PlayClipAtPoint(unlock_snd, Camera.main.transform.position);
        }
    }

    void Update()
    {
        if (GameObject.Find("Key(Clone)") != null && GameObject.Find("Key(Clone)").transform.position.x < 4.5f && door.GetComponent<Rigidbody>().isKinematic == true) {
            Destroy(GameObject.Find("Key(Clone)"));
            door.GetComponent<Rigidbody>().isKinematic = false;
            AudioSource.PlayClipAtPoint(unlock_snd, Camera.main.transform.position);
        }
    }
}
