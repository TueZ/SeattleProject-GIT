using UnityEngine;
using System.Collections;

public class PlayerAttackScr : MonoBehaviour
{
    public KeyCode Pickup;
    private GameObject currentweapon;
    
    private Player _PL; 
    public KeyCode Attack;
    public float CD;
    private float _CD; 

	// Use this for initialization
	void Start ()
	{
	    _PL = GetComponent<Player>(); 
	}
	
	// Update is called once per frame
	void Update () 
    {
	    AttackFunction();
	}

    void AttackFunction ()
    {
        if (_CD > 0) _CD -= Time.deltaTime; 
        if (Input.GetKeyDown(Attack) & _CD <= 0)
        {
            _CD = CD;
            if (currentweapon != null)
            {
                currentweapon.SendMessage();
            }
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
