using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AddInfoManager : MonoBehaviour
{
    private UserData userData;
    
    [SerializeField]
    public TMP_InputField  nameField, ageField, weightField;
    
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        userData = GeneralController.getGeneralControllerInstance().getUserData();
        //Next();
    }

    public void Validate(string field)
    {
        try
        {
           if(field == "name")
           {
                userData.setName(nameField.text);
           } 
           else if (field == "age") 
           {
                userData.setAge(int.Parse(ageField.text));
           }
           else
           {
                userData.setWeight(float.Parse(weightField.text));
           }
             
        }
        catch (Exception e)
        {
            if(field == "age")
            {
                userData.setAge(0);
            }
            else if(field == "weight")
            {
                userData.setWeight(0);
            }
            Debug.LogException(e);
        }

    }

    public void Next()
    {
        Validate("name");
        Validate("age");
        Validate("weight");

        if (userData.getName() != "" && userData.getWeight() != 0 && userData.getAge() != 0)
        {
            userData.updateUserData();
            // Debug.Log(age.ToString() + " " + weight.ToString() + " " + name);

            SceneManager.LoadScene("SpinMobileMainScene");
            GeneralController.getGeneralControllerInstance().getState().handle();
            //StartCoroutine(XRController.StartXR());
            XRController.EnterVR();
        }
    }
}
