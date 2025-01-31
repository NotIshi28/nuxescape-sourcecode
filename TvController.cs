using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour
{

    public GameObject TvScreen;
    public GameObject ant;
    public GameObject note;

    // Start is called before the first frame update
    void Start()
    {
     TvScreen.SetActive(false);  
     note.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
     if(!ant.activeInHierarchy)   {
        TvScreen.SetActive(false);
        note.SetActive(false);
     }
     else if(ant.activeInHierarchy){
        TvScreen.SetActive(true);
        note.SetActive(true);
     }
    }
}
