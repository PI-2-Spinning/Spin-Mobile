using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe encarregada de salvar as informações de um circuito
public class Registry
{
    private float averageSpeed;
    private float maxSpeed;
    private float travelledDistance;
    private float travelledTime;
    
    public Registry(){
        maxSpeed = 0;
    }

    public Registry(float averageSpeedHistory, float maxSpeedHistory, float travelledDistanceHistory, float travelledTimeHistory){
        Debug.Log("Criou o Registro vindo do cache" + averageSpeedHistory + ", " + maxSpeedHistory + ", " + travelledDistanceHistory + ", " + travelledTimeHistory);

        averageSpeed = averageSpeedHistory;
        maxSpeed = maxSpeedHistory;
        travelledDistance = travelledDistanceHistory;
        travelledTime = travelledTimeHistory;
    }

    public float getTravelledDistance(){
        return travelledDistance;
    }

    public void setTravelledDistance(float distance){
        travelledDistance = distance;
    }

    public float getTravelledTime(){
        return travelledTime;
    }

    public void setTravelledTime(float time){
       travelledTime = time;
    }

    public float getAverageSpeed(){
        return averageSpeed;
    }

    public void setAverageSpeed(){
        averageSpeed = calculateVelocity(travelledDistance, travelledTime);
    }

    public float getMaxSpeed(){
        return maxSpeed;
    }

    public void setMaxSpeed(){
        if (averageSpeed > maxSpeed) {
            maxSpeed = averageSpeed;
        }
    }

    public float calculateVelocity(float distance, float time) {
        return distance / time;
    }
}
