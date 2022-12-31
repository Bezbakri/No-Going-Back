using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1projectile : MonoBehaviour
{
    [SerializeField] private int damage = 15;

    [SerializeField] private float speed = 1.5f;

    [SerializeField] private EnemyData data;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
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
        if (collision.GetComponent<Rigidbody2D>() != null && !collision.CompareTag("boss1"))
        {
            this.GetComponent<Health>().Damage(100000);
        }
    }
}
