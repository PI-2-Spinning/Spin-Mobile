using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class History {
    UserData userData;
    private List<Registry> listRegistry = new List<Registry>();

    public History() {
        #if UNITY_EDITOR
            userData = new UserData();
        #else
            userData = GeneralController.controllerInstance.getUserData();
        #endif
        
        convertStringToListRegistry(userData.getHistory());
    }

    public List<Registry> getListRegistry() {
        return listRegistry;
    }

    public void addHistory(Registry registry) {
        listRegistry.Add(registry);
        Debug.Log("Inseriu Registro no Histórico");
    }

    public string convertListRegistryToString() {
        string stringHistory = "";

        foreach (var reg in listRegistry){
            string stringRegistry = (int)reg.getAverageSpeed() + "," + (int)reg.getMaxSpeed() + "," + (int)reg.getTravelledDistance() + "," + (int)reg.getTravelledTime() + ";";
            stringHistory = stringHistory + stringRegistry;
        }

        Debug.Log("Converteu Histórico em String: " + stringHistory);

        return stringHistory;
    }

    public void saveHistoryOnUserData() {
        string stringHistory = convertListRegistryToString();

        userData.setHistory(stringHistory);

        Debug.Log("Salvou o Histórico no User Data: " + userData.getHistory());
    }

    public void convertStringToListRegistry(string cacheHistoryString) {
        if (string.IsNullOrEmpty(cacheHistoryString)) {
            Debug.Log("cache vazio");
            return;
        }

        string[] listaTesteString = cacheHistoryString.Split(';');

        foreach (var registryString in listaTesteString){
            string[] listRegistryValue = registryString.Split(',');

            float averageSpeed = float.Parse(listRegistryValue[0], CultureInfo.InvariantCulture.NumberFormat);
            float maxSpeed = float.Parse(listRegistryValue[1], CultureInfo.InvariantCulture.NumberFormat);
            float travelledDistance = float.Parse(listRegistryValue[2], CultureInfo.InvariantCulture.NumberFormat);
            float travelledTime = float.Parse(listRegistryValue[3], CultureInfo.InvariantCulture.NumberFormat);

            Registry registry = new Registry(averageSpeed, maxSpeed, travelledDistance, travelledTime);
            addHistory(registry);
        } 

        Debug.Log("Converteu a String do User Data em uma Lista de Registros");
    }
}
