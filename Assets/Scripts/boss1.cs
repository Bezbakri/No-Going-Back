using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1 : MonoBehaviour
{
    [SerializeField] private int damage = 5;

    [SerializeField] private EnemyData data;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
