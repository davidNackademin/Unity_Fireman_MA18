using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))] // kräv att det finns en GameManager på samma object
public class JumperSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject jumperPrefab;

	GameManager gameManager;
    float lastSpawnTime;

    [Range(0, 5)]
    public float spawnDelay = 3.0f;
    [Range(0, 2)]
    public float deltaRandomSpawn = 0.5f;

	public float spawnDelayDecreaseSpeed = 0.02f;

	private float randomSpawnDelay;
    private bool stop = false;

    private List<GameObject> jumpers = new List<GameObject>();

    private void Start()
    {
        if (jumperPrefab == null)
            return;

		gameManager = GetComponent<GameManager>();

        randomSpawnDelay = spawnDelay;
        SpawnJumper();
    }

    private void Update()
    {
        if (!stop && Time.time > lastSpawnTime + randomSpawnDelay)
        {
            SpawnJumper();
        }
    }

    private void SpawnJumper()
    {
        lastSpawnTime = Time.time;
		float delay = Mathf.Clamp( spawnDelay - ( spawnDelayDecreaseSpeed  * gameManager.Points()), deltaRandomSpawn , spawnDelay) ;
        randomSpawnDelay = Random.Range(delay - deltaRandomSpawn, delay + deltaRandomSpawn);
        GameObject jumper = Instantiate(jumperPrefab);

		jumpers.Add(jumper);

        JumperController jumperController = jumper.GetComponentInChildren<JumperController>();

		jumperController.jumperSpawner = this;
	}

    public void DestroyJumper(GameObject jumper)
	{
		// ta bort jumper ur listan
		jumpers.Remove(jumper);

		// destroy jumper
		Destroy(jumper);
	}


    public void Stop()
	{
		stop = true;
        // gå igenom listan destroy all

        for(int i = jumpers.Count - 1; i >= 0; i-- )
		{
			DestroyJumper(jumpers[i]);
		} 
	}
}
