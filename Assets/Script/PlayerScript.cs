using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    private bool isGround;
    private Animator animator;

    public Text gameStatus;
    public Text textScore;
    int score = 0;
    bool isGameOver;
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
        if(Input.GetKeyDown(KeyCode.Space) && isGameOver)
        {
            SceneManager.LoadScene("SampleScene");
            isGameOver = false;
            Time.timeScale = 1;
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
            score++;
            textScore.text = "Score: " + score;
        }else if(col.gameObject.tag == "tree")
        {
            Time.timeScale= 0;
            gameStatus.gameObject.SetActive(true);
            isGameOver = true;
        }

    }
}
