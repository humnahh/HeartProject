// UMD IMDM290 
// Instructor: Myungin Lee
    // [a <-----------> b]
    // Lerp : Linearly interpolates between two points. 
    // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Vector3.Lerp.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingHeart : MonoBehaviour
{
    static int numSquares = 500;
    float time = 0f;
    Vector3[] startPosition, endPosition;
    GameObject[] squares;
    float lerpFraction;

    void Start()
    {
        squares = new GameObject[numSquares];
        startPosition = new Vector3[numSquares];
        endPosition = new Vector3[numSquares];

        for (int i = 0; i < numSquares; i++)
        {
            float r = 25f;
            startPosition[i] = new Vector3(r * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f));
            
            float t = i * 2 * Mathf.PI / numSquares;
            endPosition[i] = new Vector3(
                5f * Mathf.Sqrt(2f) * Mathf.Sin(t) * Mathf.Sin(t) * Mathf.Sin(t),
                5f * (-Mathf.Cos(t) * Mathf.Cos(t) * Mathf.Cos(t) - Mathf.Cos(t) * Mathf.Cos(t) + 2 * Mathf.Cos(t)) + 3f,
                0f);
            
            squares[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            squares[i].transform.position = startPosition[i];
            squares[i].transform.localScale = Vector3.one * 0.5f;
            squares[i].GetComponent<Renderer>().material.color = (i % 2 == 0) ? Color.green : Color.blue;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        lerpFraction = Mathf.Sin(time) * 0.5f + 0.5f;

        for (int i = 0; i < numSquares; i++)
        {
            squares[i].transform.position = Vector3.Lerp(startPosition[i], endPosition[i], lerpFraction);
            squares[i].transform.Rotate(Vector3.up * 100f * Time.deltaTime);
        }
    }
}
