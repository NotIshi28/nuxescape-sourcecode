using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherController : MonoBehaviour
{
    public GameObject Keypad;
    public GameObject ext;

    // Start is called before the first frame update
    void Start()
    {
        ext.SetActive(false);
    }
}
