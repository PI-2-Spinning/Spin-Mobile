using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;
using UnityEngine.Android;

public class GeneralController : MonoBehaviour
{
    public static GeneralController controllerInstance { get; private set; }
    private UserData userData;
    private State state;
    public bool isConnected = false;
    private BluetoothService btService;
    string[] BT_PERMISSIONS = {"android.permission.BLUETOOTH_CONNECT", "android.permission.BLUETOOTH_SCAN"};
    string deviceName = "Spin";

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
            btService = new BluetoothService();
            btService.CreateBluetoothObject();
            controllerInstance.state.handle();
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void doConnect(){
        isConnected = btService.StartBluetoothConnection(deviceName);
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

    public BluetoothService getBtService() {
        Permission.RequestUserPermissions(BT_PERMISSIONS);
        return btService;
    }
}
