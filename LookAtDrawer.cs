using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookAtDrawer : MonoBehaviour
{
    public GameObject textOBMis;
    public GameObject PlaceText;
    public GameObject scr;
    public bool isFixed;
    public bool inReach;


    void Start()
    {
        textOBMis.SetActive(false);
        PlaceText.SetActive(false);
        isFixed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            textOBMis.SetActive(true);
            PlaceText.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            PlaceText.SetActive(false);
            textOBMis.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && !scr.activeInHierarchy && !isFixed)
        {
            textOBMis.SetActive(true);
            PlaceText.SetActive(false);
        }   

        else if(inReach && scr.activeInHierarchy){
            textOBMis.SetActive(false);
            if(!isFixed){
                PlaceText.SetActive(true);
            }
            if(Input.GetButtonDown("Interact") ){
                PlaceText.SetActive(false);
                isFixed = true;
            }
        }

        
    }
}
