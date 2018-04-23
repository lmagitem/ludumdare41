							using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car2DController : MonoBehaviour {
    public int player;
    Transform leftFrontWheel;
    Transform rightFrontWheel;
    Transform leftRearWheel;
    Transform rightRearWheel;
    Text publicSpeed;
    Image publicSpeedSlider;

    // Movement variables
    public float speedForce = 5.5f;
    public float angleSpeed = 4f;
    public float timeToMaxSpeed = 1f;
    float speedTimer = 0;
    public float driftFactorSticky = 0.99f;
    public float driftFactorSlippy = 1;
    public float maxStickyVelocity = 2.2f;
    public float minSlippyVelocity = 1.5f;
    public float maxTimeToRestart = 20f;
    float timeToRestart = 0;


    // Power charges
	public int colorVehicule = 0;
	private bool coroutinePurple = false;
	private bool blocageAppui = false;
	public int chargeBleu = 0;
	public int chargeRouge = 0;
	public int colorCharge;

	//Doors interactions
	public int colorToOut;

	// Particules

	public GameObject redTrail;




    void Start ()
    {
        leftFrontWheel = GetComponentInChildren<LFW>().gameObject.transform;
        rightFrontWheel = GetComponentInChildren<RFW>().gameObject.transform;
        leftRearWheel = GetComponentInChildren<LRW>().gameObject.transform;
        rightRearWheel = GetComponentInChildren<RRW>().gameObject.transform;
        publicSpeed = GameObject.Find("RText" + player).GetComponent<Text>();
        publicSpeedSlider = GameObject.Find("SSImage" + player).GetComponent<Image>();
    }

    void Update()
    {
		
	
    }

    void FixedUpdate()
    {
		print (chargeBleu);
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float driftFactor = driftFactorSticky;
        if(RightVelocity().magnitude > maxStickyVelocity)
        {
            driftFactor = driftFactorSlippy;
        }

        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

        if(Input.GetButton("Accelerate p" + player))
        {
            rb.AddForceAtPosition(transform.up * speedForce, new Vector2(leftRearWheel.position.x, leftRearWheel.position.y));
            rb.AddForceAtPosition(transform.up * speedForce, new Vector2(rightRearWheel.position.x, rightRearWheel.position.y));
            timeToRestart = 0;
            angleSpeed = 4;
        }

        if(Input.GetButton("Brakes p" + player))
        {
            if(Mathf.Abs(rb.velocity.x * rb.velocity.y) > 0.1)
            {
                rb.AddForceAtPosition(transform.up * -speedForce / 1.5f, new Vector2(leftRearWheel.position.x, leftRearWheel.position.y));
                rb.AddForceAtPosition(transform.up * -speedForce / 1.5f, new Vector2(rightRearWheel.position.x, rightRearWheel.position.y));
                angleSpeed = 10;
            }
            else
            {
                timeToRestart += 1;
                if(timeToRestart >= maxTimeToRestart)
                {
                    rb.AddForceAtPosition(transform.up * -speedForce, new Vector2(leftRearWheel.position.x, leftRearWheel.position.y));
                    rb.AddForceAtPosition(transform.up * -speedForce, new Vector2(rightRearWheel.position.x, rightRearWheel.position.y));
                    angleSpeed = 4;
                }
            }

        }


        rb.AddForceAtPosition(transform.right * Input.GetAxis("Horizontal p" + player) * rb.velocity.magnitude / angleSpeed, new Vector2(leftFrontWheel.position.x, leftFrontWheel.position.y));
        rb.AddForceAtPosition(transform.right * Input.GetAxis("Horizontal p" + player) * rb.velocity.magnitude / angleSpeed, new Vector2(rightFrontWheel.position.x, rightFrontWheel.position.y));


        float speed = rb.velocity.magnitude / 14;
        publicSpeedSlider.fillAmount = speed;
        float toShow = Mathf.Round(speed * 140);
        publicSpeed.text = toShow + " km/h";

		//je choisi le couleur de la caisse
		if (Input.GetButton ("ColorRed") && Input.GetButton ("ColorBlue")&& coroutinePurple == false)
		{
			colorVehicule = 3;
			blocageAppui = true;
			coroutinePurple = true;
			StartCoroutine ("purplePause");

		} else if (Input.GetButton ("ColorRed") && blocageAppui == false)
		{
			colorVehicule = 2;
			bool trailRed1Created = false;
			if (!trailRed1Created )
			{
				Instantiate (redTrail, transform);		
				trailRed1Created  = true;
			}
		}

		else if(Input.GetButton("ColorBlue")&& blocageAppui == false)
		{
			colorVehicule = 1;
		}

		//je change de Layer pour stop les collision avec les portes
		if (chargeBleu + chargeRouge == 0)
		{
			gameObject.layer = 8;
		}
		if (colorVehicule == 1 && chargeBleu > 0) {
			gameObject.layer = 9; 
		} 
		if (colorVehicule == 2 && chargeRouge > 0) {
			gameObject.layer = 10; 
		} 
		if (colorVehicule == 3 && chargeRouge> 0 && chargeBleu >0) {
			gameObject.layer = 11; 
		} 

    }

	void OnTriggerEnter2D (Collider2D other) // pickups
	{
		if (other.gameObject.CompareTag ("PowerUp")) 
		{
			colorCharge = other.gameObject.GetComponent<PowerUpScript>().colorPower;

			if (colorCharge == 1) 
			{
				chargeBleu = chargeBleu + 3;
			}
			if (colorCharge == 2) 
			{
				chargeRouge = chargeRouge +3;
			}
		
		}

	}

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }
	IEnumerator purplePause()
	{
		yield return new WaitForSeconds (0.5f);
		blocageAppui = false;
		coroutinePurple = false;
	}
		
	void OnTriggerExit2D (Collider2D other) 
	{
		if (other.gameObject.CompareTag ("Doors"))
		{
			colorToOut = other.gameObject.GetComponent<DoorsScriptColor>().colorDoor;
			if (colorToOut == 1)
			{
				chargeBleu = chargeBleu - 1;
			}
			if (colorToOut == 2)
			{
				chargeRouge = chargeRouge-1;
			}
			if (colorToOut == 3)
			{
				chargeRouge = chargeRouge-1;
				chargeBleu = chargeBleu-1;
			}

		}
	}
}

