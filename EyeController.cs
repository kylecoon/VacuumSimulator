using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    private Vector3 initial_position;
    public Transform hose;
    // Start is called before the first frame update
    void Awake()
    {
        initial_position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = initial_position + new Vector3(hose.position.x - transform.position.x, hose.position.y - transform.position.y, 0).normalized * 0.1f;
    }
}
