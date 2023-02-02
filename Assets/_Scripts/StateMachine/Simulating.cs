using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class Simulating : State
{
    private Registry registry;

    public Simulating(){
        stateName = "Simulating";
        Debug.Log("Simulating...");

        registry = new Registry();
    }

    public void updateRegistry(float speed) {
        Debug.Log("updating registry");

        registry.setAverageSpeed(speed);
        registry.setTravelledTime();

        float travelledDistance = registry.getTravelledDistance();
        float travelledTime = registry.getTravelledTime();
        float averageSpeed = registry.getAverageSpeed();

        Debug.Log("Distancia Percorrida: " + travelledDistance);
        Debug.Log("Tempo Percorrido: " + travelledTime);
        Debug.Log("Velocidade Momentanea: " + speed);
        Debug.Log("Velocidade Média" + averageSpeed);
    }

    public int generateRandomNumber(int lower, int upper) {
        var RndB = new Random();
        var StrB = RndB.Next(lower, upper);
        return StrB;
    }

    public override void handle()
    {
        GeneralController context = GeneralController.controllerInstance;
    }
}
