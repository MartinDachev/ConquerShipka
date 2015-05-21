using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour 
{
	public float health;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Damage(float damage)
	{
		health = health - damage;
		if (health <= 0) 
		{
			Destroy (this.gameObject);
		}
	}
}
