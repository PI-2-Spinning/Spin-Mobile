using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public string stateName;

    public abstract void handle();
}
