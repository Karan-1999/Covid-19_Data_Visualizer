using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Raycast : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject objectPrefab;
    public Camera rayCastCamera;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();


    void Update()
    {
        if(raycastManager == null)
        {
            return;
        }

        if(rayCastCamera == null)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0) && !IsClickOverUI())
        {
            Ray ray = rayCastCamera.ScreenPointToRay(Input.mousePosition);
            if(raycastManager.Raycast(ray, hits, TrackableType.Planes))
            {
                Pose pose = hits[0].pose;

                if (FindObjectOfType<ToggleAR>().isOn)
                {
                    objectPrefab.transform.SetPositionAndRotation(pose.position, pose.rotation);
                }
            }
        }
    }

    bool IsClickOverUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);
        for (int i = 0; i < raycastResults.Count; i++)
        {
            if (raycastResults[i].gameObject.GetComponent<MouseOverClickThrough>() != null)
            {
                raycastResults.RemoveAt(i);
                i--;
            }
        }

        return raycastResults.Count > 0;
    }
}
