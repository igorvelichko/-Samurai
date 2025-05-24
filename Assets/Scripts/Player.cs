using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Warrior
{
    void Start()
    {
        Startrb();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            StartCoroutine(Jump());
        }

        if (Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            speed = 10f;
            anim.SetBool("Run", true);
        }
        else
        {
            speed = 3f;
            anim.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            StartCoroutine(Attack_Up());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            StartCoroutine(Attack_Forward());
        }
        if (Input.GetKeyDown(KeyCode.A))
            Flipx(true);
        if (Input.GetKeyDown(KeyCode.D))
            Flipx(false);
        anim.SetFloat("Speed", Mathf.Abs(movement));
    }
}
