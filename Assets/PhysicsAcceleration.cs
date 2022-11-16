using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAcceleration : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] GameObject circle;
    Vector2 v = Vector2.zero;
    readonly float s = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition); Vector2 circlePosition = circle.transform.position;
        float accMag = 5.0f;
        Vector2 velocity = v;
        Vector2 accVec;
        accMag = 5.0f;
        accVec = (mousePos - circlePosition).normalized * accMag;
        bool isLocked = true;
        if (Input.GetKey(KeyCode.S))
            accVec = Vector2.down * accMag;
        else if (Input.GetKey(KeyCode.A))
            accVec = Vector2.left * accMag;
        else if (Input.GetKey(KeyCode.D))
            accVec = Vector2.right * accMag;
        else if (Input.GetKey(KeyCode.W))
            accVec = Vector2.up * accMag;
        else
        {
            isLocked = false;
        }

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition); accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; accMag = 5.0f; velocity += accVec * Time.deltaTime; accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; accMag = 5.0f; circlePosition += velocity * Time.deltaTime; mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition); accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition); accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); accMag = 5.0f; mousePos = camera.ScreenToWorldPoint(Input.mousePosition); mousePos = camera.ScreenToWorldPoint(Input.mousePosition);


        Debug.Log($"{v} : {isLocked}");
        v = velocity;
        circle.transform.position = circlePosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            circle.transform.position = Vector3.zero;
            v = Vector2.zero;
        }

        Debug.DrawLine(Vector3.zero, circle.transform.position, Color.green);
        Debug.DrawLine(circle.transform.position, circle.transform.position + (Vector3) v, new Color(0.6f, 0.6f, 1.0f));
        Debug.DrawLine(circle.transform.position, circle.transform.position + (Vector3) accVec, Color.red);
    }
}
