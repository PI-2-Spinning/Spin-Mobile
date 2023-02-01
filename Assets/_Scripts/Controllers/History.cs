using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class History {
    private List<Registry> listRegistry = new List<Registry>();

    public History() {

    }

    public List<Registry> getListRegistry() {
        return listRegistry;
    }

    public void addHistory(Registry registry) {
        listRegistry.Add(registry);
    }

    public void convertStringToListRegistry() {
        string testeString = "10,20,30,40;50,60,70,80;90,91,92,93";

        string[] listaTesteString = testeString.Split(';');

        foreach (var registryString in listaTesteString){
            string[] listRegistryValue = registryString.Split(',');

            float averageSpeed = float.Parse(listRegistryValue[0], CultureInfo.InvariantCulture.NumberFormat);
            float maxSpeed = float.Parse(listRegistryValue[1], CultureInfo.InvariantCulture.NumberFormat);
            float travelledDistance = float.Parse(listRegistryValue[2], CultureInfo.InvariantCulture.NumberFormat);
            float travelledTime = float.Parse(listRegistryValue[3], CultureInfo.InvariantCulture.NumberFormat);

            Registry registry = new Registry(averageSpeed, maxSpeed, travelledDistance, travelledTime);
            addHistory(registry);
        } 
    }
}
