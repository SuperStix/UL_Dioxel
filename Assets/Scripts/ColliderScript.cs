using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

    public string restrictLetter;
    public string nextLetter;
    public GameObject mask;
    CircleCollider2D cc;

    public float timer;

    private void Start()
    {
        cc = this.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            cc.isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

       // if(collision.tag == "Mask")
       // {
       //     collision.tag = "Restrict";
	   //
       //     if(collision.tag == "Restrict")
       //     {
       //         Destroy(this.gameObject);
       //     }
       // }


        if (collision.gameObject.tag == "Mask")
        {
            Destroy(this.gameObject);
        }

       
        if(restrictLetter == "I" && nextLetter == "D")
        {
            if (collision.tag == "D")
            {
                Destroy(collision.gameObject);
            }
            if (collision.tag == "I" || collision.tag == "O" || collision.tag == "X" || collision.tag == "E" || collision.tag == "L")
            {
                Destroy(this.gameObject);
            }
        }
        if (restrictLetter == "O" && nextLetter == "I")
        {
            if (collision.tag == "I")
            {
                Destroy(collision.gameObject);
            }
            if (collision.tag == "O" || collision.tag == "X" || collision.tag == "E" || collision.tag == "L")
            {
                Destroy(this.gameObject);
            }
        }
        if (restrictLetter == "X" && nextLetter == "O")
        {
            if (collision.tag == "O")
            {
                Destroy(collision.gameObject);
            }
            if (collision.tag == "X" || collision.tag == "E" || collision.tag == "L")
            {
                Destroy(this.gameObject);
            }
        }
        if (restrictLetter == "E" && nextLetter == "X")
        {
            if (collision.tag == "X")
            {
                Destroy(collision.gameObject);
            }
            if (collision.tag == "E" || collision.tag == "L")
            {
                Destroy(this.gameObject);
            }
        }
        if (restrictLetter == "L" && nextLetter == "E")
        {
            if (collision.tag == "E")
            {
                Destroy(collision.gameObject);
            }
            if (collision.tag == "L")
            {
                Destroy(this.gameObject);
            }
        }
        if (restrictLetter == "" && nextLetter == "L")
        {
            if (collision.tag == "L")
            {
                Destroy(collision.gameObject);
            }           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Restrict")
        {
            Destroy(this.gameObject);
        }

    }
}
