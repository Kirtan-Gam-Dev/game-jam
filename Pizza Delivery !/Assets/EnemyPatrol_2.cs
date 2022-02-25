using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol_2 : MonoBehaviour
{
    private float distoplayer;

    public float range;
    public float speed;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distoplayer = Vector2.Distance(transform.position , Player.transform.position);
        if(distoplayer <= range)
        {
          Chase();
        }
        Flip();
    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position , speed * Time.deltaTime);
    }
    private void Flip()
    {
        if(transform.position.x > Player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }
}
