using UnityEngine;
using System.Collections;

public class ControlsTemp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public float Jump;
    public float Speed; 

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, Jump));
        if (Input.GetKey(KeyCode.RightArrow)) GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(Speed, 0)); 
        if (Input.GetKey(KeyCode.LeftArrow)) GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-Speed, 0)); 
        //GetComponent<Rigidbody2D>().AddRelativeForce();
	}
}
