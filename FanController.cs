using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public Fan_Rotation fr;
    public GameObject air;
    public GameObject wall;
    public AudioClip break_snd;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        AudioSource.PlayClipAtPoint(break_snd, Camera.main.transform.position);
        fr.speed = 0;
        Destroy(air);
        Destroy(wall);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = Vector3.forward * 5;
        GetComponent<BoxCollider>().size = new Vector3(GetComponent<BoxCollider>().size.x, GetComponent<BoxCollider>().size.y, 0.4f);
        Destroy(GetComponent<FanController>());
    }
}
