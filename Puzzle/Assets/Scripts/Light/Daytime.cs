using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daytime : MonoBehaviour
{
    public float daySpeed = 1;
    float xRotation;
    // Update is called once per frame
    void Update()
    {
        xRotation += daySpeed*Time.deltaTime;
        transform.rotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
