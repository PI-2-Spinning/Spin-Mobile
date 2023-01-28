using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class GeneralController : MonoBehaviour
{
    private static GeneralController controllerInstance;
    private UserData userData;
    private State state;
    string deviceName = "ESP32";
    public bool isConnected = false;

    private GeneralController(){
        XRController.initialSetup();
        userData = new UserData();
        state = new Starting(userData);
        BluetoothService.CreateBluetoothObject();
        DontDestroyOnLoad(this);
    }

    public static GeneralController getGeneralControllerInstance(){
        if (controllerInstance == null){
            controllerInstance = new GeneralController();             
        }
        
        return controllerInstance;
    }

    public void doConnect(){
        isConnected = BluetoothService.StartBluetoothConnection(deviceName);
    }

    public State getState(){
        return state;
    }

    public UserData getUserData(){
        return userData;
    }

    public void changeState(State newState){
        state = newState;
    }

    public State GetState(){
        return state;
    }
}
