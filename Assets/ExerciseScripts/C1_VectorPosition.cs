using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1_VectorPosition : MonoBehaviour
{
    [SerializeField] GameObject square;
    [SerializeField] GameObject circle;
    [SerializeField] GameObject hexagon;

    void Update()
    {
        /**
         * Checkpoint 1:
         * - Move the square to position (2, 1)
         * - Move the circle to position (-4, 3)
         * - Move the hexagon to position (8.5, -7.5)
         */

        // Solution to C1 here



        // End C1 solution

        DrawLinesToShapes();
    }

    void DrawLinesToShapes()
    {
        Debug.DrawLine(Vector3.zero, square.transform.position);
        Debug.DrawLine(Vector3.zero, circle.transform.position);
        Debug.DrawLine(Vector3.zero, hexagon.transform.position);
    }
}
