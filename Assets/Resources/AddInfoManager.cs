using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddInfoManager : MonoBehaviour
{
    [SerializeField]
    private string scene; 


    public void Confirm()
    {
        SceneManager.LoadScene(scene);
    }
}
