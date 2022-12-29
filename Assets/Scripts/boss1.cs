using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1 : MonoBehaviour
{
    [SerializeField] private int damage = 5;

    [SerializeField] private EnemyData data;

    [SerializeField] private GameObject projectileSpawnerPrefab;

    [SerializeField] private GameObject shadowPrefab;

    [SerializeField] private GameObject lightningAnimPrefab;

    [SerializeField] private GameObject lightningPrefab;

    private bool reachedHalfHealth = false;

    private bool reachedQuarterHealth = false;

    private GameObject player;

    private GameObject projectileSpawner;
    private GameObject anotherProjectileSpawner;
    private GameObject thirdProjectileSpawner;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetBossValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Health>().getHealth() <= GetComponent<Health>().getMaxHealth() / 2 && !reachedHalfHealth)
        {
            reachedHalfHealth = true;
            projectileSpawner = Instantiate(projectileSpawnerPrefab, this.transform.position + new Vector3(0, -15, 0), Quaternion.identity);
            anotherProjectileSpawner = Instantiate(projectileSpawnerPrefab, this.transform.position + new Vector3(5, -12.5f, 0), Quaternion.identity);
            thirdProjectileSpawner = Instantiate(projectileSpawnerPrefab, this.transform.position + new Vector3(-5, -12.5f, 0), Quaternion.identity);
        }
        if (GetComponent<Health>().getHealth() <= GetComponent<Health>().getMaxHealth() / 4 && !reachedQuarterHealth)
        {
            reachedQuarterHealth = true;
            StartCoroutine(SpawnLightning());
        }
        if (GetComponent<Health>().getHealth() <= 10)
        {
            Destroy(projectileSpawner);
            Destroy(anotherProjectileSpawner);
            Destroy(thirdProjectileSpawner);
            StopAllCoroutines();
        }
    }

    private void SetBossValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Health>() != null)
            {
                collision.GetComponent<Health>().Damage(damage);
            }
        }
    }

    private IEnumerator SpawnLightning()
    {
        GameObject shadow = Instantiate(shadowPrefab, player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        GameObject lightningAnim = Instantiate(lightningAnimPrefab, shadow.transform.position + new Vector3(0, 10, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        GameObject lightning = Instantiate(lightningPrefab, lightningAnim.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Destroy(shadow);
        Destroy(lightningAnim); 
        Destroy(lightning);
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnLightning());
    }
}
