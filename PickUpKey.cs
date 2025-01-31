using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject keyOB;

    public GameObject invOB;
    
    public GameObject openText;
    
    public GameObject pickUpText;
    public AudioSource keySound;

    public InventorySwitch inv;

    public bool inReach;


    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && !openText.activeInHierarchy)
        {
            inReach = true;
            pickUpText.SetActive(true);

        }

        else if (other.gameObject.tag == "Reach" && openText.activeInHierarchy)
        {
            inReach = false;
            pickUpText.SetActive(false);

        }
    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);

        }
    }


    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            keyOB.SetActive(false);
            keySound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
        }

        
    }
}