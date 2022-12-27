using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AddInfoManager : MonoBehaviour
{
    [SerializeField]
    private string scene;
    private string name; 
    private int age;
    private float weight;

    public TMP_InputField  nameField, ageField, weightField;
    
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        age = PlayerPrefs.GetInt("age", 0);
        weight = PlayerPrefs.GetFloat("weight", 0);
        name = PlayerPrefs.GetString("name", "");

        Debug.Log(name);

        Next();
    }

    private void SavePlayerData()
    {
        PlayerPrefs.SetInt("age", age);
        PlayerPrefs.SetFloat("weight", weight);
        PlayerPrefs.SetString("name", name);
    }

    public void Validate(string field)
    {
        try
        {
           if(field == "name")
           {
                name = nameField.text; 
           } 
           else if (field == "age") 
           {
                age = int.Parse(ageField.text);
           }
           else
           {
                weight = float.Parse(weightField.text);
           }
             
        }
        catch (Exception e)
        {
            if(field == "age")
            {
                age = 0;
            }
            else if(field == "weight")
            {
                weight = 0;
            }
            Debug.LogException(e);
        }

    }

    public void Next()
    {

        if (name.Length != 0 && weight != 0 && age != 0)
        {
            SavePlayerData();
            Debug.Log(age.ToString() + " " + weight.ToString() + " " + name);

            SceneManager.LoadScene(scene);
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
