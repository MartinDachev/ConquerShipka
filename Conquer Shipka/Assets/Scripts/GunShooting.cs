using UnityEngine;
using System.Collections;

public class GunShooting : MonoBehaviour
{

    RaycastHit hit;
    Ray shootRay;
    bool isShooting = false;
    public ParticleSystem bulletParticles;
	GunProperties gunProperties;
	float waitingTime;
	float timeBetweenShots;

	// Use this for initialization
	void Start ()
    {
		gunProperties = this.gameObject.GetComponent<GunProperties> ();
		timeBetweenShots = 60 / gunProperties.rateOfFire;
		waitingTime = timeBetweenShots;
	}
	
	// Update is called once per frame
	void Update () 
    {
		Debug.Log (gunProperties.rateOfFire);
        if (Input.GetMouseButton(0))
        {
			if(waitingTime >= timeBetweenShots)
			{
				if(!isShooting)
				{
					bulletParticles.Play();
				}
	            isShooting = true;

	            shootRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f));
	            if (Physics.Raycast(shootRay, out hit, 1000f))
	            {
                    hit.collider.gameObject.SendMessage("Damage", gunProperties.damage, SendMessageOptions.DontRequireReceiver);
	            }
				waitingTime = 0.0f;
			}
			waitingTime = waitingTime + Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0) && isShooting)
        {
            bulletParticles.Stop();
            isShooting = false;
        }
	}
}
