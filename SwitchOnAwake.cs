using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchOnAwake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("change", 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void change(){
        SceneManager.LoadScene("s");
    }
}
