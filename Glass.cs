using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public AudioClip glass_break;
    public GameObject glassShard;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Roomba") {
            AudioSource.PlayClipAtPoint(glass_break, Camera.main.transform.position);
            Instantiate(glassShard, transform.position, Quaternion.identity);
            Instantiate(glassShard, transform.position, Quaternion.identity);
            Instantiate(glassShard, transform.position, Quaternion.identity);
            Instantiate(glassShard, transform.position, Quaternion.identity);
            Instantiate(glassShard, transform.position, Quaternion.identity);
            Instantiate(glassShard, transform.position, Quaternion.identity);
            Instantiate(glassShard, transform.position, Quaternion.identity);
            Instantiate(glassShard, transform.position, Quaternion.identity);
            Instantiate(glassShard, transform.position, Quaternion.identity);
            Instantiate(glassShard, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
