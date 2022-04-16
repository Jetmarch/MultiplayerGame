using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float maxJumpHoldTime;
    private bool isJumpTimeAvailable;

    [SerializeField]
    private float digDistance;

    [SerializeField]
    private float handDamage;

    private bool isGrounded;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            transform.position = new Vector3(0f, 2.05f);
        }

        if(Input.GetMouseButtonDown(0))
        {
            DigBlock();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce);
            isJumpTimeAvailable = true;
            StartCoroutine(JumpCountDown());
        }

        if(Input.GetKey(KeyCode.Space) && isJumpTimeAvailable)
        {
            rb.AddForce(Vector2.up * (jumpForce / 100));
        }
    }

    private IEnumerator JumpCountDown()
    {
        yield return new WaitForSeconds(maxJumpHoldTime);
        isJumpTimeAvailable = false;
    }

    private void DigBlock()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        if (Vector2.Distance(mousePos2D, transform.position) > digDistance)
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);


        if(hit.collider != null)
        {
            var block = hit.collider.GetComponent<BlockController>();

            if(block != null)
            {
                block.GetDamage(handDamage);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        

        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, digDistance);

       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Block"))
        {
            isGrounded = true;
        }
    }
}
