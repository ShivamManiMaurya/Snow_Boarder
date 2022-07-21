using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float winDelayTime = 2f;
    //[SerializeField] public bool finished = false;
    [SerializeField] ParticleSystem finishLine;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            finishLine.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", winDelayTime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level1");

    }
}
