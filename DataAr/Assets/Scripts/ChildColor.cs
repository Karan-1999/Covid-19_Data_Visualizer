using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColor : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [SerializeField] GameObject child;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        var material = meshRenderer.material;

        child.GetComponent<MeshRenderer>().material = material;

    }
}
