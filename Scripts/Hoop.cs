using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public AudioClip unlock;
    public GameObject door;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object")) {
            Destroy(door);
            AudioSource.PlayClipAtPoint(unlock, Camera.main.transform.position);
        }
    }
}
