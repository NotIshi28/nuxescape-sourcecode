using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class LightFire : MonoBehaviour
{
    public GameObject ext;
    public GameObject fire;
    public GameObject blocker;
    public bool isExtinguish = false;
    public bool inReach;
    public GameObject ExtinguishText;
    public AudioSource ExtSound;
    void Start(){
        inReach = false;
        ExtinguishText.SetActive(false);
        blocker.SetActive(true);
        fire.SetActive(true);
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Reach" && !isExtinguish && ext.activeInHierarchy)
        {
            inReach = true;
            ExtinguishText.SetActive(true);
        }

        else if (other.gameObject.tag == "Reach" && isExtinguish )
        {
            inReach = true;
            ExtinguishText.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            ExtinguishText.SetActive(false);
        }
    }

    void Update(){
        if (!isExtinguish && inReach && Input.GetButtonDown("Interact")&& ext.activeInHierarchy)
        {
            isExtinguish = true;
            ExtinguishText.SetActive(false);
            inReach = false;
            ExtSound.Play();
            Invoke("disablefire", 2f);
        }

        else if (isExtinguish)
        {
            ExtinguishText.SetActive(false);
        }
    }

    void disablefire(){
        blocker.SetActive(false);
        fire.SetActive(false);
    }
}
