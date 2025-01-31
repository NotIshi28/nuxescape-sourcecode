// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FireExit : MonoBehaviour
// {
//     public GameObject fire;
//     public bool inReach;

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     void OnTriggerEnter(Collider other){
//         if (other.gameObject.tag == "Reach" && fire.activeInHierarchy)
//         {
//             inReach = true;
//             openText.SetActive(true);
//         }

//         if (other.gameObject.tag == "Reach" && !fire.activeInHierarchy)
//         {
//             inReach = true;
//             closeText.SetActive(true);
//         }
//     }

//     void OnTriggerExit(Collider other){

//     }
// }
