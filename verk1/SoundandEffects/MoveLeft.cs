using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10;
    private float leftBound = -15;

    // teingir script
    private PlayerController playerControllerScript;

    void Start()
    {
        // teingir script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        // hreifir bagrun og obsticles ef gameover er false
        if (playerControllerScript.gameOver == false) { 
        // hreifir bagrun og obsticles
        transform.Translate(Vector3.left * Time.deltaTime * speed); }
        // eiðir obsticles þegar er búið að nota þá
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
