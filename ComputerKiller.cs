using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerKiller : MonoBehaviour
{
    public GameObject screen;
    public GameObject screenLight;
    public GameObject platform;
    public AudioClip zap;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Laptop") {
            KillComputer();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Laptop") {
            KillComputer();
        }
    }

    void KillComputer() {
        if (screen != null) {
            AudioSource.PlayClipAtPoint(zap, Camera.main.transform.position);
            Destroy(screen);
            Destroy(screenLight.GetComponent<Light>());
            platform.transform.position = new Vector3(platform.transform.position.x, 12.0f, transform.position.z);
        }
    }
}
