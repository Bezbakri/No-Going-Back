using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;  // The animator controller
    private float timeToAttack = 0.25f;
    private float timer = 0;

    private GameObject attackArea;
    private PolygonCollider2D p0lyg0n;
    private bool attacking = false;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        attackArea = transform.GetChild(0).gameObject;
        p0lyg0n = attackArea.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("GoingUp"))
        {
            List<Vector2> upAttackArea = new List<Vector2>();
            upAttackArea.Add(new Vector2(2f, 2f));
            upAttackArea.Add(new Vector2(0f, 6f));
            upAttackArea.Add(new Vector2(-2f, 2f));
            p0lyg0n.SetPath(0, upAttackArea);
        } else if (animator.GetBool("GoingSide"))
        {
            List<Vector2> sideAttackArea = new List<Vector2>();
            sideAttackArea.Add(new Vector2(2f, -2f));
            sideAttackArea.Add(new Vector2(6f, 0f));
            sideAttackArea.Add(new Vector2(2f, 2f));
            p0lyg0n.SetPath(0, sideAttackArea);
        } 
        if (animator.GetBool("GoingDown"))
        {
            List<Vector2> downAttackArea = new List<Vector2>();
            downAttackArea.Add(new Vector2(2f, -1.5f));
            downAttackArea.Add(new Vector2(0f, -5f));
            downAttackArea.Add(new Vector2(-2f, -1.5f));
            p0lyg0n.SetPath(0, downAttackArea);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer > timeToAttack)
            {
                timer = 0;
                attacking = false;
                animator.SetBool("IsAttacking", attacking);
                attackArea.SetActive(attacking);
            }
        }
        
    }
    private void Attack()
    {
        attacking = true;
        animator.SetBool("IsAttacking", attacking);
        attackArea.SetActive(attacking);
    }
}
