using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public float moveSpeed = 2000;
    public float jumpForce = 200;
    public float lookAtSpeed = 200;

    [HideInInspector] public bool loosed;

    [HideInInspector] public int points;

    [HideInInspector] public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity.x = moveSpeed; // Change this to get the velocity you would prefer
        // Since it is a public variable, I do not know the final value of moveSpeed, but you would want to reduce it
    }

    // Update is called once per frame
    void Update()
    {
        if (loosed) return;
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            Jump();
        }

        //lookAtVelocity();
    }

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void lookAtVelocity()
    {
        lookAtSpeed *= rb.velocity.normalized.y;

        if (gameObject.transform.rotation.y <= 45 || gameObject.transform.rotation.y >= -45)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, lookAtSpeed * Time.deltaTime));
        }

    }

    private void Jump()
    {
        SoundManager.Instance.Play("Jump" + Random.Range(0, 4).ToString());
        rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SoundManager.Instance.Play("Dead");
            CanvasManager.Instance.looseScreen();
            rb.velocity = 0;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
