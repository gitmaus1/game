using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject ObsticlePreafab;
    //  st�urin �ar sem hlutur spawnar
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
        // ei�ir obsticles �egar er b�i� a� nota ��
        if (transform.position.y < leftBound && gameObject.CompareTag("hindrun"))
        {
            Destroy(gameObject);
        }
    }
    // b�r til hindranir(obsticles) ef gameover er false
    void spawnobsticle()
    {
        
        
            Instantiate(ObsticlePreafab, spawnPos, ObsticlePreafab.transform.rotation);
            Instantiate(ObsticlePreafab, spawnPos2, ObsticlePreafab.transform.rotation);


    }
        // ei�ir obsticles �egar er b�i� a� nota ��
       
}
