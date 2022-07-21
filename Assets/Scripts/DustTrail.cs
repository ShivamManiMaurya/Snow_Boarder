using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem boardSnow;
    [SerializeField] AudioClip slideSFX;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GetComponent<AudioSource>().PlayOneShot(slideSFX);
            boardSnow.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            boardSnow.Stop();
        }
        
    }
}
