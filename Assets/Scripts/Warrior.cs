using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public float speed = 3f;
    public float jump = 5f;
    public Animator anim;

    Rigidbody2D rb;
    SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.1f)
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
        if(Input.GetKeyDown(KeyCode.Mouse0) && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            StartCoroutine(Attack1());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            StartCoroutine(Attack2());
        }

        sr.flipX = movement < 0 ? true : false;

        anim.SetFloat("HorizontalMove", Mathf.Abs(movement));
    }

    IEnumerator Jump()
    {
        anim.SetBool("Jump", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Jump", false);
    }

    IEnumerator Attack1()
    {
        anim.SetBool("Attack1", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Attack1", false);
    }
    IEnumerator Attack2()
    {
        anim.SetBool("Attack2", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Attack2", false);
    }

    IEnumerator Dead()
    {
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
    }
}
