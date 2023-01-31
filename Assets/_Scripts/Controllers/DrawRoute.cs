using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRoute : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        int i = 0;
        while(true)
        {
            var aux = transform.GetChild(i);
            i += 1;
            if (aux.name == "p_start")
            {
                continue;
            }
            if (aux.name == "p_end")
            {
                break;
            }

            Gizmos.DrawLine(aux.position, transform.GetChild(i).position);
        }
    }
}
