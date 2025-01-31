using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAntennae : MonoBehaviour
{
    public GameObject drawer;
    
    public GameObject OB;

    public GameObject invOB;
    
    public GameObject openText;
    
    public GameObject pickUpText;
    
    public GameObject brokenText;

    public AudioSource pickUpSound;

    public GameObject gunObj;

    public GameObject knifeObj;

    public InventorySwitch inv;

    public bool inReach;

    public bool fix;
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        brokenText.SetActive(false);
        invOB.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        fix = drawer.GetComponent<LookAtDrawer>().isFixed;

        if (other.gameObject.tag == "Reach" && !openText.activeInHierarchy && fix)
        {
            inReach = true;
            pickUpText.SetActive(true);
            brokenText.SetActive(true);

        }

        else if (other.gameObject.tag == "Reach" && openText.activeInHierarchy)
        {
            inReach = false;
            pickUpText.SetActive(false);
            brokenText.SetActive(false);

        }
    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
            brokenText.SetActive(false);

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