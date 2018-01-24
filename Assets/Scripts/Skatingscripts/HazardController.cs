using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour {
    public GameObject hazardTreeLeft,hazardTreeRight, hazardIce;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private List<GameObject> randomHazardList;

	// Use this for initialization
	void Start () {
        randomHazardList = new List<GameObject>();

        randomHazardList.Add(hazardIce);

        randomHazardList.Add(hazardTreeLeft);
        randomHazardList.Add(hazardTreeRight);

        StartCoroutine(SpawnWaves());

    }

    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition=new Vector3();
                Quaternion spawnRotation=new Quaternion();
                int num = Random.Range(0, 3);
                if (num==0)
                {
                    spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    spawnRotation = Quaternion.identity;
                }
                else if (num==1)
                {
                    spawnPosition = new Vector3(spawnValues.x+1, 0.0f, spawnValues.z);
                    spawnRotation = Quaternion.Euler(new Vector3(0, 0, 35));
                }
                else if (num == 2)
                {
                    spawnPosition = new Vector3(-spawnValues.x-1, 0.0f, spawnValues.z);
                    spawnRotation = Quaternion.Euler(new Vector3(0, 25, -35));
                }

                Instantiate(randomHazardList[num], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    
}
