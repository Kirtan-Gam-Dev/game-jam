using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthChange : MonoBehaviour
{
    public AudioSource damage;
    public Text Health;
    public GameObject player;
    private float HealthMax = 8f;
    public float currentHealth;
    public GameObject DeathScreen;

    // Start is called before the first frame update
    void Start()
    {
        Health.text = HealthMax.ToString();
        currentHealth = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
           DeathScreen.SetActive(true);
           player.SetActive(false);
        }

        if(player.transform.position.y <= -7f )
        {
            DeathScreen.SetActive(true);
           player.SetActive(false);
           currentHealth = currentHealth - 8f;
           damage.Play();
            Health.text = currentHealth.ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<Collider2D>().tag == "enemy")
        {
            damage.Play();
            currentHealth = currentHealth - 1f;
        }
        Health.text = currentHealth.ToString();
    }

}

