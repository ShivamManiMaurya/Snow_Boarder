using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float surfaceSpeed = 30f;
    [SerializeField] float decreaseSpeed = 10f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        BoostSpeed();
    }

    void BoostSpeed()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = surfaceSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = decreaseSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
    
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
