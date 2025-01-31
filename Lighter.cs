using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    public GameObject lighter;
    public GameObject flames;

    public GameObject pointLight;
    public float delay;

    public AudioSource lighterSound;

    public bool isOn;



    void Start()
    {
        isOn = false;
        flames.SetActive(false);
        pointLight.SetActive(false);
    }




    void Update()
    {
        if(Input.GetButtonDown("Fire1") && lighter.activeInHierarchy)
        {
            flames.SetActive(true);
            pointLight.SetActive(false);
            lighterSound.Play();
            isOn = true;
            Invoke("PointLightOn", delay);
        }

        else if(Input.GetButtonDown("Fire1") && isOn)
        {
            return;
        }

        if (Input.GetButtonDown("Fire2") && lighter.activeInHierarchy && isOn)
        {
            flames.SetActive(false);
            pointLight.SetActive(false);
            isOn = false;
        }



    }

    void PointLightOn(){
        pointLight.SetActive(true);
    }
}