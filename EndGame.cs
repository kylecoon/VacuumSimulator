using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public CameraController cam;
    public Movement mov;
    public StateController st8;
    private GameObject hose;
    private GameObject player;
    private Rigidbody rb;
    public GameObject endtext;
    bool ended = false;
    void Start()
    {
        hose = GameObject.Find("Hose");
        player = GameObject.Find("Player");
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (ended) {
            return;
        }
        if (other.gameObject.name == "Air" && hose.GetComponent<StateController>().GetState() == 1) {
            ended = true;
            endtext.SetActive(true);
            rb.isKinematic = false;
            cam.can_move = false;
            player.transform.parent = transform;
            hose.transform.parent = player.transform;
            mov.can_move = false;
            st8.can_switch = false;
            rb.velocity = Vector2.right * 2;
        }
    }
}
