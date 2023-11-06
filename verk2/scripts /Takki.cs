using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Takki : MonoBehaviour
{


    public TextMeshProUGUI texti;
   
    public void Start()
    {

        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

        // ef lokasena texti
        if (SceneManager.GetActiveScene().buildIndex==3)
        {
            Debug.Log("cccccccccccccccccccccccccccccccccccccccccccc");
            texti.text = "Lokastig " + saveHlutir.Life + " af 8 ítu á taka til að endurstarta" ;
            // endurstilir líf
            saveHlutir.Life = 0;


        }
        
    }
    void Update()
    {
        // getur líka birjað með space
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("SPACE");
            SceneManager.LoadScene(1);
        }
    }






        public void Byrja()
    {
        Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
        SceneManager.LoadScene(1);

    }


    public void Endir()
    {
        SceneManager.LoadScene(0);
        PlayerMovment.count = 0;
    }
    
}
