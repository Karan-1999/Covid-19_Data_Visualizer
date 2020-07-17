using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Lean.Touch;
using System;

public class ToggleAR : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public ARPointCloudManager pointCloudManager;
    public bool isOn = true;

    [SerializeField] LeanTwistRotateAxis rotationAxis;
    [SerializeField] LeanPinchScale pinchScale;
    


    private void Start()
    {
        VisualizePlanes(isOn);
        VisualizePoints(isOn);
        EnableDisableRotationScale(isOn);
    }

    public void OnValueChanged()
    {
        isOn =! isOn;  // toggle
        VisualizePlanes(isOn);
        VisualizePoints(isOn);
        EnableDisableRotationScale(isOn);
    }

    void VisualizePlanes(bool active)
    {
        planeManager.enabled = active;
        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(active);
        }
    }

    void VisualizePoints(bool active)
    {
        pointCloudManager.enabled = active;
        foreach (ARPointCloud pointCLoud in pointCloudManager.trackables)
        {
            pointCLoud.gameObject.SetActive(active);
        }
    }

    private void EnableDisableRotationScale(bool active)
    {
        rotationAxis.enabled = !active;
        pinchScale.enabled = !active;
    }
}
