using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C5_PlanetMovement : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject planet1;
    [SerializeField] GameObject planet2;

    Vector3 initPos;

    Rigidbody2D ballRb;
    Rigidbody2D planet1Rb;
    Rigidbody2D planet2Rb;

    private void Awake()
    {
        ballRb = ball.GetComponent<Rigidbody2D>();
        planet1Rb = planet1.GetComponent<Rigidbody2D>();
        planet2Rb = planet2.GetComponent<Rigidbody2D>();

        initPos = ballRb.position;
    }

    private void Update()
    {
        // If click LMB
        if (Input.GetMouseButtonDown(0))
        {
            Launch();
        } 
        // If click RMB
        else if (Input.GetMouseButtonDown(1))
        {
            Boost();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballRb.position = initPos;
            ballRb.velocity = Vector2.zero;
        }    
    }

    void FixedUpdate()
    {
        const float G = 25.0f;
        float rSqrd1 = (ballRb.position - planet1Rb.position).sqrMagnitude;
        float forceMag1 = G * (ballRb.mass * planet1Rb.mass) / rSqrd1;
        Vector2 force1 = (planet1Rb.position - ballRb.position).normalized * forceMag1;

        float rSqrd2 = (ballRb.position - planet2Rb.position).sqrMagnitude;
        float forceMag2 = G * (ballRb.mass * planet2Rb.mass) / rSqrd2;
        Vector2 force2 = (planet2Rb.position - ballRb.position).normalized * forceMag2;

        Vector2 force = force1 + force2;
        
        ballRb.AddForce(force);
    }

    private void Launch()
    {
        /*
         *  Checkpoint 5a: When this method is invoked, a force of 10N should be applied to
         *  the ball in the direction normal to the closest planet.
         *  
         *  In other words, set `launchForce` to be of length 10 and have it be in
         *  the direction normal to the planet.
         */
        Vector2 planetPosition = GetClosestPlanetPosition();
        Vector2 ballPosition = ballRb.position;

        const float launchForceMag = 10.0f;  // 10 Newtons

        Vector2 launchForce = Vector2.zero;  // edit this variable
        // Your solution to Launch() here


        // End solution

        ballRb.AddForce(launchForce, ForceMode2D.Impulse);
    }

    private void Boost()
    {
        /*
         *  Checkpoint 5b: When this method is invoked, a force of 4N should be applied to
         *  the ball in the direction tangent to the closest planet.
         *  
         *  The ball should be boosted in the tangent direction that the ball is moving in.
         *  If the ball is stationary, you can choose which way to boost.
         *  
         *  You should set `boostForce` to be of length 4 and in the appropriate tangent direction
         */

        Vector2 planetPosition = GetClosestPlanetPosition();
        Vector2 ballPosition = ballRb.position;

        Vector2 ballVelocity = ballRb.velocity;

        const float boostForceMag = 4.0f;  // 4 Newtons

        Quaternion rotCW = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        Quaternion rotCCW = Quaternion.Euler(0.0f, 0.0f, 90.0f);

        // Vector2 vec = Vector2.up;
        // Vector2 vecRotCW = rotCW * vec;   // rotate `vec` 90 deg clockwise
        // Vector2 vecRotCCW = rotCCW * vec; // rotate `vec` 90 deg counter-clockwise

        Vector2 boostForce = Vector2.zero;
        // Your solution to Boost() here


        // End solution

        ballRb.AddForce(boostForce, ForceMode2D.Impulse);
    }

    private Vector3 GetClosestPlanetPosition()
    {
        return ((ballRb.position - planet1Rb.position).magnitude - planet1.GetComponent<CircleCollider2D>().radius * planet1.transform.localScale.x) -
            ((ballRb.position - planet2Rb.position).magnitude - planet2.GetComponent<CircleCollider2D>().radius * planet2.transform.localScale.x) < 0.0f ? planet1Rb.position : planet2Rb.position;
    }
}
