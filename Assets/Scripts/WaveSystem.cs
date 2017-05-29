using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveSystem : MonoBehaviour
{
    public int Wave;
    public GameObject hazard;
    public GameObject[] SpawnPoints;
    public GameObject Enemies;
    private NavMeshAgent agent;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int holder = 8;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                int randomWayNumber = Random.Range(0, SpawnPoints.Length);
                Debug.Log("Got Spawned at " + randomWayNumber);
                Enemies = Instantiate(hazard, SpawnPoints[randomWayNumber].transform.position, SpawnPoints[randomWayNumber].transform.rotation);
                agent = Enemies.GetComponent<NavMeshAgent>();
                agent.SetDestination(new Vector3(0, 0, 0));
                yield return new WaitForSeconds(spawnWait);
            }
            // End of the WAVE
            Wave++;
            hazardCount += 2;
            yield return new WaitForSeconds(waveWait);
        }
    }

    void Update()
    {
        if(Wave == 1)
        {
            
        }
    }

}
