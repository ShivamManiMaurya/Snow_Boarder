using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] float deadDelay = 0.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Ground"))
        {
            Invoke("ReloadSceneWhenLose", deadDelay);
        }
    }

    void ReloadSceneWhenLose()
    {
        SceneManager.LoadScene("Level1");

    }
}
