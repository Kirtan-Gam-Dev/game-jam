using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float walkspeed , range;
    private float distoplayer;
    private bool mustPatrol;
    private bool mustFlip;

    public Rigidbody2D rb;
    public Transform GroundCheckPoint;
    public LayerMask groundLayer;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }

        distoplayer = Vector2.Distance(transform.position , player.position);

        if(distoplayer <= range)
        {
            if(player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
            mustPatrol = false;
            rb.velocity = Vector2.zero;
            Attack();
        }
        else
        {
            mustPatrol = true;
        }
    }
    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(GroundCheckPoint.position, 0.1f , groundLayer);
        }
    }

    void Patrol()
    {
        if(mustFlip )
        {
            Flip();
        }
        rb.velocity = new Vector2(walkspeed*Time.fixedDeltaTime , rb.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false; 
        transform.localScale = new Vector2(transform.localScale.x * -1 , transform.localScale.y);
        walkspeed *= -1;
        mustPatrol = true; 
    }

    void Attack()
    {

    }
}
