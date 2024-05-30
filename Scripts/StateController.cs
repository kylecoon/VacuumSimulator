using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class StateController : MonoBehaviour
{
    public bool can_switch = true;
    private int state_id; //0 = empty, 1 = blowing, 2 = sucking, 3 = full, 4 = idle
    private GameObject object_reference;
    public bool against_surface;
    public AudioClip pickup;
    public AudioClip shoot;
    public AudioClip drop;
    public AudioSource audSrc;
    public GameObject blowParticles;
    public GameObject suckParticles;
    public GameObject player;
    private Rigidbody player_rb;
    private Rigidbody rb;
    private float speed_multiplier;
    public Transform origin;
    RaycastHit hit;

    public Tutorial toot;
    public bool can_suck = false;
    public bool can_shoot = false;
    public bool can_blow = false;

    void Awake()
    {
        speed_multiplier = 0.1f;
        rb = GetComponent<Rigidbody>();
        player_rb = player.GetComponent<Rigidbody>();
        state_id = 0;
        against_surface = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Object") && state_id == 2) {
            AudioSource.PlayClipAtPoint(pickup, Camera.main.transform.position);
            SetHeldObject(other.gameObject);
        }
    }

    void Update()
    {
        GetInput();
    }

    void GetInput() {
        switch (state_id) {
            //empty
            case 0:
                if (Input.GetMouseButtonDown(0) && can_blow) {
                    audSrc.Play();
                    blowParticles.SetActive(true);
                    state_id = 1;
                    StartCoroutine(IncreaseSpeed());
                    break;
                }
                if (Input.GetMouseButtonDown(1) && can_suck) {
                    audSrc.Play();
                    suckParticles.SetActive(true);
                    state_id = 2;
                    break;
                }
                break;
            //blow
            case 1:
                if (Input.GetMouseButtonUp(0) && can_switch) {
                    audSrc.Stop();
                    blowParticles.SetActive(false);
                    state_id = 0;
                    speed_multiplier = 0.1f;
                    break;
                }
                if (against_surface) {
                    if (!Physics.Raycast(origin.position, transform.position - origin.position, out hit, Vector2.Distance(origin.position, transform.position)) || !hit.collider.CompareTag("Surface")) {
                        player_rb.velocity = 1.5f * speed_multiplier * -transform.up;
                        rb.velocity += 1.5f * speed_multiplier * -transform.up;
                    }
                }
                break;
            //suck
            case 2:
                if (Input.GetMouseButtonUp(1)) {
                    audSrc.Stop();
                    suckParticles.SetActive(false);
                    state_id = 0;
                    break;
                }
                break;
            //full
            case 3:
                if (object_reference.GetComponent<ObjectCollider>().Check_in_wall() || !can_shoot) {
                    break;
                }
                if (Input.GetMouseButtonDown(0)) {
                    if (!can_blow) {
                        toot.UpdateTutorial(2);
                    }
                    AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position);
                    ReleaseItem(15.0f);
                    break;
                }
                if (Input.GetMouseButtonDown(1)) {
                    if (!can_blow) {
                        toot.UpdateTutorial(2);
                    }
                    AudioSource.PlayClipAtPoint(drop, Camera.main.transform.position);
                    ReleaseItem(0.0f);
                    break;
                }
                break;
            //idle
            case 4:
                if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1)) {
                    state_id = 0;
                    break;
                }
                break;
        }
    }

    public int GetState() {
        return state_id;
    }

    private void SetHeldObject(GameObject other) {
        state_id = 3;
        audSrc.Stop();
        suckParticles.SetActive(false);
        other.transform.parent = transform;
        other.transform.SetLocalPositionAndRotation(new Vector3(0, 0.7f, 0), Quaternion.identity);
        other.GetComponent<Rigidbody>().isKinematic = true;
        if (other.GetComponent<MeshCollider>() != null) {
            other.GetComponent<MeshCollider>().isTrigger = true;
        }
        else {
            other.GetComponent<BoxCollider>().isTrigger = true;
        }
        object_reference = other;
    }

    IEnumerator IncreaseSpeed() {
        for (int i = 0; i < 20; ++i) {
            yield return new WaitForSeconds(0.025f);
            speed_multiplier += 0.045f;
        }
        yield return null;
    }

    void ReleaseItem(float speed) {
        state_id = 4;
        if (object_reference.GetComponent<MeshCollider>() != null) {
            object_reference.GetComponent<MeshCollider>().isTrigger = false;
        }
        else {
            object_reference.GetComponent<BoxCollider>().isTrigger = false;
        }
        object_reference.transform.parent = null;
        object_reference.GetComponent<Rigidbody>().isKinematic = false;
        object_reference.GetComponent<Rigidbody>().velocity = transform.up * speed;
    }
}
