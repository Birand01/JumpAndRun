using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> lisfOfObjects = new List<GameObject>();
    private int totalNumberOfObject;
    private Vector3 spawnPos=new Vector3(0, -2.712801f, -4.554195f);
    [Header("Spawn Attributes")]
    [SerializeField] private float repeatRate, spawnDelay;
    private void Awake()
    {
        totalNumberOfObject=lisfOfObjects.Count;
    }
    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle),spawnDelay,repeatRate);
    }
    private void SpawnObstacle()
    {
            Instantiate(lisfOfObjects[Random.Range(0,totalNumberOfObject)], spawnPos, lisfOfObjects[Random.Range(0, totalNumberOfObject)].transform.rotation);
    }
}
