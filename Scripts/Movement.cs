using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public bool can_move = true;
    Rigidbody rb;
    public Transform origin;
    public float hose_length = 2f;
    private Vector2 target_position;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (can_move) {
            GetInput();
        }
        else {
            rb.velocity = Vector2.right * 1f;
        }
    }

    void GetInput() {
        //convert mouse position to world position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane + 6.55f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        //if mouse has moved far enough away from hose, move hose
        if (Vector2.Distance(worldPosition, transform.position) >= 0.1f) {
            UpdateRotation(Vector2.SignedAngle(Vector2.right, worldPosition - transform.position));
            if (Vector2.Distance(origin.position, worldPosition) > hose_length) {
                target_position = origin.position + (worldPosition - origin.position).normalized * hose_length;
            }
            else {
                target_position = worldPosition;
            }
            rb.velocity = (target_position - (Vector2)transform.position) * (3.0f + Vector2.Distance(transform.position, worldPosition));
        } 
        //hose has reached mouse
        else {
            rb.velocity = Vector3.zero;
        }
    }
    void UpdateRotation(float angle) {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle - 90.0f);
    }
}
