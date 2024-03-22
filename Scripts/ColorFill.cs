using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFill : MonoBehaviour
{
    public Color lineColor = Color.red; // The color of the line
    public float lineWidth = 0.1f; // Width of the line
    public int maxPoints = 100; // Maximum number of points in the line

    public LineRenderer lineRenderer; // Reference to the LineRenderer component

    void Start()
    {
        // Get the LineRenderer component attached to the object or add one if not present
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // Set line properties
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
    }

    void Update()
    {
        // Add current position to the line
        AddPoint(transform.position);
    }

    void AddPoint(Vector3 point)
    {
        // Add a new point to the line renderer
        if (lineRenderer.positionCount < maxPoints)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, point);
        }
        else
        {
            // Shift all points to the beginning, discarding the oldest point
            for (int i = 1; i < maxPoints; i++)
            {
                lineRenderer.SetPosition(i - 1, lineRenderer.GetPosition(i));
            }
            lineRenderer.SetPosition(maxPoints - 1, point);
        }
    }
} 

