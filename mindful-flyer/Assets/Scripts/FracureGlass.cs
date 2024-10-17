using System;
using UnityEngine;
using Delaunay;
using System.Collections.Generic;
using Delaunay.Geo;

[ExecuteInEditMode]
public class FracureGlass : MonoBehaviour
{
    private Collider colliderComponent;

    private float width;
    private float height;

    private Vector2 centerXY;
    private float faceZPosition;
    private List<Vector2> seedPoints;
    private List<LineSegment> edges;

    void Awake()
    {
        seedPoints = new List<Vector2>();

        colliderComponent = GetComponent<Collider>();

        width = colliderComponent.bounds.size.x;
        height = colliderComponent.bounds.size.y;
        centerXY = new Vector2(colliderComponent.bounds.center.x, colliderComponent.bounds.center.y);
        faceZPosition = colliderComponent.bounds.min.z;

        // seedPoints.Add(colliderComponent.bounds.center);
        seedPoints.Add(new Vector2(-0.2f, 0.6f) + centerXY);
        seedPoints.Add(new Vector2(0.3f, 0.3f) + centerXY);
        seedPoints.Add(new Vector2(0.2f, -0.6f) + centerXY);

        // Voronoi voronoi = new Voronoi(seedPoints, new Rect(0, 0, size.x, size.y));
        // edges = voronoi.VoronoiDiagram();
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < seedPoints.Count; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(new Vector3(seedPoints[i].x , seedPoints[i].y, faceZPosition) , 0.1f);
        }


        // Gizmos.color = Color.black;
        // foreach (var edge in edges)
        // {
        //     Vector2 left = edge.p0.Value;
        //     Vector2 right = edge.p1.Value;

        //     // Only draw edges within the bounds
        //     if (IsWithinBounds(left) && IsWithinBounds(right))
        //     {
        //         Gizmos.DrawLine(left, right);
        //     }
        // }

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(0, 0), new Vector2(0, height));
        Gizmos.DrawLine(new Vector2(0, 0), new Vector2(width, 0));
        Gizmos.DrawLine(new Vector2(width, 0), new Vector2(width, height));
        Gizmos.DrawLine(new Vector2(0, height), new Vector2(width, height));
    }

    // private bool IsWithinBounds(Vector2 point)
    // {
    //     return point.x >= 0 && point.x <= size.x && point.y >= 0 && point.y <= size.y;
    // }
}
