using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dokme : MonoBehaviour
{
    bool In=false;
    bool Out=false;
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag=="in"){
        
                In=true;
                Debug.Log("in");
        }
    }
private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag=="out"){
        
                Out=true;
                Debug.Log("out");

        }
        }
         void Update() {

            if(In&&Out){
                Debug.Log("ssssssssssssssss");
            }
         }
}
        

