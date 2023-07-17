using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITextUpdater : MonoBehaviour
{
    [Header("Controller")]
   
    [SerializeField] ButtonController buttonController;

    private void Awake()
    {

        buttonController.StatTextUpdate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }
    }
}
