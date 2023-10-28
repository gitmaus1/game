using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jump;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    void Start()
    {
        // nær í og gerir tilbúið
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        //stjórnar jump ef plaer er á jörð og ekki dáin
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            // gerir false þegar han hopar svo hann geti ekki hopað í lofti
            isOnGround = false;
            // hop animation
            playerAnim.SetTrigger("Jump_trig");
            // stopar dirtParticle ef hop
            dirtParticle.Stop();
            // hljóð ef hopað
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }
    }
    // ef snertir 
    private void OnCollisionEnter(Collision collision)
    {
        // ef snertir jörð getur hann hopað aftur
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // kveikir á dirtParticle ef snertir jörð
            dirtParticle.Play();
        }
        // ef snertir Obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            // dauða animation
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            // spilar spreingingu
            explosionParticle.Play();
            // stopar dirtParticle á dauða
            dirtParticle.Stop();
            // ef klesir á
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}

