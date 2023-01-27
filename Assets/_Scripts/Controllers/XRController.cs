using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using Google.XR.Cardboard;  

public static class XRController 
{
    public static Camera _mainCamera;
    public static float _defaultFieldOfView = 60.0f;

    public static void initialSetup(){
        _mainCamera = Camera.main;

        // Configures the app to not shut down the screen and sets the brightness to maximum.
        // Brightness control is expected to work only in iOS, see:
        // https://docs.unity3d.com/ScriptReference/Screen-brightness.html.
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        // Checks if the device parameters are stored and scans them if not.
        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
    }

    public static bool _isScreenTouched()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }

    public static bool _isVrModeEnabled()
    {
        return XRGeneralSettings.Instance.Manager.isInitializationComplete;
    }

    public static void ExitVR()
    {
        StopXR();
    }

    public static void StopXR()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        Debug.Log("XR stopped.");

        Debug.Log("Deinitializing XR...");
        //XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR deinitialized.");

        //_mainCamera.ResetAspect();
        //_mainCamera.fieldOfView = _defaultFieldOfView;
        Debug.Log("HERE");
    }

    public static void EnterVR()
    {
        StartXR();
        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }
    }

    public static void StartXR()
    {
        XRGeneralSettings.Instance.Manager.StartSubsystems();
        
        /*Debug.Log("Initializing XR...");
        
        //yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("XR started.");    
        }*/
    }
}
