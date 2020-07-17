using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GazeOther : MonoBehaviour
{
    List<InfoBehaviourOther> infos = new List<InfoBehaviourOther>();
    // Start is called before the first frame update
    void Start()
    {
        infos = FindObjectsOfType<InfoBehaviourOther>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject gameObject = hit.collider.gameObject;
            if (gameObject.CompareTag("hasInfo"))
            {
                OpenInfo(gameObject.GetComponent<InfoBehaviourOther>());
            }
            else
            {
                CloseAll();
            }
        }
    }

    void OpenInfo(InfoBehaviourOther desiredInfo)
    {
        foreach (InfoBehaviourOther info in infos)
        {
            if (info == desiredInfo)
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
        foreach (InfoBehaviourOther info in infos)
        {
            info.CloseInfo();
        }
    }
}
