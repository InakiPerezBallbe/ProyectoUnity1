using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 0.4)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.5f, gameObject.transform.position.z);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.transform.parent.DetachChildren();
        }
    }
}
