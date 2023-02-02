using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDriver : MonoBehaviour
{
    public float EnginePower = 2;
    public Rigidbody2D rigidBody;
    private bool accelerating = false;
    private bool braking = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Drive();
        if (braking)
        {
            rigidBody.drag = 5f;
        }
        else if (!braking && !accelerating)
        {
            rigidBody.drag = 1.5f;
        }

        if (rigidBody.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rigidBody.velocity.y, rigidBody.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

    void Drive()
    {
        if (!braking)
        {
            if (Input.GetKey(KeyCode.W))
            {
                accelerating = true;
                rigidBody.AddForce(new Vector2(0.0f, 1.0f) * EnginePower);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                accelerating = true;
                rigidBody.AddForce(new Vector2(-1.0f, 0.0f) * EnginePower);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                accelerating = true;
                rigidBody.AddForce(new Vector2(0.0f, -1.0f) * EnginePower);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                accelerating = true;
                rigidBody.AddForce(new Vector2(1.0f, 0.0f) * EnginePower);
            }
            else
            {
                accelerating = false;
            }
        }

        // braking overrides any acceleration
        if (Input.GetKey(KeyCode.Space))
        {
            braking = true;
            accelerating = false;
        }
        else
        {
            braking = false;
        }
    }
}
