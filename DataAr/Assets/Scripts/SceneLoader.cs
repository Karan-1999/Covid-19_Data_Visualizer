using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    

    private void Update()
    {

        Ray mousePostion = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(mousePostion, out hit))
            {
                if (hit.transform.tag == "India")
                {
                    SceneManager.LoadScene(1);
                }
                else if(hit.transform.tag == "SouthAmerica")
                {
                    SceneManager.LoadScene(2);
                }
                else if (hit.transform.tag == "NorthAmerica")
                {
                    SceneManager.LoadScene(3);
                }
                else if (hit.transform.tag == "Europe")
                {
                    SceneManager.LoadScene(4);
                }
                else if (hit.transform.tag == "Australia")
                {
                    SceneManager.LoadScene(5);
                }
                else if (hit.transform.tag == "Asia")
                {
                    SceneManager.LoadScene(6);
                }
                else if (hit.transform.tag == "Africa")
                {
                    SceneManager.LoadScene(7);
                }
            }
        }
    }



    public void LoadWorldScene()
    {
        SceneManager.LoadScene(0);
    }

    public void HowToUse()
    {
        SceneManager.LoadScene(8);
    }
}
