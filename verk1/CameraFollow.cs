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
 
        // l�tur mindavjel elta leikman
        transform.position = player.transform.TransformPoint(offset);
        // l�tue mindavjel sn�ast me� b�ll
        transform.eulerAngles = player.transform.eulerAngles;
        // l�tue mindavjel l�ta sm� ni�ur 
        transform.Rotate(5.0f, 0.0f, 0.0f, Space.Self);


    

        
    }
}
