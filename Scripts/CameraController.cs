using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool can_move = true;
    private GameObject player;
    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (can_move) {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, transform.position.z);
        }
        
    }
}
