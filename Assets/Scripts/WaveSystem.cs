using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveSystem : MonoBehaviour
{
    public int Wave;
    public AnimationCurve SpawnWaitCurve;
    public AnimationCurve WaveWaitcurve;
    public AnimationCurve EnemySpeedCurve;
    public GameObject hazard;
    public GameObject[] SpawnPoints;
    private GameObject Enemies;
    private NavMeshAgent agent;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

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
            WaveCompleted();
            yield return new WaitForSeconds(waveWait);
        }
    }

    void WaveCompleted()
    {
        spawnWait = Mathf.Clamp(SpawnWaitCurve.Evaluate(Time.time), 0, 25);
        waveWait = Mathf.Clamp(WaveWaitcurve.Evaluate(Time.time), 0, 25);
        agent.speed = Mathf.Clamp(EnemySpeedCurve.Evaluate(Time.time), 0, 25);

        Wave++;
        hazardCount += Random.Range(0, 2);
    }

    void Update()
    {
        
    }

}
