using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentScreen : MonoBehaviour
{
    public AudioClip break_snd;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Object") && Mathf.Abs(Vector2.Distance(other.gameObject.GetComponent<Rigidbody>().velocity, Vector2.zero)) > 0f) {
            AudioSource.PlayClipAtPoint(break_snd, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
