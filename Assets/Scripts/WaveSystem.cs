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
    public Animator animator;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int SpawnerIndex;
    public int SpanwerHolder;

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
                UpdateSpawner();
                Enemies = Instantiate(hazard, SpawnPoints[SpawnerIndex].transform.position, SpawnPoints[SpawnerIndex].transform.rotation);
                GetComp();
                SetSpeed();

                agent.SetDestination(new Vector3(0, 0, 0));
                yield return new WaitForSeconds(spawnWait);
            }
            // End of the WAVE
            WaveCompleted();
            yield return new WaitForSeconds(waveWait);
        }
    }
    
    void GetComp()
    {
        agent = Enemies.GetComponent<NavMeshAgent>();
        animator = Enemies.GetComponent<Animator>();
    }

    void SetSpeed()
    {
        agent.speed = Mathf.Clamp(EnemySpeedCurve.Evaluate(Wave), 0, 25);
        animator.SetFloat("Speed", 0.5f);
    }

    void UpdateSpawner()
    {
        SpawnerIndex = Random.Range(0, SpanwerHolder);

        Debug.Log("Got Spawned at " + SpawnerIndex);
    }

    void WaveCompleted()
    {
        Wave++;
        hazardCount += Random.Range(0, 2);

        spawnWait = Mathf.Clamp(SpawnWaitCurve.Evaluate(Wave), 0, 25);
        waveWait = Mathf.Clamp(WaveWaitcurve.Evaluate(Wave), 0, 25);
    }

    void Update()
    {
        
    }

}
