using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canControl = true;
    public LayerMask LayerGround;
    public float movementSpeed = 5f;
    public float jumbForce = 5f;
    public bool isGrounded = true;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        CharacterControl();

    }

    public void CharacterControl()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * movementSpeed * Time.deltaTime, rb.velocity.y);
        if (!canControl) return;
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumbForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("nup");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(movementSpeed * Time.deltaTime, 0, 0);

        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
