using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {       
        GeneralController context = GeneralController.getGeneralControllerInstance();
        Debug.Log("context done!");
    }

     public void Update()
    {
        if (XRController._isVrModeEnabled())
        {
            if (Api.IsCloseButtonPressed)
            {
                XRController.ExitVR();
                Application.Quit();
            }

            Api.UpdateScreenParams();
        }
        
        if (GeneralController.getGeneralControllerInstance().isConnected)
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
            GeneralController.getGeneralControllerInstance().doConnect();
        }
    }

    public void OnDestroy()
    {
        if(GeneralController.getGeneralControllerInstance().getState().stateName != "Simulating"){
            Debug.Log("Manager Parando o VR agora!!!");
            XRController.ExitVR();
        }
    }
}
