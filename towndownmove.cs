using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class towndownmove : MonoBehaviour
{
    [Header("Player")]
    SpriteRenderer sr;
    public float moveSpeed=5f;
    Rigidbody2D rb;
    Vector2 mov;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");
        //
        anim.SetFloat("h",mov.x);
        anim.SetFloat("v", mov.y);
        anim.SetFloat("speed", mov.sqrMagnitude);
        //animations here
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+mov*moveSpeed);
    }
}
