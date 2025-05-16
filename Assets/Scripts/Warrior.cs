using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public float speed = 3f;
    public float jump = 25f;
    public Animator anim;
    public int health = 100;
    public int damage;

    protected Rigidbody2D rb;
    protected SpriteRenderer sr;

    protected void Startrb()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    protected void Flipx()
    {
        if (Input.GetKeyDown(KeyCode.A))
            sr.flipX = true;
        if (Input.GetKeyDown(KeyCode.D))
            sr.flipX = false;
    }

    protected void Pray(bool norm)
    {
        if (norm)
            anim.SetBool("Pray", true);
        else
            anim.SetBool("Pray", false);
    }

    protected void Eat(bool norm)
    {
        if (norm)
            anim.SetBool("Eat", true);
        else
            anim.SetBool("Eat", false);
    }

    protected IEnumerator Jump()
    {
        anim.SetBool("Jump", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Jump", false);
    }

    protected IEnumerator Attack_Up()
    {
        anim.SetBool("Attack_Up", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Attack_Up", false);
    }
    protected IEnumerator Attack_Forward()
    {
        anim.SetBool("Attack_Forward", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Attack_Forward", false);
    }

    protected IEnumerator Attack_Down()
    {
        anim.SetBool("Attack_Down", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Attack_Down", false);
    }

    protected IEnumerator Dead()
    {
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
    }
}
