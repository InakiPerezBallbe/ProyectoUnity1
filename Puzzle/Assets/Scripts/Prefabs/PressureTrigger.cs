using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureTrigger : MonoBehaviour
{
    static float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 4)
        {
            LightsTrigger.lightsTrigger.red.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "TestCube")
        {
            transform.parent.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            counter++;
            Debug.Log(counter);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "TestCube")
        {
            transform.parent.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            counter--;
        }
    }
}
