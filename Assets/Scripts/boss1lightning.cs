using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1lightning : MonoBehaviour
{
    private int damage = 20;
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
