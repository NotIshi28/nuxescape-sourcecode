using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // public GameObject 
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Reach")
        {
            SceneManager.LoadScene("attic");
        }
    }


}
