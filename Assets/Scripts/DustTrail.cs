using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem boardSnow;
    [SerializeField] AudioClip slideSFX;

    bool noEffect = true;

    public void DisableBoardEffect()
    {
        noEffect = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GetComponent<AudioSource>().PlayOneShot(slideSFX);
            if (noEffect)
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
