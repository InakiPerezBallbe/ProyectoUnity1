using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightsTrigger : MonoBehaviour
{
    public Light red;
    public Light green;
    public Light blue;
    public Light yellow;
    public static LightsTrigger lightsTrigger;
    // Start is called before the first frame update
    void Start()
    {
        lightsTrigger = this;
    }

    private void Update()
    {
        if (red.enabled && blue.enabled && green.enabled && yellow.enabled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
