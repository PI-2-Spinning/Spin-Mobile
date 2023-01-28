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
    public TMP_InputField  nameField, ageField, weightField, heightField, sexField;
    
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
           else if(field == "weight")
           {
                userData.setWeight(float.Parse(weightField.text));
           }
           else if(field == "height")
            {
                userData.setHeight(int.Parse(heightField.text));
            }
           else if(field == "sex")
            {
                userData.setSex(sexField.text);
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
            else if (field == "height")
            {
                userData.setHeight(0);
            }
            else if (field == "sex")
            {
                userData.setSex("");
            }
            Debug.LogException(e);
        }

    }

    public void Next()
    {
        Validate("name");
        Validate("age");
        Validate("weight");
        Validate("height");
        Validate("sex");

        if (userData.getName() != "" && userData.getWeight() != 0 && userData.getAge() != 0 && userData.getHeight() != 0 && userData.getSex() != "")
        {
            userData.updateUserData();
            Debug.Log(userData.getName() + " " + userData.getWeight().ToString() + " " + userData.getAge().ToString());

            SceneManager.LoadScene("SpinMobileMainScene");            
        }
    }

    public void OnDestroy()
    {
        GeneralController.getGeneralControllerInstance().getState().handle();
        Debug.Log("Form Ativando o VR agora!!!");
        XRController.EnterVR();
    }
}
