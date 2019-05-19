using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningApiText : MonoBehaviour
{
    Color textColor;
    Animator animator;
    void Start()
    {
        textColor = gameObject.GetComponent<Text>().color;
        animator = gameObject.GetComponent<Animator>();
    }

    public void HideWarning()
    {
        textColor.a = 0;
        gameObject.GetComponent<Text>().color = textColor;
        animator.enabled = false;
        print("hide me");
    }

    public void ShowWarning()
    {
        textColor.a = 1;
        gameObject.GetComponent<Text>().color = textColor;
        animator.enabled = true;
        print("ahow me");

    }
}
