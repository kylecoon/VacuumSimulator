using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public AudioClip pop_snd;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Knife") {
            AudioSource.PlayClipAtPoint(pop_snd, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
