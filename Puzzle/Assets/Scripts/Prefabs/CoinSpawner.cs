using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    float timer = 0;
    public float counter = 0;
    enum Coins { Blue = 0, Green = 1, Red = 2 };

    public GameObject blueCoin;
    public GameObject greenCoin;
    public GameObject redCoin;
    public static CoinSpawner coinSpawner;
    GameObject go;
    Vector3 pos;
    Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {
        coinSpawner = this;
        pos = transform.position;
        rot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer>=1f && counter < 15)
        {
            counter++;
            timer = 0;
            Coins c = (Coins)Random.Range(0, 3);
            Vector3 position = new Vector3(Random.Range(pos.x - 2, pos.x + 3), 1, Random.Range(pos.z - 4, pos.z + 6));
            Quaternion rotation = Quaternion.Euler(0, rot.y, 0);
            if (c.Equals(Coins.Blue))
            {
                go = Instantiate(blueCoin, position, rotation);
            }
            else if (c.Equals(Coins.Green))
            {
                go = Instantiate(greenCoin, position, rotation);
            }
            else if(c.Equals(Coins.Red))
            {
                go = Instantiate(redCoin, position, rotation);
            }
            go.transform.parent = transform;
        }
    }
}
