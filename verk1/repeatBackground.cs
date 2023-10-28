using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class repeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWith;
    void Start()
    {
        // gerir start sta�setningu
        startPos =  transform.position;

        // with backgrunds deilt me� 2
        repeatWith = GetComponent<BoxCollider>().size.x / 2;
        
    }
    
    
    void Update()
    {
        // loopar
        if (transform.position.x < startPos.x - repeatWith)
        {
            transform.position = startPos;
        }
            
    }
}
