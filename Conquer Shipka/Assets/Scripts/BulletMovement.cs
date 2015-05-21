using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour 
{
    float speed = 100f;
    float time = 3f;
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        time -= Time.deltaTime;
        this.transform.position += (this.transform.forward * (Time.deltaTime * speed));
        if (time <= 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
