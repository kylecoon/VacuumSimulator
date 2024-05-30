using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] sprites;
    private int index = -1;
    public StateController st8;
    public GameObject key;
    private float initial_y;
    void Start()
    {
        initial_y = 2.13f;
    }

    public void UpdateTutorial(int new_index) {
        if (new_index <= index) {
            return;
        }
        if (new_index == 0) {
            ++index;
            sprites[0].SetActive(true);
            st8.can_suck = true;
            key.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (new_index == 1) {
            ++index;
            sprites[0].SetActive(false);
            sprites[1].SetActive(true);
            st8.can_shoot = true;
        }
        if (new_index == 2) {
            ++index;
            sprites[1].SetActive(false);
            sprites[2].SetActive(true);
            st8.can_blow = true;
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, initial_y + (Mathf.Cos(Time.time) * 0.3f), transform.position.z);
    }
}
