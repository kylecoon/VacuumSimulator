using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public AudioClip break_snd;
    public bool has_key;
    public GameObject key;
    public GameObject shard;
    //public GameObject;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Hose")) {
            return;
        }
        if (Mathf.Abs(Vector2.Distance(GetComponent<Rigidbody>().velocity, Vector2.zero)) > 1.0f) {
            AudioSource.PlayClipAtPoint(break_snd, Camera.main.transform.position);
            if (has_key) {
                Instantiate(key, transform.position, transform.rotation);
            }
            Instantiate(shard, transform.position, transform.rotation);
            Instantiate(shard, transform.position, transform.rotation);
            Instantiate(shard, transform.position, transform.rotation);
            Instantiate(shard, transform.position, transform.rotation);
            Instantiate(shard, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
