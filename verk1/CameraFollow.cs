using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CameraFollow : MonoBehaviour
{
public Transform target;

    public GameObject player;
    private Vector3 offset = new Vector3(0,3,-7);
    void Start()
    {
        
    }


     

    void LateUpdate()
    {
 
        // lætur mindavjel elta leikman
        transform.position = player.transform.TransformPoint(offset);
        // lætue mindavjel snúast með bíll
        transform.eulerAngles = player.transform.eulerAngles;
        // lætue mindavjel líta smá niður 
        transform.Rotate(5.0f, 0.0f, 0.0f, Space.Self);


    

        
    }
}
