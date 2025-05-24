using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : Warrior
{
    public GameObject[] checkpoints;
    private int i;
    private bool going = true;
    void Start()
    {
        Startrb();
        if(this.tag == "Priest")
        {
            anim.SetBool("Pray", true);
        }
    }

    void Update()
    {
        toCheckpoint();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            transform.position = this.transform.position;
            anim.SetFloat("Speed", 0f);
            going = false;
        }
    }

    public void toCheckpoint()
    {
        if(going)
            if (this.tag == "MainPriest")
                Walk(checkpoints[i], this.gameObject);
    }
}
