using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    BluetoothService btService;

    void Start()
    {       
        btService = GeneralController.controllerInstance.getBtService();
        Debug.Log("context done!");
    }    

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        #else
        
        if (XRController._isVrModeEnabled())
        {
            if (Api.IsCloseButtonPressed)
            {
                XRController.ExitVR();
                Application.Quit();
            }

            Api.UpdateScreenParams();
        }
        
        if (GeneralController.controllerInstance.isConnected)
        {
            try
            {
                string dataIn = btService.ReadFromBluetooth();
                if (dataIn.Length > 0)
                {
                    Debug.Log(dataIn + " " + dataIn.Substring(6));
                    
                    speed = float.Parse(dataIn.Substring(6));
                    speed = (speed < 0) ? 0 : speed;
                    speed = 2f * 3.6f * 3.14f* 0.19f * speed / 60;

                    Debug.Log("km/h: " + speed);

                    transform.Translate(Vector3.forward * speed / 3.6f * Time.deltaTime);
                    
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            /*if ((time == -1 || Time.time >= time) && GeneralController.controllerInstance.getState().stateName != "Simulating") {
                btService.WritetoBluetooth(resistence.ToString() + "\n");
                if (resistence < 100)
                {
                    resistence += 5;
                }
                time = (int)Time.time + 10;
            }*/
        }
        else
        {
            //Debug.Log("Connecting...");
            GeneralController.controllerInstance.doConnect();
        }
        #endif
    }
}
