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

        registry.setTravelledTime();
        registry.setAverageSpeed(speed);
        registry.setMaxSpeed(speed);

        float travelledDistance = registry.getTravelledDistance();
        float travelledTime = registry.getTravelledTime();
        
        float averageSpeed = registry.getAverageSpeed();
        float maxSpeed = registry.getMaxSpeed();

        Debug.Log("Distancia Percorrida: " + travelledDistance);
        Debug.Log("Tempo Percorrido: " + travelledTime);
        Debug.Log("Velocidade Média: " + averageSpeed);
        Debug.Log("Velocidade Máxima: " + maxSpeed);

        //checkEndCircuit(travelledDistance);
    }

    public int generateRandomNumber(int lower, int upper) {
        var RndB = new Random();
        var StrB = RndB.Next(lower, upper);
        return StrB;
    }

    /*public void checkEndCircuit(float travelledDistance) {
        if (travelledDistance > 50) {
            History history = new History();

            history.addHistory(registry);
            history.saveHistoryOnUserData();
        }
    }*/

    public override void handle()
    {
        History history = new History();

        history.addHistory(registry);
        history.saveHistoryOnUserData();

        GeneralController.controllerInstance.changeState(new Finishing());
    }
}
