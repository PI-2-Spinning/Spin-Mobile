using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishing : State
{
    // Start is called before the first frame update
    public Finishing(){
        stateName = "finishing";
    }
    
    public override void handle()
    {
        GeneralController.controllerInstance.changeState(new Idle());
    }
}
