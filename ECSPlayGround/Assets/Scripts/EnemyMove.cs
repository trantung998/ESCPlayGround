using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Tweening;
using UnityEngine;

class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    
    void Awake()
    {
    }

    void Start()
    {
        var waypoint = WaypointExtension.waypoints;
        transform.localPosition = waypoint[0];

        transform.DOLocalPath(WaypointExtension.waypoints, speed, PathType.Linear, PathMode.Full3D, 10, Color.green).SetEase(Ease.Linear);
    }
}