using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public List<Transform> waypoints;

    private void Update()
    {
        waypoints.RemoveAll(list_item => list_item == null);
    }
}
