using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShapesText : MonoBehaviour
{
    [SerializeField] TMP_Text shapesText;
    [SerializeField] GameObject square;
    [SerializeField] GameObject circle;
    [SerializeField] GameObject hexagon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shapesText.text = $"Square: {(Vector2)square.transform.position}\n" +
            $"Circle: {(Vector2)circle.transform.position}\n" +
            $"Hexagon: {(Vector2)hexagon.transform.position}";
    }
}
