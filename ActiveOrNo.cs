using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOrNo : MonoBehaviour
{

    public GameObject keypad;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(keypad.activeInHierarchy) gameObject.SetActive(false);
        else if(!keypad.activeInHierarchy) gameObject.SetActive(true);
    }
}
