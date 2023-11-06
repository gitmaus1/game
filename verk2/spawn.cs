using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject ObsticlePreafab;
    //  stðurin þar sem hlutur spawnar
    private Vector3 spawnPos = new Vector3(-12, 10, 59);
    private Vector3 spawnPos2 = new Vector3(-84, 23, 125);
    private float startDelay = 2;
    private float repeatRate = 2;
    //private PlayerController playerControllerScript;

    private float speed = 10;
    private float leftBound = -15;


    void Start()
    {
        InvokeRepeating("spawnobsticle", startDelay, repeatRate);
        // teingir script
       // playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }


    void Update()
    {
        // hreifir bagrun og obsticles
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        // eiðir obsticles þegar er búið að nota þá
        if (transform.position.y < leftBound && gameObject.CompareTag("hindrun"))
        {
            Destroy(gameObject);
        }
    }
    // bír til hindranir(obsticles) ef gameover er false
    void spawnobsticle()
    {
        
        
            Instantiate(ObsticlePreafab, spawnPos, ObsticlePreafab.transform.rotation);
            Instantiate(ObsticlePreafab, spawnPos2, ObsticlePreafab.transform.rotation);


    }
        // eiðir obsticles þegar er búið að nota þá
       
}
