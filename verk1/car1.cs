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
        // n�r � inputin
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // hreifir b�ll �fram og aftur�back
        transform.Translate(Vector3.forward * Time.deltaTime*speed * forwardInput);
        // sn�r b�ll
        transform.Rotate(Vector3.up,TurnSpeed * horizontalInput * Time.deltaTime);
    }
}
