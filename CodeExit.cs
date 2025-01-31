using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeExit : MonoBehaviour
{
    public GameObject fireext;
    public GameObject codeUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fireext.activeInHierarchy){
            codeUI.SetActive(false);
        }
    }
}
