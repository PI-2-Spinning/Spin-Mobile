using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 0f;
    public Transform route;
    public Vector3 CenterOfMass2;
    private float threshold = 1f;

    private Rigidbody rb;
    Vector3 m_EulerAngle;
    Vector3 newPosition;

    bool inRoute;
    int i = 1;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        m_EulerAngle = new Vector3(0f, 1f, 0f);
        inRoute = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.centerOfMass = CenterOfMass2;
        if (inRoute)
        {
            MovePlayer();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position + transform.rotation * CenterOfMass2, 0.1f);
    }

    void MovePlayer()
    {
        var target = route.GetChild(i);
        float targetDistance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(target.position.x, target.position.z));
        if (targetDistance > threshold)
        {
            // move to target
            float target_relative_x = target.position.x - transform.position.x;
            float target_relative_z = target.position.z - transform.position.z;
            float tot = Mathf.Abs(target_relative_x) + Mathf.Abs(target_relative_z);
            newPosition = new Vector3(target_relative_x / tot, 0f, target_relative_z / tot);
            rb.MovePosition(transform.position + newPosition * speed * Time.fixedDeltaTime);

            // rotate to target
            Vector3 relative = transform.InverseTransformPoint(target.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngle * angle * (speed/10f) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        else if (i == route.childCount - 1)
        {
            inRoute = false;
        }
        else
        {
            i += 1;
        }
    }
}
