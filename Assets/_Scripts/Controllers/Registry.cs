using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe encarregada de salvar as informações de um circuito
public class Registry
{
    private float totalSpeed;
    
    private float averageSpeed;
    private float maxSpeed;
    private float travelledDistance;
    private float travelledTime;
    
    public Registry(){
        totalSpeed = 0;
        maxSpeed = 0;
        averageSpeed = 0;
    }

    public Registry(float averageSpeedHistory, float maxSpeedHistory, float travelledDistanceHistory, float travelledTimeHistory){
        Debug.Log("Criou o Registro vindo do cache" + averageSpeedHistory + ", " + maxSpeedHistory + ", " + travelledDistanceHistory + ", " + travelledTimeHistory);

        averageSpeed = averageSpeedHistory;
        maxSpeed = maxSpeedHistory;
        travelledDistance = travelledDistanceHistory;
        travelledTime = travelledTimeHistory;
    }

    public float getTravelledDistance(){
        float convert = averageSpeed / 3.6f;
        return convert * travelledTime;
    }

    public void setTravelledDistance(float distance){
        travelledDistance = distance;
    }

    public float getTravelledTime(){
        return travelledTime;
    }

    public void setTravelledTime(){
       travelledTime += 1;
    }

    public float getAverageSpeed(){
        return averageSpeed;
    }

    public void setAverageSpeed(float momentSpeed){
        totalSpeed += momentSpeed;

        averageSpeed = calculateVelocity(totalSpeed, travelledTime);
    }

    public float getMaxSpeed(){
        return maxSpeed;
    }

    public void setMaxSpeed(float speed){
        if (speed > maxSpeed) {
            maxSpeed = speed;
        }
    }

    public float calculateVelocity(float speed, float time) {
        return speed / time;
    }
}
