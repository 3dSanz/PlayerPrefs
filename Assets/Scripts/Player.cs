using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    private CharacterController characterController;
    private SaveManagerEJ save;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        save = GameObject.Find("SaveManager").GetComponent<SaveManagerEJ>();
        PlayerPosition();
    }

    void Update()
    {
        MoveSideways();
    }

    void PlayerPosition()
    {
        transform.position = new Vector3 (save.playerPosition.x, save.playerPosition.y, save.playerPosition.z);
    }

    void MoveSideways()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f);
        Vector3 moveVector = moveDirection * speed * Time.deltaTime;
        characterController.Move(moveVector);
    }

    void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.tag == "CP1")
            {
                save.checkPoint = "1";
                Debug.Log("Save!");
                save.SaveData();
            }

            if(other.gameObject.tag == "CP2")
            {
                save.checkPoint = "2";
                Debug.Log("Save!");
                save.SaveData();
            }

            if(other.gameObject.tag == "CP3")
            {
                save.checkPoint = "3";
                Debug.Log("Save!");
                save.SaveData();
            }
    }
}
