using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject otherTeleporter;
    public GameObject player;
    Transform tp;

    private void Start()
    {
        tp = otherTeleporter.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.transform.tag=="tpEnt")
        {
            player.transform.position = new Vector3(tp.position.x, tp.position.y,tp.position.z + tp.forward.z*0.1f);
            PlayerMove.playerMove.speed = 1;
            PlayerMove.playerMove.jumpSpeed = 4;
            player.GetComponent<CharacterController>().stepOffset = 0;
            player.transform.localScale = new Vector3(0.1f, 0.01f, 0.1f);

        }
        if (gameObject.transform.tag=="tpExit")
        {
            player.transform.position = new Vector3(tp.position.x, tp.position.y, tp.position.z + tp.forward.z* 4);
            player.GetComponent<CharacterController>().stepOffset = 0.3f;
            PlayerMove.playerMove.speed = 5;
            PlayerMove.playerMove.jumpSpeed = 10;
            player.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
