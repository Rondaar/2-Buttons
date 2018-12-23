using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour 
{

    [SerializeField]
    Button[] buttons;

    public void DisableButtons() 
    { 
        foreach (Button button in buttons)
        {
            if(!button.GetComponent<ChooseAnimation>().IsPlaying)
            {
                button.GetComponent<FadeAnimation>().StartAnimation();
            }
            button.interactable = false;
        }
    }

    public void DisplayMenu()
    {
        foreach (Button button in buttons)
        {
            button.GetComponent<SlideInAnimation>().StartAnimation();
        }
    }
}
