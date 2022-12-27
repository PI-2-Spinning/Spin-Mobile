using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddInfoManager : MonoBehaviour
{
    [SerializeField]
    private string scene, name;
    private float weight;
    
    public Text age;
   
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void Validate(string data)
    {
        try
        {
            Debug.Log(age.ToString());
           // age = int.Parse(data);

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

    }

    public void Confirm()
    {
        SceneManager.LoadScene(scene);
    }
}
