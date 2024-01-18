using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    [Inject] GameEvents gameEvents;
    [SerializeField] private List<GameObject> listOfObstacle = new List<GameObject>();
    private int totalNumberOfObject;
    private Vector3 spawnPos=new Vector3(0, -2.712801f, -4.554195f);
    [Header("Spawn Attributes")]
    [SerializeField] private float repeatRate, spawnDelay;
   
    private void OnEnable()
    {
        totalNumberOfObject=listOfObstacle.Count;
    }
    private void Start()
    {
        StartGameButton.OnSpawnObstacle += SpawnObstacle;

    }
    private void OnDisable()
    {
        StartGameButton.OnSpawnObstacle -= SpawnObstacle;
    }
    private void SpawnObstacle(bool state)
    {
        StartCoroutine(SpawnObstacleCoroutine(state));
    }
    private IEnumerator SpawnObstacleCoroutine(bool state)
    {
        while(state)
        {
            GameObject obstaclePrefab = Instantiate(listOfObstacle[Random.Range(0, totalNumberOfObject)]);
            obstaclePrefab.transform.position = spawnPos;
            obstaclePrefab.transform.rotation = listOfObstacle[Random.Range(0, totalNumberOfObject)].transform.rotation;
            if (gameEvents.gameLost.Value)
            {
                StopCoroutine(SpawnObstacleCoroutine(!state));
                yield break;
            }
            yield return new WaitForSeconds(spawnDelay);

        }

    }

  
}
