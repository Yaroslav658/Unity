using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class characterController: MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float move;
	int score=0;
    void Start()
    {
	}
    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        move = Input.GetAxis("Horizontal");
	}
    void Update()
    {
        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
		}
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0 && !facingRight)
		Flip();
        else if (move < 0 && facingRight)
		Flip();
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
		}
		
		if (Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "die")
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		
		if (col.gameObject.tag == "bonus")
		{
			score++;
			Destroy (col.gameObject);
		}
	}
	
	void OnGUI() {
	GUI.Box (new Rect (0, 0, 100, 100), "Bonus: " + score);
}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}
} 
