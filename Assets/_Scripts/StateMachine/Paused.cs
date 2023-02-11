using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : State
{
    // Start is called before the first frame update
    public Paused(){
        stateName = "paused";
        
    }
    
    public override void handle()
    {   
        if(GeneralController.controllerInstance.getUserData().getInfos())
            GeneralController.controllerInstance.changeState(new Simulating());
    }
}
