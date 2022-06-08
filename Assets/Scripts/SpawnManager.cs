using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs;
    private float starDelay = 0.1f;
    
    

    void Start()
    {
        InvokeRepeating("CarSpawn", starDelay, Random.Range(1,3f));
    }

  
    void Update()
    {
    }

    void CarSpawn()
    {
        int carIndex = Random.Range(0, carPrefabs.Length);
        Instantiate(carPrefabs[carIndex], new Vector3(5.79f, 0.014f, -13), carPrefabs[carIndex].transform.rotation);
       
    }
}
