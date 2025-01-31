using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiveOrRead : MonoBehaviour
{
    public GameObject obj;
    public GameObject text;
    public bool inReach;
    public AudioSource sound;
    public bool backScene1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            text.SetActive(true);
        }

        else if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            text.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            text.SetActive(false);
        }
    }
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            text.SetActive(false);
            inReach = false;
            sound.Play();
            Invoke("teleport", 4f);
        }
    }

    void teleport(){
        if(backScene1){
            SceneManager.LoadScene("scene1");
        }
        else{
            SceneManager.LoadScene("end");
        }
    }
}
