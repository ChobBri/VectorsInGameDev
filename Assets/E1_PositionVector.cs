using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PositionVector : MonoBehaviour
{
    [SerializeField] GameObject square;
    [SerializeField] GameObject circle;
    [SerializeField] GameObject hexagon;

    void Update()
    {
        /**
         * Question 1:
         * - Move the square to position (2, 1)
         * - Move the circle to position (-4, 3)
         * - Move the hexagon to position (8.5, -7.5)
         */

        // Solution to Q1 here

        square.transform.position = new Vector2(2.0f, 1.0f);
        circle.transform.position = new Vector2(-4.0f, 3.0f);
        hexagon.transform.position = new Vector2(8.5f, -7.5f);
        //square.transform.position = new Vector2(2, 1);
        //circle.transform.position = new Vector2(-4, 3);
        //hexagon.transform.position = new Vector2(8.5f, -7.5f);

        // End Q1 solution

        DrawLinesToShapes();

    }

    /**
     * Notes:
     * - `gobj.transform.position` gets the position property of gobj's transform component
     * - `gobj.transform.position = new Vector2(0, 1)` assigns a position of [0, 1] to gobj
     * 
     * - `new Vector2(x, y)` creates a 2d vector: [x, y]
     * - 'Vector2 v = new Vector2(x, y)' assigns a 2d vector: [x, y] to variable `v` of type `Vector2'
     * - `1.0` is of type `double` whereas `1.0f` is of type `float`!!!!
     */

    void DrawLinesToShapes()
    {
        Debug.DrawLine(Vector3.zero, square.transform.position);
        Debug.DrawLine(Vector3.zero, circle.transform.position);
        Debug.DrawLine(Vector3.zero, hexagon.transform.position);
    }
}
