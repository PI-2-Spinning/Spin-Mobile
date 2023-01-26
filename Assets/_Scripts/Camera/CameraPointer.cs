using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{

    private float speedCam = 120f;
    public Transform playerBody;
    public float xRotation = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_EDITOR
        Cursor.lockState = CursorLockMode.Locked;
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        float mouseX = speedCam * Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = speedCam * Input.GetAxis("Mouse Y") * Time.deltaTime;

        xRotation -= mouseY;
        //yaw = Mathf.Clamp(yaw, -90f, 90f);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        #endif
    }
}
