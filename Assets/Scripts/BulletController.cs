using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15; //The speed variable is used to control how fast the bullet move
    public float despawnTimer = 3; //This variable determines the time before the GameObject is destroyed
   
    public Rigidbody2D _rigidbody2D; //Rigidbody give the GameObject physics.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, despawnTimer);
    }
    // Update is called once per frame
    void Update()
    {
        //Since bullets constantly move we don't have to check for any input,
        //just constantly add velocity to the object. 
        // _rigidbody2D.linearVelocity = new Vector2(1, 0) * speed;
        _rigidbody2D.linearVelocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().health -= 1;
            // other.gameObject.GetComponent<SpriteRenderer>().color = Color.;
            Destroy(gameObject);
        }

        if (other.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
}

