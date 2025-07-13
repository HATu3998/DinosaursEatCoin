using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    private bool isGround;
    private Animator animator;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            isGround = false;
            animator.SetBool("isJump", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
      if(col.gameObject.name == "road")
        {
            isGround = true;
            animator.SetBool("isJump", false);
        }else if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
        }
    }
}
