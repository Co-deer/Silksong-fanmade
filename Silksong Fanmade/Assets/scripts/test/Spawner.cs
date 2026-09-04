using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Spawner : MonoBehaviour
{
    public GameObject[] objects;



    private float tiempo;

    
        

    

    public void SpawnRandom()
    {
        Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)]);
    }


    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandom), 5f, 5f);
    }
}
