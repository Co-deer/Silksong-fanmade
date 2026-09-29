using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    
    public GameObject enemy;
    
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemys), 5f, 5f);
    }

    // Update is called once per frame
    void Awake()
    {
        // Busca automáticamente el Prefab en Assets/Resources/EnemigoPrefab
        enemy = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/enemigos/Evil Beam.prefab");
        
        
    }    
    

    void SpawnEnemys()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
