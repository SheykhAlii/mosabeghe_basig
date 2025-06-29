using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class roadDespawn : MonoBehaviour
{
    public GameObject road;


private void OnTriggerExit(Collider other) {
    
    if(other.gameObject.CompareTag("Player")){
        Debug.Log("exite");
        Destroy(road);
        
    }
}
}
