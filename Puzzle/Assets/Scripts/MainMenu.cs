using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        PlayerMove.playerMove.speed = data.speed;
        PlayerMove.playerMove.jumpSpeed = data.jumpSpeed;
        PlayerMove.playerMove.gravity = data.gravity;
        PlayerMove.playerMove.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }
}
