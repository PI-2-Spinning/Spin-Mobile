using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralController 
{
    private static GeneralController controllerInstance;
    private UserData userData;
    private State state;
    public bool isConnected;

    private GeneralController(){
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
}
