using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraNotifier : MonoBehaviour
{
    bool transitioning = false;
    int current_id = 0;
    public GameObject cam;
    private List<float> y_positions = new List<float>();
    private List<float> x_rotations = new List<float>();

    void Start()
    {
        y_positions.Add(2.91f);
        y_positions.Add(9.1f);

        x_rotations.Add(7.48f);
        x_rotations.Add(24.32f);
    }
    // Start is called before the first frame update
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CamTrigger") && !transitioning) {
            transitioning = true;
            if (current_id < int.Parse(other.gameObject.name)) {
                StartCoroutine(MoveCamera(current_id, current_id+1));
                ++current_id;
            }
            else {
                StartCoroutine(MoveCamera(current_id, current_id-1));
                --current_id;
            }
        }
    }

    IEnumerator MoveCamera(int initial_index, int target_index) {

        for (int i = 0; i < 20; ++i) {
            cam.transform.position += new Vector3(0, (y_positions[target_index] - y_positions[initial_index]) / 20f, 0);
            cam.transform.rotation = Quaternion.Euler(Vector3.Lerp(new Vector3(x_rotations[initial_index], 0, 0), new Vector3(x_rotations[target_index], 0, 0), i * 0.05f));
            yield return new WaitForSeconds(0.025f);
        }
        transitioning = false;
        yield return null;
    }
}
