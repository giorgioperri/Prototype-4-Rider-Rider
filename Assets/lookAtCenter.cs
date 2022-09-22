using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCenter : MonoBehaviour
{
    public Transform mapCenter;
    void Update()
    {
        transform.LookAt(mapCenter);
    }
}
