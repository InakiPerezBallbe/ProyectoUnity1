using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float score;
    public float speed;
    public float jumpSpeed;
    public float gravity;
    public float[] position;

    public PlayerData(PlayerMove player, PickCoins pickCoins)
    {
        score = pickCoins.score;
        speed = player.speed;
        jumpSpeed = player.jumpSpeed;
        gravity = player.gravity;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
