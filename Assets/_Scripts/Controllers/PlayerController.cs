using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    BluetoothService btService;

    private float playerWeight, bicycleRim, angle, g = 9.807f;
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
        btService = GeneralController.controllerInstance.getBtService();
        playerWeight = (GeneralController.controllerInstance.getUserData().getWeight() + 12f) * g;
        bicycleRim = GeneralController.controllerInstance.getUserData().getRim();
        rb = GetComponent<Rigidbody>();
        m_EulerAngle = new Vector3(0f, 1f, 0f);
        inRoute = true;

        Debug.Log("Player context done!");
    }  

    // Update is called once per frame
    void FixedUpdate(){
        rb.centerOfMass = CenterOfMass2;

        if (XRController._isVrModeEnabled())
        {
            if (Api.IsCloseButtonPressed)
            {
                XRController.ExitVR();
                Application.Quit();
            }

            Api.UpdateScreenParams();
        }
        
        if (GeneralController.controllerInstance.isConnected)
        {
            if(GeneralController.controllerInstance.getState().stateName == "Simulating"){
                try{
                    float resistencia = playerWeight * (int) Math.Sin(angle) + 0.65f * playerWeight * (float) Math.Cos(angle);
                    resistencia = (resistencia * -100)/1040;
                    resistencia = (resistencia > 100) ? 100 : resistencia;
                    resistencia = (resistencia < 0) ? 0 : resistencia;

                    int resistenciaI = (int) resistencia;
                    Debug.Log(resistencia + "  " + resistenciaI);
                    btService.WritetoBluetooth(resistenciaI.ToString() + "\n");

                    string dataIn = btService.ReadFromBluetooth();
                    if (dataIn.Length > 0){
                        Debug.Log(dataIn);                    
                        float rpmRolamento = float.Parse(dataIn.Substring(6));

                        float rpmPneu = (0.025f/bicycleRim) * rpmRolamento;
                        Debug.Log("RPM Pneu: " + rpmPneu);

                        speed =  2f * 3.6f * (float) Math.PI * bicycleRim * rpmPneu / 60f;
                        speed = (speed < 0) ? 0 : speed;

                        Debug.Log("km/h: " + speed);
                    }

                    // transform.Translate(Vector3.forward * speed / 3.6f * Time.deltaTime);
                    if (inRoute)
                    {
                        MovePlayer();
                    }
                }
                catch (Exception e){ Debug.LogException(e); }
            }
        }
        else
        {
            //Debug.Log("Connecting...");
            GeneralController.controllerInstance.doConnect();
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
            Vector3 relative;
            if (targetDistance < threshold + 10 && i < route.childCount - 1)
            {
                relative = transform.InverseTransformPoint(route.GetChild(i+1).position);
            }
            else
            {
                relative = transform.InverseTransformPoint(target.position);
            }
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

    void OnControllerColliderHit(ControllerColliderHit hit) {
        angle = Vector3.Angle(Vector3.up, hit.normal); //Calc angle between normal and character
    }
}
