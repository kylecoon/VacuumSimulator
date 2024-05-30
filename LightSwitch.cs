using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private bool on = false;
    public GameObject lights;
    public Tutorial toot;
    public AudioClip light_up;
    public AudioClip light_down;
    // Start is called before the first frame update
    void OnCollisionStay(Collision other)
    {
        if (transform.rotation.z > 0.38f && !on) {
            AudioSource.PlayClipAtPoint(light_up, Camera.main.transform.position);
            on = true;
            lights.SetActive(true);
            toot.UpdateTutorial(0);

        }
        if (transform.rotation.z < -0.38f && on) {
            AudioSource.PlayClipAtPoint(light_down, Camera.main.transform.position);
            on = false;
            lights.SetActive(false);
        }
    }
}
