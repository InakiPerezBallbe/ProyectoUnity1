using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class audioManagement : MonoBehaviour
{
    AudioSource audioSource;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = slider.value;
    }

}
