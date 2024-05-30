using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLightHandler : MonoBehaviour
{   
    public GameObject roomba;
    public GameObject boss_text;
    public AudioClip spotlight;
    public GameObject hatch;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<Light>().enabled == false) {

            if (gameObject.name == "BossLight4") {
                roomba.SetActive(true);
                hatch.transform.position = new Vector3(hatch.transform.position.x, 14.81466f, hatch.transform.position.z);
            }
            if (spotlight != null) {
                AudioSource.PlayClipAtPoint(spotlight, Camera.main.transform.position);
            }
            
            GetComponent<Light>().enabled = true;
            boss_text.SetActive(true);
        }


    }
}
