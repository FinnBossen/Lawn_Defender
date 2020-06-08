using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    CameraOrbit cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CameraOrbit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad4))
        {
            cam.MoveHorizontal(true);
        } else if (Input.GetKey(KeyCode.Keypad6))
        {
            cam.MoveHorizontal(false);
        } else if (Input.GetKey(KeyCode.Keypad8))
        {
            cam.MoveVertical(true);
        } else if (Input.GetKey(KeyCode.Keypad2))
        {
            cam.MoveVertical(false);
        }
    }
}
