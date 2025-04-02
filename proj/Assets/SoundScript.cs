using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource footstepAudio;
    public float footstepZader = 1f;

    private float nextFootstepTime;
    private bool isMoving;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        isMoving = (horizontal != 0f || vertical != 0f);

        if (isMoving && Time.time >= nextFootstepTime)
        {
            footstepAudio.Play();
            nextFootstepTime = Time.time + footstepZader;
        }
    }
}
