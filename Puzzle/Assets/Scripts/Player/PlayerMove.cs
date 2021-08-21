using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    public float jumpSpeed = 10;
    public float gravity = 35;
    bool duck = true;

    Vector3 moveDirection;
    public CharacterController cc;
    public static PlayerMove playerMove;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        playerMove = this;
    }
    void Update()
    {
        if (cc.isGrounded )
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetKey(KeyCode.LeftShift))
                moveDirection *= 2*speed;
            else
                moveDirection *= speed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        else 
            moveDirection.y -= gravity * Time.deltaTime;

        cc.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (duck)
            {
                //Debug.Log("Agachado");
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                cc.height -= 1f;
                cc.center = new Vector3(cc.center.x, cc.center.y + 0.5f, cc.center.z);
                duck = false;
            }
        }
        else
        {
            if (!duck)
            {
                //Debug.Log("De pie");
                transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
                cc.height += 1f;
                cc.center = new Vector3(cc.center.x, cc.center.y - 0.5f, cc.center.z);
                duck = true;
            }
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, PickCoins.pickCoins);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        speed = data.speed;
        jumpSpeed = data.jumpSpeed;
        gravity = data.gravity;
        transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }
}
