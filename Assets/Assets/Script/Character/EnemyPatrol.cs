using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public Animator animator;

    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        target = waypoints[0];
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //si le slime est quasi arrivé à sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;

            animator.SetTrigger("SlimeRedHugeJump");
        }
    }

    
}









