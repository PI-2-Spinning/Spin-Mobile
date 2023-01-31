using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting : State
{
   
    public Starting(UserData userData){
        stateName = "starting";
        
    }
    
    public override void handle()
    {   
        if(GeneralController.controllerInstance.getUserData().getInfos())
            GeneralController.controllerInstance.changeState(new Idle());
    }
}
