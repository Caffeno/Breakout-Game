using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instacne;
    float baseSpeed = 5f;
    float maxSpeed;
    private Rigidbody2D ballRB;
    private void Awake()
    {
        ballRB = GetComponent<Rigidbody2D>();
        maxSpeed = baseSpeed;
        instacne = this;
    }

    void Start()
    {
        ballRB.velocity = new Vector2(Random.Range(.5f, 1f), Random.Range(.5f, 1f)) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballRB.velocity.magnitude > maxSpeed)
        {
            ballRB.velocity = ballRB.velocity.normalized * (ballRB.velocity.magnitude + maxSpeed) / 2;
        }
    }

    public void SpeedUp(float boostPercentage)
    {
        maxSpeed += boostPercentage * baseSpeed;
        Debug.Log("Max speed + " + (boostPercentage * baseSpeed));

    }
}
