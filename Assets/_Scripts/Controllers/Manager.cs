using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;
using UnityEngine.Android;

public class Manager : MonoBehaviour
{
    string[] BT_PERMISSIONS = {"android.permission.BLUETOOTH_CONNECT", "android.permission.BLUETOOTH_SCAN"};
    string deviceName = "ESP32";
    bool isConnected = false;
    int time = 2;

    // Start is called before the first frame update
    void Start()
    {  
        Permission.RequestUserPermissions(BT_PERMISSIONS);
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

            if(Time.time >= time) {
                System.Random resistenceGenerator = new System.Random();
                float resistence = (float)(resistenceGenerator.NextDouble() * 100);
                BluetoothService.WritetoBluetooth(resistence.ToString() + "\n");
                time += 2;
            }
        }
        else
        {
            isConnected = BluetoothService.StartBluetoothConnection(deviceName);
        }
    }

    public void OnDestroy()
    {
        Debug.Log("Parando o VR agora!!!");
        BluetoothService.StopBluetoothConnection();
        XRController.ExitVR();
    }
}
