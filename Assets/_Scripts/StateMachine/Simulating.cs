using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulating : State
{
    // Start is called before the first frame update
   public Simulating(){
        stateName = "Simulating";
        Debug.Log("Simulating...");
    }

    public override void handle(){
        
    }
}
