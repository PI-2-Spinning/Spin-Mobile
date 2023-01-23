using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class Manager : MonoBehaviour
{
    string deviceName = "ESP32";
    bool isConnected = false;

    // Start is called before the first frame update
    void Start()
    {  
        XRController.initialSetup();
        GeneralController context = GeneralController.getGeneralControllerInstance();
        Debug.Log("s");

        BluetoothService.CreateBluetoothObject();
    }

    // Update is called once per frame
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
        else
        {
            /*if(GeneralController.getGeneralControllerInstance().getState().stateName == "idle"){
                XRController.EnterVR();
                Debug.Log("Entered");
            }*/
        }

        if (isConnected)
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
            isConnected = BluetoothService.StartBluetoothConnection(deviceName);
        }
    }
}
