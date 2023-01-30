using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class GeneralController : MonoBehaviour
{
    public static GeneralController controllerInstance { get; private set; }
    private UserData userData;
    private State state;
    string deviceName = "ESP32";
    public bool isConnected = false;

    private GeneralController(){
       /*XRController.initialSetup();
        userData = new UserData();
        state = new Starting(userData);
        BluetoothService.CreateBluetoothObject();*/
    }

    private void Awake()
    {
        if (controllerInstance != null && controllerInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            XRController.initialSetup();
            controllerInstance = this;
            controllerInstance.userData = new UserData();
            controllerInstance.state = new Starting(userData);
            controllerInstance.state.handle();
        }
        
        DontDestroyOnLoad(gameObject);
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
        Debug.Log("changed !!!!!!!!! "+state.stateName);
    }

    public State GetState(){
        return state;
    }
}