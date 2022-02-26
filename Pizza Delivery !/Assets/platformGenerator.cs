using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenerator : MonoBehaviour
{
    public GameObject platform;
    public GameObject Gardian;

    public Transform GenerationPoint;
    private float distanceBTW;
    private float platformHeight;
    private int Spawnenemy;

    private float platformSize;

    public float platformdisMin;
    public float platformdisMax;

    public float platformHeightMin;
    public float platformHeightMax;

    private int SpawnenemyMin = 1;
    private int SpawnenemyMax = 50;

    // Start is called before the first frame update
    void Start()
    {
        platformSize=platform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Spawnenemy = Random.Range(SpawnenemyMin,SpawnenemyMax);
        
        if(transform.position.x < GenerationPoint.position.x)
        {
            distanceBTW = Random.Range(platformdisMin,platformdisMax);
            platformHeight = Random.Range(platformHeightMin , platformdisMax);

            transform.position = new Vector3(transform.position.x + distanceBTW + platformSize,platformHeight,-9);
            Instantiate(platform,transform.position,transform.rotation);
        }
        Debug.Log(Spawnenemy);
        if(Spawnenemy == 18)
        {
            Invoke("CreateEnemy",10);
        }

    }
    private void CreateEnemy()
    {
        Instantiate(Gardian,transform.position + new Vector3( 2 ,2,0),transform.rotation);
    }
}
