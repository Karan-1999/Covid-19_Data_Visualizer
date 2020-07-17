using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    private bool menuOpen = false;

    public void MenuStatues()
    {
        menuOpen = !menuOpen;
        GetComponent<Animator>().SetBool("clicked", menuOpen);
    }
}
