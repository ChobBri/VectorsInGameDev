using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3_ContinuousMovement : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] GameObject circle;
    Vector2 v = Vector2.zero;
    readonly float s = 5.0f;

    // Update is called once per frame
    void Update()
    {
        /**
         * Checkpoint 3:
         * - Make the circle accelerate towards the mouse position at 5 units/second^2
         */
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 circlePosition = circle.transform.position;
        const float accMag = 5.0f;
        Vector2 velocity = v;

        Vector2 acceleration = Vector2.zero;  // edit this variable
        // Your C3 solution here

        acceleration = (mousePos - circlePosition).normalized * accMag;
        velocity += acceleration * Time.deltaTime;
        circlePosition += velocity * Time.deltaTime;

        // End C3 solution


        v = velocity;
        circle.transform.position = circlePosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            circle.transform.position = Vector3.zero;
            v = Vector2.zero;
        }

        Debug.DrawLine(Vector3.zero, circle.transform.position, Color.green);
        Debug.DrawLine(circle.transform.position, circle.transform.position + (Vector3) v, new Color(0.6f, 0.6f, 1.0f));
        Debug.DrawLine(circle.transform.position, circle.transform.position + (Vector3) acceleration, Color.red);
    }
}
