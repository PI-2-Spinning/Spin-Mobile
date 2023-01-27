using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class Manager : MonoBehaviour
{
    int time = 2;
    BluetoothService btService;
    GeneralController context;

    // Start is called before the first frame update
    void Start()
    {  
        XRController.initialSetup();
        context = GeneralController.getGeneralControllerInstance();
        Debug.Log("s");

        btService = context.getBtService();
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

        if (context.getIsConnected())
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

            if(Time.time >= time) {
                System.Random resistenceGenerator = new System.Random();
                float resistence = (float)(resistenceGenerator.NextDouble() * 100);
                btService.WritetoBluetooth(resistence.ToString() + "\n");
                time += 2;
            }
        }
        else
        {
            context.connectBluetooth();
        }
    }

    public void OnDestroy()
    {
        Debug.Log("Parando o VR agora!!!");
        XRController.ExitVR();
    }
}
