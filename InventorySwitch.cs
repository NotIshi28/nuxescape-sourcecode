using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public GameObject object01;
    public GameObject object02;
    public GameObject object03;

    public bool has1;
    public bool has2;
    public bool has3;

    public bool hasKey;

    void Start()
    {
        object01.SetActive(false);
        object02.SetActive(false);
        object03.SetActive(false);

        has1 = false;
        has2 = false;
        has3 = false;
    }




    void Update()
    {
        if(Input.GetButtonDown("1"))
        {
            object01.SetActive(false);
            object02.SetActive(false);
            object03.SetActive(false);
        }

        if (Input.GetButtonDown("2") && has1)
        {
            object01.SetActive(true);
            object02.SetActive(false);
            object03.SetActive(false);
        }

        if (Input.GetButtonDown("3") && has2)
        {
            object01.SetActive(false);
            object02.SetActive(true);
            object03.SetActive(false);
        }

        if (Input.GetButtonDown("4") && has3)
        {
            object01.SetActive(false);
            object02.SetActive(false);
            object03.SetActive(true);
        }


    }
}