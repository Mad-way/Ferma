using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlants : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject objToSpawn;
    void Start()
    {
        StartCoroutine(SpawnCD());
    }

    IEnumerator SpawnCD()
    {
    
        yield return new WaitForSeconds(15);
        Instantiate(objToSpawn).transform.position = spawnPoint.transform.position;
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.name == "tractor")
        {
            StartCoroutine(SpawnCD());
        }
    }
}