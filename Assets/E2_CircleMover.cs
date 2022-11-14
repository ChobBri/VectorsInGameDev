using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_CircleMover : MonoBehaviour
{
    [SerializeField] GameObject circle;



    void Update()
    {
        /**
         * Question 2:
         * - When the 'UP' key is pressed, move the circle up 1 unit
         * - When the 'DOWN' key is pressed, move the circle down 2 units
         * - When the 'RIGHT' key is pressed, move the circle right 2 units and up 1 unit
         * - When the 'LEFT' key is pressed, move the circle left 0.5 units and down 0.5 units
         * - When the 'SPACE' key is pressed, move the circle back to the origin
         */

        // Your solution to Q2 here

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            circle.transform.position = (Vector2) circle.transform.position + new Vector2(0.0f, 1.0f);
            circle.transform.position = circle.transform.position + new Vector3(0.0f, 1.0f, 0.0f);

            circle.transform.position += (Vector3) new Vector2(0.0f, 1.0f);
            circle.transform.position = circle.transform.position + (Vector3) new Vector2(0.0f, 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            circle.transform.position += (Vector3) new Vector2(0, -2);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            circle.transform.position += (Vector3) new Vector2(2, 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            circle.transform.position += (Vector3)new Vector2(-0.5f, -0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            circle.transform.position = Vector3.zero;
        }

        // End Q2 solution

    }

    /**
     * Notes:
     * - `=` is an assignment operator NOT an equality operator
     * - `a = a + b` assigns the value `a + b` to the variable `a`
     * - Adding a 3d vector to a 2d vector and vice versa is not defined
     * 
     * - `gobj.transform.position = gobj.transform.position + new Vector2(1, 1);` produces an error
     *      [Vector3] = [Vector3] + [Vector2]   NOT ALLOWED!!!
     *      
     * - Use typecasting: `(T) v` converts whatever `v` is to type `T`
     *      
     * - `gobj.transform.position = (Vector2) gobj.transform.position + new Vector2(1, 1);` works.
     *      [Vector3] = [Vector2] + [Vector2]   ALLOWED
     *      
     *   `gobj.transform.position = gobj.transform.position + (Vector3) new Vector2(1, 1);` works. ***
     *      [Vector3] = [Vector3] + [Vector3]   ALLOWED
     *      
     *   `gobj.transform.position = gobj.transform.position + new Vector3(1, 1, 0);`        works.
     *      [Vector3] = [Vector3] + [Vector3]   ALLOWED
     *   
     *      Notice how Unity can handle the assignment of a 2d vector to a 3d vector.
     *      
     * - `gobj.transform.position += (Vector3) new Vector2(1, 1)` is the same as ***.
     *   `+=`, `-=`, `*=`, `/=`. etc. are called compound-assignment operators. Very useful!
     */
}
