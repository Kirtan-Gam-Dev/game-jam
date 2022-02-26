using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem blast2;
    [SerializeField] private GameObject Player;
    private float distoplayer;
    private float player;

    void Update()
    {
        distoplayer = Vector2.Distance(transform.position , Player.transform.position);
    }

     private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            anim.SetTrigger("BlastAttack");
            blast2.Play();
            Invoke("DestroyGameObject" , 1f);
        }
        if(distoplayer <= 10)
        {
            var player = Player.gameObject.GetComponent<healthChange>();
            player.currentHealth -= 1;
        }
    }
    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
