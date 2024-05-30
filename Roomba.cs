using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba : MonoBehaviour
{
    public GameObject spotlight;
    Transform player;
    Rigidbody rb;
    public GameObject light_src;
    private bool alive = true;
    public AudioClip hum;

    void OnEnable()
    {
        GetComponent<AudioSource>().Play();
    }
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive) {
            return;
        }
        if (rb.isKinematic) {
            GetComponent<AudioSource>().clip = hum;
            GetComponent<AudioSource>().Play();
            alive = false;
            spotlight.SetActive(true);
            return;
        }
        if (player.position.x < transform.position.x) {
            rb.velocity = Vector2.left;
            light_src.transform.localPosition = new Vector3(-0.25f, light_src.transform.localPosition.y, light_src.transform.localPosition.z);
        }
        else {
            rb.velocity = Vector2.right;
            light_src.transform.localPosition = new Vector3(0.25f, light_src.transform.localPosition.y, light_src.transform.localPosition.z);
        }
    }
}
