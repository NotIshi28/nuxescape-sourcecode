using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject OriginalOB;
    public GameObject ChangeOB;
    public Animator ANI;
    
    public float health = 100f;

    public bool animate;
    public bool replace;
    public bool destroy;


    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f && animate)
        {
            Animate();
        }

        if (health <= 0f && replace)
        {
            Replace();
        }

        if (health <= 0f && destroy)
        {
            Destroy();
        }

        if(OriginalOB.tag == "chest"){
            changeBool();
        }
    }

    void Animate()
    {
        ANI.SetBool("open", true);
    }


    void Replace()
    {
        OriginalOB.SetActive(false);
        ChangeOB.SetActive(true);
    }


    void Destroy()
    {
        Destroy(gameObject);
    }

    void changeBool(){
        OriginalOB.GetComponent<OpenBoxScript>().isOpen = true;
        OriginalOB.GetComponent<OpenBoxScript>().boxOB.SetBool("open", true);
    }

}