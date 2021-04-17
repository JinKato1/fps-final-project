using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float mouse_sensitivity = 0.01f;

    public GameObject pause_screen;

    // Start is called before the first frame update
    void Start()
    {

    }

    void LateUpdate()
    {
        if (!pause_screen.activeInHierarchy)
        {
            yaw += mouse_sensitivity * Input.GetAxis("Mouse X");
            pitch -= mouse_sensitivity * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
