using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject ObsticlePreafab;
    //  stðurin þar sem hlutur spawnar
    private Vector3 spawnPos = new Vector3(50, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    void Start()
    {
        InvokeRepeating("spawnobsticle", startDelay, repeatRate);
        // teingir script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }


    void Update()
    {
        
    }
    // bír til hindranir(obsticles) ef gameover er false
    void spawnobsticle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(ObsticlePreafab, spawnPos, ObsticlePreafab.transform.rotation);
        }
    }
}
