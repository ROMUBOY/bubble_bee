using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPointList : MonoBehaviour
{
    [SerializeField] List<Transform> points = new List<Transform>();
    [SerializeField] LineRenderer line;
    void Start()
    {
        var _index = 0;
        foreach(Transform child in transform) {
            points.Add(child);
            line.positionCount = _index + 1;
            line.SetPosition(_index++, child.position);
        }
    }
}
