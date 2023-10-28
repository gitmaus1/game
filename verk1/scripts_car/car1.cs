using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car1 : MonoBehaviour
{
    private float speed = 20.0f;
    private float TurnSpeed = 45.0f ;
    private float horizontalInput;
    private float forwardInput;


    void Start()
    {
        
    }
    void Update()
    {
        // nær í inputin
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // hreifir bíll áfram og afturáback
        transform.Translate(Vector3.forward * Time.deltaTime*speed * forwardInput);
        // snír bíll
        transform.Rotate(Vector3.up,TurnSpeed * horizontalInput * Time.deltaTime);
    }
}
