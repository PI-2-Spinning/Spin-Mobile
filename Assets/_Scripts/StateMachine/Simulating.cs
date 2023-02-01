using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class Simulating : State
{
    private Registry registry;

    private float distance;
    private float time;
    private float velocity;

    public Simulating(){
        stateName = "simulating";
        Debug.Log("Simulating...");

        distance = 0;
        time = 0;

        registry = new Registry();
    }

    public void updateRegistry() {
        Debug.Log("updating registry");

        distance += generateRandomNumber(2, 5);
        time += 1;

        registry.setTravelledDistance(distance);
        registry.setTravelledTime(time);
        registry.setAverageSpeed();

        float travelledDistance = registry.getTravelledDistance();
        float travelledTime = registry.getTravelledTime();
        float velocity = registry.getAverageSpeed();

        Debug.Log("Distancia Percorrida: " + travelledDistance);
        Debug.Log("Tempo Percorrido: " + travelledTime);
        Debug.Log("Velocidade: " + velocity);
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
