using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class boss1projectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boss1projectilePrefab;

    private float spawnTimer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnProjectile()
    {
        yield return new WaitForSeconds(spawnTimer);
        GameObject projectile = Instantiate(boss1projectilePrefab, this.transform.position, Quaternion.identity);
        StartCoroutine(SpawnProjectile());
    }
}
