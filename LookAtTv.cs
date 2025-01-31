using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookAtTv : MonoBehaviour
{
    public GameObject textOBMis;
    public GameObject PlaceText;
    public GameObject antOnTv;
    public GameObject ant;

    public bool inReach;


    void Start()
    {
        textOBMis.SetActive(false);
        antOnTv.SetActive(false);
        PlaceText.SetActive(false);
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
        if (inReach && !ant.activeInHierarchy)
        {
            textOBMis.SetActive(true);
            antOnTv.SetActive(false);
            PlaceText.SetActive(false);
        }   

        else if(inReach && ant.activeInHierarchy){
            textOBMis.SetActive(false);
            if(!antOnTv.activeInHierarchy){
                PlaceText.SetActive(true);
            }
            if(Input.GetButtonDown("Interact") ){
                antOnTv.SetActive(true);
                PlaceText.SetActive(false);
            }
        }

        
    }
}
