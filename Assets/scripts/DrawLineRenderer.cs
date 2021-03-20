using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DrawLineRenderer : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;
    public Transform Point3;
    public Transform Point4;
     LineRenderer linerenderer;
    public float vertexCount = 40;
    // Start is called before the first frame update
    void Start()
    {
        linerenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {       
        var pointList = new List<Vector3>();

        for (float ratio = 0; ratio <= 1; ratio += 1 / vertexCount)
        {
            var tangent1 = Vector3.Lerp(Point1.position, Point2.position, ratio);
            var tangent2 = Vector3.Lerp(Point2.position, Point3.position, ratio);
            var tangent3 = Vector3.Lerp(Point3.position, Point4.position, ratio);
            var curve1 = Vector3.Lerp(tangent1, tangent2, ratio);
            var curve2 = Vector3.Lerp(tangent2, tangent3, ratio);
            var curve3 = Vector3.Lerp(curve1, curve2, ratio);

            pointList.Add(curve3);
        }
        linerenderer.positionCount = pointList.Count;
        linerenderer.SetPositions(pointList.ToArray());
    }
}