using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Text userNameText;
    [SerializeField] private Text userScoreText;
    [SerializeField] private Text userPositionText;

    [SerializeField] private string userName;
    [SerializeField] private int userScore;
    [SerializeField] private Vector3 userPosition;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("name", userName);
        PlayerPrefs.SetInt("score", userScore);
        PlayerPrefs.SetFloat("position x", userPosition.x);
        PlayerPrefs.SetFloat("position y", userPosition.y);
        PlayerPrefs.SetFloat("position z", userPosition.z);

        LoadData();
    }

    void LoadData()
    {
        userNameText.text = "User Name: " + PlayerPrefs.GetString("name", "No name");
        userScoreText.text = "User Score: " + PlayerPrefs.GetInt("score", 0).ToString();
        userPositionText.text = "Player Position : (" + PlayerPrefs.GetFloat("position x", 0).ToString() + "," + 
                                PlayerPrefs.GetFloat("position y", 0).ToString() + "," + 
                                PlayerPrefs.GetFloat("position z", 0).ToString() + ")";
        
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("name");
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("position x");
        PlayerPrefs.DeleteKey("position y");
        PlayerPrefs.DeleteKey("position z");

        //PlayerPrefs.DeleteAll(); Se carga todos los PlayerPrefs de TODOS los scripts
        LoadData();
    }
}
