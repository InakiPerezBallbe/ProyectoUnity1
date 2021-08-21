using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickCoins : MonoBehaviour
{
    public float score = 0;

    public static PickCoins pickCoins;
    public GameObject scoreText;
    public AudioClip coin;

    // Start is called before the first frame update
    void Start()
    {
        pickCoins = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Coins: " + score;
        if (score >= 100)
        {
            LightsTrigger.lightsTrigger.green.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag =="Collectables")
        {
            if (other.transform.name == "BlueCoin(Clone)")
            {
                score += 1;
            }
            if (other.transform.name == "GreenCoin(Clone)")
            {
                score += 2;
            }
            if (other.transform.name == "RedCoin(Clone)")
            {
                score += 5;
            }
            AudioSource.PlayClipAtPoint(coin, transform.position, 0.1f);
            CoinSpawner.coinSpawner.counter--;
            Destroy(other.gameObject);
        }
    }
}
