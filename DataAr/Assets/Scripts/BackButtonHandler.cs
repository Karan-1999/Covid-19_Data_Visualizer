using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonHandler : MonoBehaviour
{
    [SerializeField] Button backButton;
    public void ButtonDisapperEvent()
    {
        backButton.gameObject.SetActive(false);
    }

    public void ButtonApperEvent()
    {
        backButton.gameObject.SetActive(true);
    }
}
