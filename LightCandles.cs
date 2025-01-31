using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandles : MonoBehaviour
{
    public GameObject lighterOB;
    public GameObject flame;
    public GameObject lightText;

    public GameObject pointLight;
    public float delay;

    public bool unlit;
    public bool inReach;

    public GameObject cube;
    public bool lit;


    void Start()
    {
        cube.SetActive(false);
        lit = false;
        unlit = true;
        flame.SetActive(false);
        pointLight.SetActive(false);
        lightText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && unlit)
        {
            inReach = true;
            lightText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach" && unlit)
        {
            inReach = false;
            lightText.SetActive(false);
        }
    }

    void Update()
    {
        if(lighterOB.activeInHierarchy && inReach && unlit && Input.GetButtonDown("Interact"))
        {
            flame.SetActive(true);
            pointLight.SetActive(false);
            lightText.SetActive(false);
            unlit = false;
            Invoke("PointLightOn", delay);
        }

    }

    void PointLightOn(){
        pointLight.SetActive(true);
        lit = true;
        cube.SetActive(true);
    }
}