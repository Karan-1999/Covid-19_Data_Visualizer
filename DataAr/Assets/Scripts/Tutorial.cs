using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Image[] images;
    int currentValue = 0;
    // Start is called before the first frame update
    void Start()
    {
      foreach(Image image in images)
        {
            image.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < images.Length; i++)
        {
            if(i == currentValue)
            {
                images[i].enabled = true;
            }
            else
            {
                images[i].enabled = false;
            }
        }
    }

    public void NextButton()
    {
        currentValue++;
        if(currentValue >= images.Length)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PrevoiusButton()
    {
        if (currentValue <= 0)
        {
            currentValue = 0;
        }
        else
        {
            currentValue--;
        } 
    }
}
