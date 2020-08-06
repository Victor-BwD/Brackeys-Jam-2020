using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //speed in x
    public float velx = 7f;
    //speed in y
    float vely = 0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        rb.velocity = new Vector2(velx, vely);
        //after 5 seconds destroy the gameobject
        Destroy(gameObject, 5f);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
