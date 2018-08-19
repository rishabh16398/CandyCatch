using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour {
    [SerializeField]
    float maxX;
    [SerializeField]
    float Spawninterval;
    public static CandySpawner instance;
 
    public GameObject[] Candies;
    private void Awake()
    {
       if(instance==null)
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        StartSpawningCandies();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SpawnCandy()
    {
        int rand = Random.Range(0, Candies.Length);
        float randomX = Random.Range(-maxX, maxX);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(Candies[rand], randomPos, transform.rotation);
    }
    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);
        while(true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(Spawninterval);

        }
    }
    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }
    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
