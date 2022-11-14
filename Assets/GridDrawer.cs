using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GridDrawer : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] Color gridColor;
    [SerializeField] Color axisColor;
    [Range(0.0f, 10.0f)]
    [SerializeField] float gridStrokeWeight;
    [Range(0.0f, 10.0f)]
    [SerializeField] float axisStrokeWeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        int size = (int) camera.orthographicSize + 1;
        for (int row = -size; row <= size; row++)
        {
            Vector2 startPoint = new Vector2(-size, row);
            Vector2 endPoint = new Vector2(size, row);

            Handles.color = row == 0 ? axisColor : gridColor;
            float strokeWeight = row == 0 ? axisStrokeWeight : gridStrokeWeight;
            Handles.DrawLine(startPoint, endPoint, strokeWeight);
        }

        for (int col = -size; col <= size; col++)
        {
            Vector2 startPoint = new Vector2(col, -size);
            Vector2 endPoint = new Vector2(col, size);

            Handles.color = col == 0 ? axisColor : gridColor;
            float strokeWeight = col == 0 ? axisStrokeWeight : gridStrokeWeight;
            Handles.DrawLine(startPoint, endPoint, strokeWeight);
        }
    }
}
