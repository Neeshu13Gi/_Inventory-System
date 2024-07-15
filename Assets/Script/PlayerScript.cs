using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, ro_speed;
    public AudioClip walkSound;

    private AudioSource audioSource;
    private bool walking;
    public Transform playerTrans;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            velocity += transform.forward * w_speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += -transform.forward * wb_speed;
        }

        playerRigid.velocity = velocity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("Walking");
            playerAnim.ResetTrigger("Idle");
            walking = true;
            PlayWalkingSound();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("Walking");
            playerAnim.SetTrigger("Idle");
            walking = false;
            StopWalkingSound();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("WalkingBackward");
            playerAnim.ResetTrigger("Idle");
            PlayWalkingSound();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("WalkingBackward");
            playerAnim.SetTrigger("Idle");
            StopWalkingSound();
        }


        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }
    }

    void PlayWalkingSound()
    {
        if (!audioSource.isPlaying && walkSound != null)
        {
            audioSource.clip = walkSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void StopWalkingSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
