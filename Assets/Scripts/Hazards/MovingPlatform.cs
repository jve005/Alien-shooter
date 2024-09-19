using UnityEngine;
using UnityEngine.Serialization;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public LayerMask whatIsWall;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;

    private Rigidbody2D _rigidbody2D;

    void Start()
    {
       _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        if (DetectedWall())
        {
            moveSpeed *= -1;
            //transform.localScale = new Vector2(transform.localScale.x * -1f, 1f);
        }
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
    }

    private bool DetectedWall()
    {
        return Physics2D.OverlapCircle(wallCheckLeft.position, 0.1f, whatIsWall) || Physics2D.OverlapCircle(wallCheckRight.position, 0.1f, whatIsWall);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(wallCheckLeft.position, 0.1f);
    }
}
