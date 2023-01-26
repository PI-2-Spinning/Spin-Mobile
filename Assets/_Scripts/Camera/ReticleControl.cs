using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleControl : MonoBehaviour {

    public Camera mainCamera; // adicione essa linha
    private Transform reticleTransform;

    void Start() {
        reticleTransform = GetComponent<Transform>();
        reticleTransform.position = mainCamera.transform.position + mainCamera.transform.forward;
    }

    void Update () {
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;
        transform.LookAt(mainCamera.transform);
    }

    public float distance = 2f;
}