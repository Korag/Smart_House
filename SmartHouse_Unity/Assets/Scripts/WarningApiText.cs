using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningApiText : MonoBehaviour
{

    void Start()
    {
    }

    public void HideWarning()
    {
        gameObject.SetActive(false);
        print("hide me");

    }

    public void ShowWarning()
    {
        gameObject.SetActive(true);
    }
}
