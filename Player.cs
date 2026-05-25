using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 7f;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public string currentColor;

    public string FinishLine;

    public string Level2;

    public Color Cyan;
    public Color Yellow;
    public Color Pink;
    public Color Purple;

    

    void Start()
    {
        SetRandomColor();
        
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 3);
        if (index == 0)
        {
            currentColor = "Cyan";
            sr.color = Cyan;
        }
        else if (index == 1)
        {
            currentColor = "Yellow";
            sr.color = Yellow;
        }
        else if (index == 2)
        {
            currentColor = "Purple";
            sr.color = Purple;
        }
        else
        {
            currentColor = "Pink";
            sr.color = Pink;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }

        if (collision.CompareTag("FinishLine"))
        {
            Debug.Log("You won");
            SceneManager.LoadScene(Level2);
            return;
        }

        if (collision.name != currentColor)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
    }
}
