using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car2DController : MonoBehaviour {
    public int player;

    // Movement variables
    public float speedForce = 5.5f;
    public float angleSpeed = 4f;
    public float timeToMaxSpeed = 1f;
    float speedTimer = 0;
    public float driftFactorSticky = 0.95f;
    public float driftFactorSlippy = 1;
    public float maxStickyVelocity = 2.2f;
    public float minSlippyVelocity = 1.5f;
    public float maxTimeToRestart = 20f;
    float timeToRestart = 0;
    public Transform leftFrontWheel;
    public Transform rightFrontWheel;
    public Transform leftRearWheel;
    public Transform rightRearWheel;
    public Text publicSpeed;
    public Image publicSpeedSlider;
	public int color= 0;
	private bool coroutinePurple = false;
	private bool blocageAppui = false;

    void Start ()
    {

    }

    void Update()
    {
		
	
    }

    void FixedUpdate()
    {
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

		if (Input.GetButton ("ColorRed") && Input.GetButton ("ColorBlue")) 
		{
			color = 3;
			blocageAppui = true;
			coroutinePurple = true;
			StartCoroutine ("purplePause");

		}
		else if(Input.GetButton("ColorRed") && blocageAppui == false)
		{
			color = 2;
		}

		else if(Input.GetButton("ColorBlue") && blocageAppui == false)
		{
			color = 1;
		}
		if (color == 1) {
			gameObject.layer = 9; 
			print ("blue");
		} 
		if (color == 2) {
			gameObject.layer = 10; 
			print ("red");
		} 
		if (color == 3) {
			gameObject.layer = 11; 
			print ("purple");
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
}

