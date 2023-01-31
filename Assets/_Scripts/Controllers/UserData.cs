using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UserData 
{
    private string playerName;
    private string playerSex;
    private int playerHeight;
    private float playerWeight;
    private int playerAge;
    private float bicycleRim;
    private float category;
    private int points;
    private string history;

    public UserData(){
        playerName = PlayerPrefs.GetString("name", "");
        playerSex = PlayerPrefs.GetString("sex", "");
        playerHeight = PlayerPrefs.GetInt("height", 0);
        playerWeight = PlayerPrefs.GetFloat("weight", 0f);
        playerAge = PlayerPrefs.GetInt("age", 0);
        bicycleRim = PlayerPrefs.GetFloat("rim", 0f);
        category = PlayerPrefs.GetFloat("category", 0f);
        points = PlayerPrefs.GetInt("points", 0);
        history = PlayerPrefs.GetString("history", "");

        History auxhistory = new History();
        auxhistory.convertStringToListRegistry();
    }

    public void updateUserData(){
        PlayerPrefs.SetString("name", playerName);
        PlayerPrefs.SetString("sex", playerSex);
        PlayerPrefs.SetInt("height", playerHeight);
        PlayerPrefs.SetFloat("weight",playerWeight);
        PlayerPrefs.SetInt("age", playerAge);
        PlayerPrefs.SetFloat("rim", bicycleRim);
        PlayerPrefs.SetFloat("category", category);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetString("history", history);
    }

    public void getInfos(){
        XRController.ExitVR();
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("InsertInfo");
    }

    public string getName(){
        return playerName;
    }

    public void setName(string name){
        playerName = name;
    }

    public string getSex(){
        return playerSex;
    }

    public void setSex(string sex){
        playerSex = sex;
    }
    public int getHeight(){
        return playerHeight;
    }

    public void setHeight(int height){
        playerHeight = height;
    }

    public float getWeight(){
        return playerWeight;
    }

    public void setWeight(float weight){
        playerWeight = weight;
    }

    public int getAge(){
        return playerAge;
    }

    public void setAge(int age){
        playerAge = age;
    }

    public float getRim(){
        return bicycleRim;
    }

    public void setRim(float rim){
        bicycleRim = rim;
    }

    public float getCategory(){
        return category;
    }

    public void setCategory(float _category){
        category = _category;
    }

    public int getPoints(){
        return points;
    }

    public void setPoints(int _points){
        points = _points;
    }

    public string getHistory(){
        return history;
    }

    public void setHistory(string historyString){
        history = historyString;
    }
}
