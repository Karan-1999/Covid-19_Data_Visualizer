using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpin : MonoBehaviour
{

    [SerializeField] int rotationSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetAxis("Mouse X") < 0)
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
        }
        
    }
}
