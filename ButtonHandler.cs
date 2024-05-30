using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public char button_id;
    public AudioClip button_snd;
    private bool accepting_input = true;

    void OnCollisionEnter(Collision other)
    {
        if (!accepting_input) {
            return;
        }
        AudioSource.PlayClipAtPoint(button_snd, Camera.main.transform.position);
        transform.parent.gameObject.GetComponent<PasswordChecker>().UpdatePassword(button_id);
    }

    void OnCollisionExit(Collision other)
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay() {
        accepting_input = false;
        yield return new WaitForSeconds(0.2f);
        accepting_input = true;
    }
}
