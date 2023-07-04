using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    [Header("Lista de Cinematicas")]
    [SerializeField] private GameObject[] cinematics;
    [Header("Controlador de Escena")]
    public IntVariable SceneNumber;
    void Awake()
    {
        for (int i = 0; i < cinematics.Length; i++)
        {
            cinematics[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Selector(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Selector(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Selector(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Selector(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Selector(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Selector(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Selector(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Selector(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Selector(9);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0) && Input.GetKeyDown(KeyCode.Alpha0))
        {
            Selector(10);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Selector(12);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Selector(13);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Selector(14);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Selector(15);
        }
    }

    public void Selector(int number)
    {
        switch (number)
        {
            case 1:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 2:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 3:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 4:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 5:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 6:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 7:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 8:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 9:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 10:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 11:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 12:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 13:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 14:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
            case 15:
                cinematics[number-1].gameObject.SetActive(true);
                SceneNumber.Value = number;
                break;
        }
    }
    
    


}
