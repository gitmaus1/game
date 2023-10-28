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
        // n�r � og gerir tilb�i�
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        //stj�rnar jump ef plaer er � j�r� og ekki d�in
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            // gerir false �egar han hopar svo hann geti ekki hopa� � lofti
            isOnGround = false;
            // hop animation
            playerAnim.SetTrigger("Jump_trig");
            // stopar dirtParticle ef hop
            dirtParticle.Stop();
            // hlj�� ef hopa�
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }
    }
    // ef snertir 
    private void OnCollisionEnter(Collision collision)
    {
        // ef snertir j�r� getur hann hopa� aftur
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // kveikir � dirtParticle ef snertir j�r�
            dirtParticle.Play();
        }
        // ef snertir Obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            // dau�a animation
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            // spilar spreingingu
            explosionParticle.Play();
            // stopar dirtParticle � dau�a
            dirtParticle.Stop();
            // ef klesir �
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}

