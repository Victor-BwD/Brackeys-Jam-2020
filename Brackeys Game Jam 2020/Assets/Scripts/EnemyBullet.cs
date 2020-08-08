using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        isReady = false;
    }


    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;
            Destroy(gameObject, 5f);
        }
    }
}
