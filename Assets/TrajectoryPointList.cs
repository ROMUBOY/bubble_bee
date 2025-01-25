using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrajectoryPointList : MonoBehaviour
{
    [SerializeField] Vector3[] points;
    [SerializeField] LineRenderer line;
    [SerializeField] Transform target;
    [SerializeField] float duration = 3f;
    [SerializeField] Ease ease = Ease.Linear;
    void Start()
    {
        var _index = 0;
        points = new Vector3[transform.childCount * 2];
        foreach(Transform child in transform) {
            points[_index] = child.position;
            points[(transform.childCount * 2) - _index - 1] = child.position;
            line.positionCount = _index + 1;
            line.SetPosition(_index++, child.position);
        }
        target.position = points[0];
        target.DOPath(points, duration).SetEase(ease).SetLoops(-1);
    }
}