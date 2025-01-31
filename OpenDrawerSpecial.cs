using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawerSpecial : MonoBehaviour
{
    public Animator ANI;

    public GameObject openText;
    public GameObject closedText;

    public AudioSource openSound;
    public AudioSource closeSound;

    private bool open;

    private bool inReach;

    public int randomNumber;
    public GameObject loot1;
    public GameObject loot2;
    public GameObject loot3;

    public GameObject drawer;
    public bool fix;

    void Start()
    {

        randomNumber = UnityEngine.Random.Range(0, 2);

        Debug.Log(randomNumber);

        openText.SetActive(false);
        closedText.SetActive(false);

        loot1.SetActive(false);
        loot2.SetActive(false);
        loot3.SetActive(false);

        ANI.SetBool("open", false);
        ANI.SetBool("close", false);

        open = false;

    }

    void OnTriggerEnter(Collider other)
    {

        if(!loot1.activeInHierarchy || !loot2.activeInHierarchy || !loot3.activeInHierarchy){
            if(randomNumber == 0){
                loot1.SetActive(true);
            }

            if(randomNumber == 1){
                loot2.SetActive(true);
            }

            if(randomNumber == 2){
                loot3.SetActive(true);
            }
        }
        fix = drawer.GetComponent<LookAtDrawer>().isFixed;
        if (other.gameObject.tag == "Reach" && !open && fix == true)
        {
            inReach = true;
            openText.SetActive(true);
            closedText.SetActive(false);
        }

        else if (other.gameObject.tag == "Reach" && !open && fix == false)
        {
            inReach = true;
            openText.SetActive(false);
            closedText.SetActive(false);
        }

        else if (other.gameObject.tag == "Reach" && open && fix == true)
        {
            inReach = true;
            closedText.SetActive(true);
            openText.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            closedText.SetActive(false);
        }
    }



    void Update()
    {
        if (!open && inReach && Input.GetButtonDown("Interact"))
        {
            openSound.Play();
            ANI.SetBool("open", true);
            ANI.SetBool("close", false);
            open = true;
            openText.SetActive(false);
            inReach = false;
        }

        else if (open && inReach && Input.GetButtonDown("Interact"))
        {
            closeSound.Play();
            ANI.SetBool("open", false);
            ANI.SetBool("close", true);
            open = false;
            closedText.SetActive(false);
            inReach = false;
        }

    }
}