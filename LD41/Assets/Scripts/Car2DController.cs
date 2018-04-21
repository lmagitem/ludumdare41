using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2DController : MonoBehaviour {

    public float speedForce = 5.5f;
    public float angleSpeed = 4f;
    public float driftFactorSticky = 0.95f;
    public float driftFactorSlippy = 1;
    public float maxStickyVelocity = 2.2f;
    public float minSlippyVelocity = 1.5f;

    public Transform leftFrontWheel;
    public Transform rightFrontWheel;
    public Transform leftRearWheel;
    public Transform rightRearWheel;

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

        // À AJOUTER : Accélération progressive

        if(Input.GetButton("Accelerate"))
        {
            rb.AddForceAtPosition(transform.up * speedForce, new Vector2(leftRearWheel.position.x, leftRearWheel.position.y));
            rb.AddForceAtPosition(transform.up * speedForce, new Vector2(rightRearWheel.position.x, rightRearWheel.position.y));
        }

        // À AJOUTER : Si tu appuies sur les freins, ça ne recule pas direct, ça tue ta vitesse, puis quand t'es arrêté, tu pars en arrière.

        if(Input.GetButton("Brakes"))
        {
            rb.AddForceAtPosition(transform.up * -speedForce / 2, new Vector2(leftRearWheel.position.x, leftRearWheel.position.y));
            rb.AddForceAtPosition(transform.up * -speedForce / 2, new Vector2(rightRearWheel.position.x, rightRearWheel.position.y));
            rb.AddForce(transform.up * -speedForce / 2f);
        }

        rb.AddForceAtPosition(transform.right * Input.GetAxis("Horizontal") * rb.velocity.magnitude / angleSpeed, new Vector2(leftFrontWheel.position.x, leftFrontWheel.position.y));
        rb.AddForceAtPosition(transform.right * Input.GetAxis("Horizontal") * rb.velocity.magnitude / angleSpeed, new Vector2(rightFrontWheel.position.x, rightFrontWheel.position.y));

    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }
}
