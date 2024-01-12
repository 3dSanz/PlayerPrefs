using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManagerEJ : MonoBehaviour
{
    [SerializeField] private Text checkPointText;
    [SerializeField] public string checkPoint;
    [SerializeField] public Vector3 playerPosition;
    Player player;
    
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        LoadData();
    }

    void Update()
    {
        playerPosition = player.transform.position;
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("checkpoint", checkPoint);   
        PlayerPrefs.SetFloat("position x", player.transform.position.x);
        PlayerPrefs.SetFloat("position y", player.transform.position.y);
        PlayerPrefs.SetFloat("position z", player.transform.position.z);

        LoadData();
    }

    void LoadData()
    {
        checkPointText.text = "CheckPoint: " + PlayerPrefs.GetString("checkpoint", checkPoint);
        playerPosition = new Vector3(PlayerPrefs.GetFloat("position x", 720f), PlayerPrefs.GetFloat("position y", 116.56f), PlayerPrefs.GetFloat("position z", -52.09312f));
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("checkpoint");
        PlayerPrefs.DeleteKey("position x");
        PlayerPrefs.DeleteKey("position y");
        PlayerPrefs.DeleteKey("position z");

        //PlayerPrefs.DeleteAll(); Se carga todos los PlayerPrefs de TODOS los scripts
        LoadData();
    }
}
