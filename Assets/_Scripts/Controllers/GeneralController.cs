using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GeneralController 
{
    private static GeneralController controllerInstance;
    private UserData userData;
    private State state;
    public bool isConnected = false;
    private BluetoothService btService;
    string[] BT_PERMISSIONS = {"android.permission.BLUETOOTH_CONNECT", "android.permission.BLUETOOTH_SCAN"};
    string deviceName = "Spin";

    private GeneralController(){
        btService = new BluetoothService();
        btService.CreateBluetoothObject();

        userData = new UserData();
        state = new Starting(userData);
    }

    public static GeneralController getGeneralControllerInstance(){
        if (controllerInstance == null){
            controllerInstance = new GeneralController();
        }
        
        return controllerInstance;
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

    public BluetoothService getBtService() {
        Permission.RequestUserPermissions(BT_PERMISSIONS);
        return btService;
    }

    public bool getIsConnected() {
        return isConnected;
    }

    public void connectBluetooth() {
        isConnected = btService.StartBluetoothConnection(deviceName);
    }
}
