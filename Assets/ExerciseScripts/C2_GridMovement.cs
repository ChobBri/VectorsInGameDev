using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2_GridMovement : MonoBehaviour
{
    [SerializeField] GameObject circle;



    void Update()
    {
        /**
         * Checkpoint 2:
         * - When the 'UP' key is pressed, move the circle up 1 unit
         * - When the 'DOWN' key is pressed, move the circle down 1 unit
         * - When the 'RIGHT' key is pressed, move the circle right 1 unit
         * - When the 'LEFT' key is pressed, move the circle left 1 unit
         * - When the 'SPACE' key is pressed, move the circle back to the origin
         */

        Vector2 position = circle.transform.position;  // edit this variable
        // Your solution to C2 here
         
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position += new Vector2(0.0f, 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position += new Vector2(0.0f, -1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            position += Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            position += Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            position = Vector2.zero;
        }

        // End C2 solution

        circle.transform.position = position;
    }
}
