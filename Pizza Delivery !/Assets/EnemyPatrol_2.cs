using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol_2 : MonoBehaviour
{
    private float distoplayer;

    private float range = 10;
    public float attackrange;
    public float speed;
    public Animator anim;
    public ParticleSystem blast1;
    public ParticleSystem blast2;
    private GameObject Player;
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        Player = GameObject.FindWithTag("Player");

        distoplayer = Vector2.Distance(transform.position , Player.transform.position);

        if(range <= distoplayer)
        {
          Chase();
          anim.SetBool("attack",false);
        }
        if(distoplayer <= attackrange)
        {
            Chase();
            blast1.Play();
            anim.SetBool("attack",true);
        }
        Flip();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<Collider2D>().tag == "bullet")
        {
            anim.SetTrigger("death");
            gameObject.SetActive(false);
            Invoke("delete",2f);
        }
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
    private void delete()
    {
       Destroy(gameObject);
    }
}
