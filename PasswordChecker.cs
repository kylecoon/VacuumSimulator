using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordChecker : MonoBehaviour
{
    private string current_input;
    public GameObject platform;
    public void UpdatePassword(char c) {
        current_input += c;
        if (current_input.Length > 20) {
            current_input = current_input.Remove(0, 1);
        }
        Debug.Log(current_input);
        if (current_input == "rybbybryrbyrbybbrrby") {
            platform.transform.position = new Vector3(platform.transform.position.x, 12.0f, transform.position.z);
        }
    }
}
