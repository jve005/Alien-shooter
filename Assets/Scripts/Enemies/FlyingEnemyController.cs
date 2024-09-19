using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public float moveSpeed;
   
    public LayerMask whatIsWall;
    public Transform wallCheck;
    public float x1, x2;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidbody2D.position.x < x1)
        {
            moveSpeed = Mathf.Abs(moveSpeed);
            transform.localScale  = new Vector2(Mathf.Abs(transform.localScale.x) * 1f, 1f);
        }

        else if (_rigidbody2D.position.x > x2)
        {
            moveSpeed = Mathf.Abs(moveSpeed) * -1f;
            transform.localScale  = new Vector2(Mathf.Abs(transform.localScale.x) * -1f, 1f);
        }
        else if (DetectedWall())
        {
            moveSpeed = moveSpeed * -1f;
            transform.localScale  = new Vector2(transform.localScale.x * -1f, 1f);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
    }

    private bool DetectedWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.1f, whatIsWall);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(wallCheck.position, 0.1f);
    }
}