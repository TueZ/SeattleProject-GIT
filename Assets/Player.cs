using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public KeyCode Up;
    public KeyCode Right;
    public KeyCode Left;
    public float MoveSpeed;
    public float JumpSpeed; 
    private Rigidbody2D PlayerBody;
    public int WallLayer; 
    
	void Start () 
    {
        PlayerBody = GetComponent<Rigidbody2D>();

        //hello Tue jeg tester
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayerMovement();
	}

    public bool FaceRight; 

    void PlayerMovement ()
    {
        Vector2 theVelocity = PlayerBody.velocity;
        //Husk at ændre værdierne i denne raycast, når størrelsen af spilleren ændres 
        if (Input.GetKey(Right) & !Physics2D.Raycast(transform.position + new Vector3(0.6f, 0), Vector2.right, 0.1f, WallLayer) & !Physics2D.Raycast(transform.position + new Vector3(0.6f, 0.5f), Vector2.right, 0.1f, WallLayer) & !Physics2D.Raycast(transform.position + new Vector3(0.6f, -0.5f), Vector2.right, 0.1f, WallLayer))
        {
            PlayerBody.velocity = new Vector2(MoveSpeed, theVelocity.y);
            FaceRight = true; 
        }
        if (Input.GetKey(Left) & !Physics2D.Raycast(transform.position + new Vector3(-0.6f, 0), Vector2.left, 0.1f, WallLayer) & !Physics2D.Raycast(transform.position + new Vector3(-0.6f, 0.5f), Vector2.left, 0.1f, WallLayer) & !Physics2D.Raycast(transform.position + new Vector3(-0.6f, -0.5f), Vector2.left, 0.1f, WallLayer))
        {
            PlayerBody.velocity = new Vector2(-MoveSpeed, theVelocity.y);
            FaceRight = false; 
        }
        if (Input.GetKeyDown(Up) & (Physics2D.Raycast(transform.position + new Vector3(0, -0.6f), Vector2.down, 0.1f, WallLayer) || Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.6f), Vector2.down, 0.1f, WallLayer) || Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.6f), Vector2.down, 0.1f, WallLayer)))
	    {
            PlayerBody.velocity = new Vector2(theVelocity.x, JumpSpeed);
	    }
        WallCollision();
    }

    void WallCollision()
    {
        if ((Physics2D.Raycast(transform.position + new Vector3(0.6f, 0), Vector2.right, 0.1f, WallLayer) ||
            Physics2D.Raycast(transform.position + new Vector3(0.6f, 0.5f), Vector2.right, 0.1f, WallLayer) ||
            Physics2D.Raycast(transform.position + new Vector3(0.6f, -0.5f), Vector2.right, 0.1f, WallLayer)) & PlayerBody.velocity.x > 0)
        {
            Debug.Log("Right Reset");
            PlayerBody.velocity = new Vector2(0, PlayerBody.velocity.y);
        }
        if ((Physics2D.Raycast(transform.position + new Vector3(-0.6f, 0), Vector2.left, 0.1f, WallLayer) ||
            Physics2D.Raycast(transform.position + new Vector3(-0.6f, 0.5f), Vector2.left, 0.1f, WallLayer) ||
            Physics2D.Raycast(transform.position + new Vector3(-0.6f, -0.5f), Vector2.left, 0.1f, WallLayer)) & PlayerBody.velocity.x < 0)
        {
            Debug.Log("Left Reset");
            PlayerBody.velocity = new Vector2(0, PlayerBody.velocity.y);
        }
    }

    
}
