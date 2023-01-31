using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class Manager : MonoBehaviour
{
    void Start()
    {  
        Debug.Log("Início Game");
        XRController.initialSetup();
        GeneralController context = GeneralController.getGeneralControllerInstance();
        Debug.Log(context.getState().stateName);

        BluetoothService.CreateBluetoothObject();
        Debug.Log("context done!");
    }

    public void Update()
    {
        Debug.Log(GeneralController.controllerInstance.getState().stateName);
        GeneralController context = GeneralController.controllerInstance;
        State state = context.getState();

        if (state.stateName == "simulating") {
            Simulating circuit = (Simulating)state;
            circuit.updateRegistry();
        }

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
