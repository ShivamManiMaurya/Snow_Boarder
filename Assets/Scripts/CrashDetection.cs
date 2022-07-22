using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] float deadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip loseSFX;

    bool noDeathAfterFinish = true;

    public void DisableDeathAfterFinish()
    {
        noDeathAfterFinish = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Ground"))
        {
            if (noDeathAfterFinish)
            {
                // Disable Snowboard Effect from DustTrail.cs
                FindObjectOfType<DustTrail>().DisableBoardEffect();

                // Disable Controls from PlayerContoller.cs
                FindObjectOfType<PlayerController>().DisableControl();

                // Disable Movement of player
                FindObjectOfType<SurfaceEffector2D>().enabled = false;

                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(loseSFX);
                Invoke("ReloadSceneWhenLose", deadDelay);
            }
        }
    }

    void ReloadSceneWhenLose()
    {
        SceneManager.LoadScene("Level1");
    }
}
