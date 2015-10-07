using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OneWayPlatformScr : MonoBehaviour
{

    public List<Collider2D> OneWayPlats;  

    

	// Use this for initialization
	void Start ()
	{
	    _rig = GetComponent<Rigidbody2D>(); 
	}

    private bool _MovesUp = false;
    private Rigidbody2D _rig; 

	// Update is called once per frame
	void Update () 
    {
	    if (!_MovesUp & _rig.velocity.y > 0)
	    {
	        _MovesUp = true;
	        IgnorePlats(); 
	    }
        else if (_MovesUp & _rig.velocity.y <= 0)
	    {
	        _MovesUp = false;
	        EnablePlats();
	    }
	}

    void IgnorePlats()
    {
        Debug.Log("Plats Ignore");
        foreach (Collider2D coll in OneWayPlats)
        {
            Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>(), true);
        }
    }

    void EnablePlats()
    {
        Debug.Log("Plats Enable");
        foreach (Collider2D coll in OneWayPlats)
        {
            Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>(), false);
        }
    }
}
