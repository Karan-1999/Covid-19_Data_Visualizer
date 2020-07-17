using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    bool expanded = false;
   public void OnRangeIndicatorClicked()
   {
        expanded = !expanded; //toggel
        GetComponentInChildren<Animator>().SetBool("expand", expanded);
   }
}
