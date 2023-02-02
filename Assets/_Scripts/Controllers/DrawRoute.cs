using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRoute : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        for(int i = 0; i < transform.childCount - 1; i++)
        {
            var aux = transform.GetChild(i);
            Gizmos.DrawLine(aux.position, transform.GetChild(i+1).position);
        }
    }
}
