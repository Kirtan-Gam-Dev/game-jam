using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenerator : MonoBehaviour
{
    public GameObject platform;
    public Transform GenerationPoint;
    private float distanceBTW;
    private float platformHeight;

    private float platformSize;

    public float platformdisMin;
    public float platformdisMax;

    public float platformHeightMin;
    public float platformHeightMax;

    // Start is called before the first frame update
    void Start()
    {
        platformSize=platform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x < GenerationPoint.position.x)
        {
            distanceBTW = Random.Range(platformdisMin,platformdisMax);
            platformHeight = Random.Range(platformHeightMin , platformdisMax);

            transform.position = new Vector3(transform.position.x + distanceBTW + platformSize,platformHeight,-9);
            Instantiate(platform,transform.position,transform.rotation);
        }

    }
}
