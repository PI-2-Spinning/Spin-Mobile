using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Idle(){
        stateName = "idle";
        Debug.Log("im idle");
    }

    public override void handle(){
        GeneralController.controllerInstance.changeState(new Simulating());
    }
}
