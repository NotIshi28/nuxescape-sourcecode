using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject OB;

    public GameObject invOB;
    
    public GameObject openText;
    
    public GameObject pickUpText;
    
    public AudioSource pickUpSound;

    public GameObject gunObj;

    public GameObject knifeObj;

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
            inv = inv.GetComponent<InventorySwitch>();
            if(OB.gameObject.tag == "glock"){
                inv.has1 = true;
                OB.SetActive(false);
            }

            else if(OB.gameObject.tag == "knife"){
                inv.has2 = true;
                OB.SetActive(false);
                gunObj.SetActive(false);            
            }

            else if(OB.gameObject.tag == "lighter"){
                gunObj.SetActive(false);
                inv.has3 = true;
                knifeObj.SetActive(false);
                OB.SetActive(false);
            }

            OB.SetActive(false);
            pickUpSound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
        }

        
    }
}