using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Interactive" && collision.transform.parent != null)
        {
            collision.transform.parent.GetComponent<Camera>().fieldOfView = 60;
            collision.transform.parent.DetachChildren();
            collision.rigidbody.constraints = RigidbodyConstraints.None;
        }   
    }
}
