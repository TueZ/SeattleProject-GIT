using UnityEngine;
using System.Collections;

public class TeleportScr : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}

    public string PlayerTag;
    public Vector2 Destination;

    void OnTriggerEnter2D (Collider2D coll)
    {
        Debug.Log("Teleport Activated");
        if (coll.gameObject.tag == PlayerTag)
        {
            coll.gameObject.transform.position = Destination;
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
