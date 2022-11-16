using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsVelocity : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] GameObject circle;
    Vector2 velocity = Vector2.zero;
    readonly float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 circlePosition = circle.transform.position;

        // Solution to Q3 here

        velocity = (mousePos - circlePosition).normalized * speed;
        circlePosition += velocity * Time.deltaTime;

        circle.transform.position = circlePosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            circle.transform.position = Vector3.zero;
            velocity = Vector2.zero;
        }

        Debug.DrawLine(Vector3.zero, circle.transform.position, Color.green);
        Debug.DrawLine(circle.transform.position, circle.transform.position + (Vector3) velocity, new Color(0.6f, 0.6f, 1.0f));
        //Debug.DrawLine(circle.transform.position, circle.transform.position + ((Vector3) mousePos - circle.transform.position).normalized * acceleration, Color.red);
    }
}
