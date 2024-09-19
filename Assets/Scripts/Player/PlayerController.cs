using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;

    [Header("Components")]
    private InputActions _input;
    private Rigidbody2D _rigidbody2D;
    private float LookDeg;
    private AudioSource _audioSource;
  
    [Header("GroundCheck")]
    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(0.8f, 0.2f);
    
    [Header("Audio")]
    public AudioClip[] jumpSounds;
    public AudioClip deathSound;
    
    public GameObject bullet; //We store the Bullet Prefab here so our code can create a copy.
    public Transform bulletSpawn; //This Transform stores position in gamespace.

    private void Start()
    {
        _input = GetComponent<InputActions>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);


        if (_input.Jump && playerIsGrounded)
        {
            _rigidbody2D.linearVelocityY = jumpSpeed;
            _audioSource.pitch = Random.Range(0.8f, 1.2f);
            _audioSource.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
        }
        if (_input.Attack || Keyboard.current.spaceKey.wasPressedThisFrame) //the frame we press the Space key.
        {
            //Instantiate is a way to create GameObjects through code. We use the bullet as a template, and create it at the bulletSpawn position.
            //Quaternion.identity is the objects rotation.
            // Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = _input.Horizontal * moveSpeed;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, groundBoxSize);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Death"))
        {
            _audioSource.PlayOneShot(deathSound);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}