using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject BronzeCoin, GoldCoin, SilverCoin;
    public Vector3 spawnValues;
    public int coinCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private GameObject[] randomCoin;
    private List<GameObject> randomCoinList;

    // Use this for initialization
    void Start()
    {

        randomCoinList = new List<GameObject>();

        randomCoinList.Add(BronzeCoin);
        randomCoinList.Add(GoldCoin);
        randomCoinList.Add(SilverCoin);

        StartCoroutine(SpawnWaves());
    }
   
    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < coinCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(randomCoinList[Random.Range(0,3)], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
