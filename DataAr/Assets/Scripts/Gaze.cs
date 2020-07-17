using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    List<InfoBehavior> infos = new List<InfoBehavior>();

    // Start is called before the first frame update
    void Start()
    {
        infos = FindObjectsOfType<InfoBehavior>().ToList();   
    }

    // Update is called once per frame
    void Update()
    {
      if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
      {
            GameObject gameObject = hit.collider.gameObject;
            if(gameObject.CompareTag("hasInfo"))
            {
                OpenInfo(gameObject.GetComponent<InfoBehavior>());
            }
            else
            {
                CloseAll();
            }
      }
    }

    void OpenInfo(InfoBehavior desiredInfo)
    {
        foreach(InfoBehavior info in infos)
        {
           if(info == desiredInfo)
            {
                info.OpenInfo();
            }

            else
            {
                info.CloseInfo();
            }
        }
    }

    void CloseAll()
    {
        foreach(InfoBehavior info in infos)
        {
            info.CloseInfo();
        }
    }
}
