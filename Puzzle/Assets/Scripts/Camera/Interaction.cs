using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interaction : MonoBehaviour
{
    RaycastHit hit;
    public Dialogue dialogue;
    public GameObject text;
    public static Interaction interaction;

    private void Start()
    {
        interaction = this;
    }
    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        ZoomRotate();
    }

    void CheckInteraction()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 4f))
        {
            
            if (hit.transform.tag == "TestCube")
            {
                text.SetActive(true);
                text.GetComponent<TMPro.TextMeshProUGUI>().text = "Press E to Interact";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    text.SetActive(false);
                    if (transform.childCount == 0)
                    {
                        hit.transform.SetParent(gameObject.transform);
                        hit.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    }
                    else
                    {
                        GetComponent<Camera>().fieldOfView = 60;
                        transform.DetachChildren();
                        hit.rigidbody.constraints = RigidbodyConstraints.None;
                    }
                }
            }
            else if (hit.transform.tag=="Button")
            {
                text.SetActive(true);
                text.GetComponent<TMPro.TextMeshProUGUI>().text = "Press E to Press Button";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    text.SetActive(false);
                    LightsTrigger.lightsTrigger.blue.enabled = true;
                }
            }
            else if (hit.transform.CompareTag("Talk"))
            {
                text.SetActive(true);
                text.GetComponent<TMPro.TextMeshProUGUI>().text = "Press E to Talk to Kevin";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    text.SetActive(false);
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                }

            }
            else
            {
                text.SetActive(false);
            }
        }
        else
        {
            text.SetActive(false);
        }
    }

    void ZoomRotate()
    {
        if (gameObject.transform.childCount == 1)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && GetComponent<Camera>().fieldOfView != 30)
            {
                GetComponent<Camera>().fieldOfView-=2;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f && GetComponent<Camera>().fieldOfView != 60)
            {
                GetComponent<Camera>().fieldOfView+=2;
            }

            if (Input.GetMouseButton(1))
            {
                hit.transform.Rotate(Input.GetAxis("Mouse Y") * 100f * Time.deltaTime, Input.GetAxis("Mouse X") * 100f * Time.deltaTime, 0, Space.World);
            }
        }
    }
}
