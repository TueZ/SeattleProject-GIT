using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public KeyCode Up;
    public KeyCode Pickup;
    public KeyCode Right;
    public KeyCode Left;
    private GameObject currentweapon;
    public float MoveSpeed;
    public float JumpSpeed; 
    private Rigidbody2D PlayerBody;
    public int WallLayer; 
    
	void Start () 
    {
        PlayerBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector2 theVelocity = PlayerBody.velocity;
        //Husk at ændre værdierne i denne raycast, når størrelsen af spilleren ændres 
        if (Input.GetKey(Right) & !Physics2D.Raycast(transform.position + new Vector3(0.6f, 0), Vector2.right, 0.1f, WallLayer) & !Physics2D.Raycast(transform.position + new Vector3(0.6f, 0.5f), Vector2.right, 0.1f, WallLayer) & !Physics2D.Raycast(transform.position + new Vector3(0.6f, -0.5f), Vector2.right, 0.1f, WallLayer))
        {
            PlayerBody.velocity = new Vector2(MoveSpeed, theVelocity.y);
	    }
        if (Input.GetKey(Left) & !Physics2D.Raycast(transform.position + new Vector3(-0.6f, 0), Vector2.left, 0.1f, WallLayer) & !Physics2D.Raycast(transform.position + new Vector3(-0.6f, 0.5f), Vector2.left, 0.1f, WallLayer) & !Physics2D.Raycast(transform.position + new Vector3(-0.6f, -0.5f), Vector2.left, 0.1f, WallLayer))
        {
            PlayerBody.velocity = new Vector2(-MoveSpeed, theVelocity.y);
        }
        if (Input.GetKeyDown(Up) & (Physics2D.Raycast(transform.position + new Vector3(0, -0.6f), Vector2.down, 0.1f, WallLayer) || Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.6f), Vector2.down, 0.1f, WallLayer) || Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.6f), Vector2.down, 0.1f, WallLayer)))
	    {
            PlayerBody.velocity = new Vector2(theVelocity.x, JumpSpeed);
	    }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Pistol" && Input.GetKeyDown(Pickup))
        {
            GameObject pistolGO = transform.FindChild("weapon1").gameObject;
            if (currentweapon != null) currentweapon.SetActive(false);
            pistolGO.SetActive(true);
            currentweapon = pistolGO;
            Destroy(other.gameObject);
        }
        if (other.name == "Bat" && Input.GetKeyDown(Pickup))
        {
            GameObject batGO = transform.FindChild("weapon2").gameObject;
            if (currentweapon != null) currentweapon.SetActive(false);
            batGO.SetActive(true);
            currentweapon = batGO;
            Destroy(other.gameObject);
        }
    }
}
