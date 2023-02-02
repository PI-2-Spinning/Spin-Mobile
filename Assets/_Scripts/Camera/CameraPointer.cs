using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject;
    private float speedCam = 120f;
    public Transform playerBody;
    public float xRotation = 0f;
    //private Camera camera;    

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_EDITOR
        Cursor.lockState = CursorLockMode.Locked;
        //camera = Camera.main;
        #endif
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        #if UNITY_EDITOR
        float mouseX = speedCam * Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = speedCam * Input.GetAxis("Mouse Y") * Time.deltaTime;

        xRotation -= mouseY;
        //yaw = Mathf.Clamp(yaw, -90f, 90f);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        #else

        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
        #endif
    }
}
