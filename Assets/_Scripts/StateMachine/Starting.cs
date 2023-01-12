using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting : State
{
   
    public Starting(UserData userData){
        stateName = "starting";
        if(userData.getAge() == 0 || userData.getName() == "" || userData.getWeight() == 0){
            userData.getInfos();
        }
    }
    
    public override void handle()
    {
        GeneralController context = GeneralController.getGeneralControllerInstance();
        context.changeState(new Idle());
    }
}
