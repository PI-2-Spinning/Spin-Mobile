using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class Manager : MonoBehaviour
{
    int time = -1;
    int resistence = 5;
    BluetoothService btService;

    void Start()
    {       
        btService = GeneralController.controllerInstance.getBtService();
        Debug.Log("context done!");
    }

    public void Update()
    {   
        //Debug.Log(GeneralController.controllerInstance.getState().stateName);

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
                    Debug.Log(dataIn);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            if ((time == -1 || Time.time >= time) && GeneralController.controllerInstance.getState().stateName != "Simulating") {
                btService.WritetoBluetooth(resistence.ToString() + "\n");
                if (resistence < 100)
                {
                    resistence += 5;
                }
                time = (int)Time.time + 10;
            }
        }
        else
        {
            //Debug.Log("Connecting...");
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
