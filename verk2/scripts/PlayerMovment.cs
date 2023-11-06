using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.2f;
    public float sideways = 0.2f;
    public float jump ;
    //private Rigidbody leikmadur;
    public static int count;


    public TextMeshProUGUI countText;

    // er á júrð
    public bool isOnGround = true;
    private Rigidbody playerRb;


    public AudioClip jumpSound;


    public AudioClip coinsound;


    private AudioSource playerAudio;


    void Start()
    {
        Debug.Log("byrja");

        // nær í og gerir tilbúið
        playerRb = GetComponent<Rigidbody>();

        // tekur líf úr minni
        count = saveHlutir.Life;


        // hlóð
        playerAudio = GetComponent<AudioSource>();



        if (count > 0)
        {
            countText.text = "Stig: " + count.ToString();

            
        }
        // gefur mission 1
        if(SceneManager.GetActiveScene().buildIndex == 1)
        { 
            countText.text = "mission  1 náðu í alla coins"; 
        }
        // gefur mission 2
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            countText.text += "   mission  2 kláraðu level";
        }


       








    }
    // Update is called once per frame
    void FixedUpdate()
    {
  
        if (Input.GetKey(KeyCode.UpArrow))//áfram
        {
            transform.position += transform.forward * speed ;
        }
        if (Input.GetKey(KeyCode.DownArrow))// til baka
        {
            transform.position += -transform.forward * speed;

        }
        if (Input.GetKey(KeyCode.RightArrow))//hægri
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.LeftArrow))//vinstri
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
            transform.position += -transform.right * sideways;
        }


        //stjórnar jump ef plaer er á jörð
        if (Input.GetKey(KeyCode.Space) && isOnGround  )
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);


            isOnGround = false;

            // hljóð ef hopað
            playerAudio.PlayOneShot(jumpSound, 1.0f);



        }

















        //hér rétti ég playerinn við ef hann dettur
        //sný player
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }


        if (Input.GetKey("e"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("q"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (Input.GetKey("r"))// ef ýtt er á r
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }


        if (Input.GetKey("w"))//áfram
        {
            transform.position += transform.forward * speed;
        }
        if (Input.GetKey("s"))// til baka
        {
            transform.position += -transform.forward * speed;

        }
        if (Input.GetKey("d"))//hægri
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey("a"))//vinstri
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
            transform.position += -transform.right * sideways;
        }


























        // enduræsir leik
        if (transform.position.y <= -1)
        {
            



            this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
            countText.text = "Dauður eftir fall ";

            StartCoroutine(Bida());
        }
        
    }
   
      void OnCollisionEnter(Collision collision)
     {
         // ef player keyrir á object sem heitir hlutur
         if (collision.collider.tag == "hlutur")
         {
             collision.collider.gameObject.SetActive(false);
             count = count + 1;

            // savar líf í minni
            saveHlutir.Life += 1;
            // hljóð ef hopað
            playerAudio.PlayOneShot(coinsound, 1.0f);


            // Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
         }




         if (collision.collider.tag == "hindrun")
         {
             //save lífe
             count = count -2;
            saveHlutir.Life -= 2;
            // er á júrð
            isOnGround = true;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
         }

        // ef snertir jörð getur hann hopað aftur
        if (collision.gameObject.CompareTag("Ground"))
        {
            // er á júrð
            isOnGround = true;
        }
    }
   
     void SetCountText()
     {
         countText.text = "Stig: " + count.ToString();



         if (count <= 0 )
         {
             this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
             countText.text = "Dauður út af hindrun ";

             StartCoroutine(Bida());
            

        }

        

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (count == 4)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//næsta sena


            }
        }










    }
     IEnumerator Bida()
     {
        
         yield return new WaitForSeconds(2);
         Endurræsa();
     }

     public void Byrja()
     {
         SceneManager.LoadScene(1);
     }
     public void Endurræsa()
     {
        // kemur í veg fyrir að þú birjir í mínus
        count = 0;


        // savar líf í minni
        saveHlutir.Life = 0;


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
         SceneManager.LoadScene(0);
     }
    
}
