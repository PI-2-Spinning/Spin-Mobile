using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3D : MonoBehaviour
{
    int currentFlowPosition = 0;

    public int CurrentFlowPosition
    {
        get { return currentFlowPosition; }
        set { currentFlowPosition = value; }
    }
    void Start()
    {
        currentFlowPosition = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
