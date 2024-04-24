using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speedX = 10f;
    public float speedY = 5f;
    public float dirX;
    public float dirY;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.acceleration.x * speedX;
        dirY = Input.acceleration.y * speedY;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -14f, 14f), transform.position.y);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }
}
