using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnIndiaClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnAsiaClicked()
    {
        SceneManager.LoadScene(6);
    }

    public void OnAfricaClicked()
    {
        SceneManager.LoadScene(7);
    }

    public void OnEuropeClicked()
    {
        SceneManager.LoadScene(4);
    }

    public void OnNorthAClicked()
    {
        SceneManager.LoadScene(3);
    }

    public void OnSouthAClicked()
    {
        SceneManager.LoadScene(2);
    }

    public void OnAutraliaClicked()
    {
        SceneManager.LoadScene(5);
    }
}
