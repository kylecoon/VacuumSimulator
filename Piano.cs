using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public AudioClip note;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        AudioSource.PlayClipAtPoint(note, Camera.main.transform.position);
    }
}
