using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockroachBehaviour : MonoBehaviour
{

    float speed = 5;
    public Vector2 target;
    private void Start()
    {
        ChangeDirection();
    }
    private void FixedUpdate()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            target = transform.position;
            Invoke(nameof(ChangeDirection), Random.Range(0.3f, 0.5f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "mininpcwall")
        {
            target = transform.position;
            Invoke(nameof(ChangeDirection), Random.Range(0.3f, 0.5f));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mininpcwall")
        {
            target = transform.position;
            Invoke(nameof(ChangeDirection), Random.Range(0.3f, 0.5f));
        }
    }

    void ChangeDirection()
    {
        target = new Vector2(transform.position.x + Random.Range(-3f, 3f), transform.position.y + Random.Range(-3f, 3f));
    }
}
