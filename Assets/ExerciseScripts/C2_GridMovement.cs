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

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {

        }

        // End C2 solution

        circle.transform.position = position;
    }
}
