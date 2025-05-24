using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest_Girl : Warrior
{
    public GameObject[] checkpoints;
    private int i;
    private bool left = true;

    private void Start()
    {
        Startrb();
    }

    private void Update()
    {
        toCheckpoint(i);
    }

    public void toCheckpoint(int i)
    {
        if(this.tag == "GirlWalk")
            Walk(checkpoints[i], this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CheckpointGirl")
        {
            left = !left;
            Flipx(left);
            i++;
            if (i == 2)
                i = 0;
        }
    }
}
