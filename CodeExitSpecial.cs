using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeExitSpecial : MonoBehaviour
{
    public GameObject door;
    public GameObject codeUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!door.activeInHierarchy){
            codeUI.SetActive(false);
        }
    }
}
