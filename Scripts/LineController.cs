using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    public Transform[] points;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = points.Length;
    }

    private void Update()
    {
        for (int i = 0; i < points.Length; ++i) {
            lr.SetPosition(i, points[i].position);
        }
    }
}
