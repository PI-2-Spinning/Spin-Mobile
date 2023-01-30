using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class Manager : MonoBehaviour
{
    void Start()
    {       
        Debug.Log("context done!");
    }

    public void Update()
    {   
        Debug.Log(GeneralController.controllerInstance.getState().stateName);

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
                string dataIn = BluetoothService.ReadFromBluetooth();
                if (dataIn.Length > 0)
                {
                    Debug.Log(dataIn);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        else
        {
            Debug.Log("Connecting...");
            GeneralController.controllerInstance.doConnect();
        }
    }

    public void OnDestroy()
    {
        if(GeneralController.controllerInstance.getState().stateName != "Simulating"){
            Debug.Log("Manager Parando o VR agora!!!");
            XRController.ExitVR();
        }
    }
}
