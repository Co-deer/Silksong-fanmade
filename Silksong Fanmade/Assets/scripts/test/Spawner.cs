using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnRate = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemys), 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemys()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}
