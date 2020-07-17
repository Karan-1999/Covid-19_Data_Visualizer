using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    bool sliderState = false;

   public void SlideOpen()
    {
        sliderState =! sliderState;
        GetComponent<Animator>().SetBool("Open", sliderState);
    }
}
