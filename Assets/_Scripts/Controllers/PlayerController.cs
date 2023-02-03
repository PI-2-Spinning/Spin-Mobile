using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private TextMeshProUGUI currentSpeed;
    [SerializeField] private TextMeshProUGUI currentTime;
    [SerializeField] private TextMeshProUGUI currentRPM;
    [SerializeField] private TextMeshProUGUI averageSpeed;
    [SerializeField] private TextMeshProUGUI totalTime;
    [SerializeField] private TextMeshProUGUI totalDistance;
    [SerializeField] private TextMeshProUGUI maxSpeed;
    [SerializeField] private GameObject inGameTablet;
    [SerializeField] private GameObject endGameTablet;

    BluetoothService btService;

    private float playerWeight, bicycleRim, angle, g = 9.807f;
    public float speed = 0f;
    public float timer = 0.0f;
    public Transform route;
    public Transform backWheel;
    public Transform frontWheel;
    public Vector3 CenterOfMass2;
    private float threshold = 1f;

    private Rigidbody rb;
    Vector3 m_EulerAngle;
    Vector3 newPosition;

    float maxAngle = 0f;

    bool inRoute;
    int i = 1;

    Simulating simState;

    void Start() {
        #if !UNITY_EDITOR
        btService = GeneralController.controllerInstance.getBtService();
        playerWeight = (GeneralController.controllerInstance.getUserData().getWeight() + 12f) * g;
        bicycleRim = GeneralController.controllerInstance.getUserData().getRim();
        #endif

        #if UNITY_EDITOR
        playerWeight = 80;
        bicycleRim = 0.622f;
        simState = new Simulating();
        #endif

        rb = GetComponent<Rigidbody>();
        m_EulerAngle = new Vector3(0f, 1f, 0f);
        inRoute = true;
        
        InvokeRepeating("updateSimulatingRegistry", .01f, 1f);
        
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
             if(GeneralController.controllerInstance.getState().stateName == "Simulating")
             {
                 try{
                     // float resistencia = playerWeight * (int) Math.Sin(angle) + 0.65f * playerWeight * (float) Math.Cos(angle);
                     // resistencia = (resistencia * 100)/117;
                     float resistencia = angle/27 * playerWeight * 2.5f;
                     resistencia = (resistencia > 100) ? 100 : resistencia;
                     resistencia = (resistencia < 0) ? 0 : resistencia;

                     int resistenciaI = (int) resistencia;
                     Debug.Log("Resistencia: " + resistencia + "  " + resistenciaI);
                     btService.WritetoBluetooth(resistenciaI.ToString() + "\n");

                     string dataIn = btService.ReadFromBluetooth();
                     if (dataIn.Length > 0){
                         Debug.Log(dataIn);                    
                         float rpmRolamento = float.Parse(dataIn.Substring(6));

                         float rpmPneu = (0.025f/bicycleRim) * rpmRolamento;

                         currentRPM.text = rpmPneu.ToString("0");
                         
                         Debug.Log("RPM Pneu: " + rpmPneu);

                         speed =  2f * 3.6f * (float) Math.PI * bicycleRim * rpmPneu / 60f;
                         speed = (speed < 0) ? 0 : speed;

                         currentSpeed.text = speed.ToString("0.00") + " Km/h";

                         Debug.Log("km/h: " + speed);
                     }

                     if (inRoute)
                     {
                        float oposto = frontWheel.position.y - backWheel.position.y;
                        float adj = 2.1f;
                        angle =  Mathf.Atan2(oposto, adj) * Mathf.Rad2Deg;
                        Debug.Log(angle);

                        timer += Time.deltaTime;
                        TimeSpan timespan = TimeSpan.FromSeconds(timer);
                        int minutes = timespan.Minutes;
                        int sec = timespan.Seconds;
                        currentTime.text = minutes.ToString("00") + ":" + sec.ToString("00") + " m";
                        totalTime.text = minutes.ToString("00") + ":" + sec.ToString("00") + " m";
                        averageSpeed.text = simState.registry.getAverageSpeed().ToString("0.00") + " Km/h";
                        totalDistance.text = simState.registry.getTravelledDistance().ToString("0.00") + " Km";
                        maxSpeed.text = simState.registry.getMaxSpeed().ToString("0.00") + " Km/h";

                        Debug.Log("tempo: " + minutes);

                        inGameTablet.SetActive(true);
                        for (int i = 0; i < inGameTablet.transform.childCount; i++){
                            var child = inGameTablet.transform.GetChild(i).gameObject;
                            child.SetActive(true);
                            if (child != null){
                                for (int j = 0; j < child.transform.childCount; j++){
                                    var childOfChild = child.transform.GetChild(j).gameObject;
                                    childOfChild.SetActive(true);
                                }
                            }
                        }

                        endGameTablet.SetActive(false);
                        for (int i = 0; i < endGameTablet.transform.childCount; i++){
                            var child = endGameTablet.transform.GetChild(i).gameObject;
                            child.SetActive(false);
                            if (child != null){
                                for (int j = 0; j < child.transform.childCount; j++){
                                    var childOfChild = child.transform.GetChild(j).gameObject;
                                    childOfChild.SetActive(false);
                                }
                            }
                        }
                        MovePlayer();
                     }else{
                        inGameTablet.SetActive(false);
                        for (int i = 0; i < inGameTablet.transform.childCount; i++){
                            var child = inGameTablet.transform.GetChild(i).gameObject;
                            child.SetActive(false);
                            if (child != null){
                                for (int j = 0; j < child.transform.childCount; j++){
                                    var childOfChild = child.transform.GetChild(j).gameObject;
                                    childOfChild.SetActive(false);
                                }
                            }
                        }

                        endGameTablet.SetActive(true);
                        for (int i = 0; i < endGameTablet.transform.childCount; i++){
                            var child = endGameTablet.transform.GetChild(i).gameObject;
                            child.SetActive(true);
                            if (child != null){
                                for (int j = 0; j < child.transform.childCount; j++){
                                    var childOfChild = child.transform.GetChild(j).gameObject;
                                    childOfChild.SetActive(true);
                                }
                            }
                        }
                     }

                       //transform.Translate(Vector3.forward * speed / 3.6f * Time.deltaTime);                   
                 }
                 catch (Exception e){ Debug.LogException(e); }
            }
        }
        else
        {
            Debug.Log("Connecting...");
            GeneralController.controllerInstance.doConnect();
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position + transform.rotation * CenterOfMass2, 0.1f);
    }*/

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

    public void updateSimulatingRegistry() {
        State state = GeneralController.controllerInstance.getState();
         simState = (Simulating)state;

        simState.updateRegistry(speed, timer);
    }
}
