using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthChange : MonoBehaviour
{
    public Text Health;
    public GameObject player;
    private float HealthMax = 8f;
    private float currentHealth;
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
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "ground")
        {
            currentHealth = currentHealth - 1f;
        }
        Health.text = currentHealth.ToString();
    }

}

