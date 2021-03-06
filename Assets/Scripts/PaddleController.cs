using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 2f;


    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Vector2 rbLocation = rb.position;
        float amountToMove = Time.deltaTime * speed * Input.GetAxisRaw("Horizontal");
        rb.MovePosition(new Vector2(rbLocation.x + amountToMove, rbLocation.y));
        
    }
}
