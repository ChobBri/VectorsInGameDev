using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_VectorPhysics : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] GameObject circle;
    Vector2 velocity = Vector2.zero;
    readonly float acceleration = 5.0f;
    readonly float speed = 5.0f;



    // Update is called once per frame
    void Update()
    {
        /**
         * Question 3:
         * - Make the circle accelerate towards the mouse position at 5 units/second^2
         * 
         * If the above is too challenging try to:
         * - Make the circle move towards the mouse position at 5 units/second
         * 
         */
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 circlePosition = circle.transform.position;

        // Solution to Q3 here

        //velocity = (mousePos - circlePosition).normalized * speed;
        //circlePosition += velocity * Time.deltaTime;

        Vector2 accVec = (mousePos - circlePosition).normalized * acceleration;

        velocity += accVec * Time.deltaTime;
        circlePosition += velocity * Time.deltaTime;

        // End Q3 solution

        circle.transform.position = circlePosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            circle.transform.position = Vector3.zero;
            velocity = Vector2.zero;
        }

        Debug.DrawLine(Vector3.zero, circle.transform.position, Color.green);
        Debug.DrawLine(circle.transform.position, circle.transform.position + (Vector3) velocity, new Color(0.6f, 0.6f, 1.0f));
        Debug.DrawLine(circle.transform.position, circle.transform.position + ((Vector3) mousePos - circle.transform.position).normalized * acceleration, Color.red);
    }
}
