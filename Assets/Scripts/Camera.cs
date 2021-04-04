using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float mouse_sensitivity = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void LateUpdate()
    {
        yaw += mouse_sensitivity * Input.GetAxis("Mouse X");
        pitch -= mouse_sensitivity * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
