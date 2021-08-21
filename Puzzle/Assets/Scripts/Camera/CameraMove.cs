using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float mouseSensitivity = 100;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(1) || gameObject.transform.childCount == 0)
        {
            xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation = Mathf.Clamp(xRotation, -90f, 90);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            gameObject.transform.parent.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
        }
    }
}
