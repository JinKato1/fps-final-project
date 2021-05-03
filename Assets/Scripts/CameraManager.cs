using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    //found from Youtube video "Rotae Camera With Mouse in Unity 3D" by Learn Everything Fast
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float mouse_sensitivity = 0.01f;

    public GameObject pause_screen, game_over_screen;

    // Start is called before the first frame update
    void Start()
    {

    }

    void LateUpdate()
    {
        if (!pause_screen.activeInHierarchy && !game_over_screen.activeInHierarchy)
        {
            //found from Youtube video "Rotae Camera With Mouse in Unity 3D" by Learn Everything Fast
            yaw += mouse_sensitivity * Input.GetAxis("Mouse X");
            pitch -= mouse_sensitivity * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
