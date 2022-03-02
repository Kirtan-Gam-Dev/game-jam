using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    public GameObject DestroyEffect;

    private void Update()
    {
        transform.Translate( Vector2.right  * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<Collider2D>().tag == "enemy")
        {
            Destroy(gameObject);
        }
    }

}
