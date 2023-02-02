using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    BluetoothService btService;

    private float playerWeight, bicycleRim, angle, g = 9.807f;

    void Start()
    {       
        btService = GeneralController.controllerInstance.getBtService();
        playerWeight = (GeneralController.controllerInstance.getUserData().getWeight() + 12f) * g;
        bicycleRim = GeneralController.controllerInstance.getUserData().getRim();

        InvokeRepeating("updateSimulatingRegistry", .01f, 1f);
        
        Debug.Log("Player context done!");
    }    

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        #else
        
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
            if(GeneralController.controllerInstance.getState().stateName != "Simulating"){
                try{
                    
                    float resistencia = playerWeight * (float) Math.Sin(angle) + 0.65f * playerWeight * (float) Math.Cos(angle);
                    resistencia = (resistencia * -100)/1040;
                    resistencia = (resistencia > 100) ? 100 : resistencia;
                    resistencia = (resistencia < 0) ? 0 : resistencia;
                    btService.WritetoBluetooth(resistencia.ToString() + "\n");
                
                    string dataIn = btService.ReadFromBluetooth();
                    if (dataIn.Length > 0){
                        Debug.Log(dataIn);                    
                        float rpmRolamento = float.Parse(dataIn.Substring(6));

                        float rpmPneu = (0.025f/bicycleRim) * rpmRolamento;
                        Debug.Log("RPM Pneu: " + rpmPneu);

                        speed =  2f * 3.6f * (float) Math.PI * bicycleRim * rpmPneu / 60f;
                        speed = (speed < 0) ? 0 : speed;

                        Debug.Log("km/h: " + speed);

                        transform.Translate(Vector3.forward * speed / 3.6f * Time.deltaTime);
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
        #endif
    }

    void updateSimulatingRegistry() {
        State state = GeneralController.controllerInstance.getState();
        Simulating stateSimulating = (Simulating)state;

        stateSimulating.updateRegistry(speed);
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        angle = Vector3.Angle(Vector3.up, hit.normal); //Calc angle between normal and character
    }
}
