using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform Player;
    public float speed = 1f;
    private float minDistance = 0.2f;
    private float range;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player").transform;
        
        range = Vector2.Distance(transform.position, Player.position);
        if (range > minDistance)
        {
            
            Player = GameObject.FindWithTag("Player").transform;
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            
        }
    }
}
