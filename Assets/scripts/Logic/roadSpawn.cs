using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;


public class roadSpawn : MonoBehaviour
{
    public GameObject road;
    Vector3 readposition;
    void Start(){
        readposition=road.transform.position;
    }
private void OnTriggerExit(Collider other) {
    if(other.gameObject.CompareTag("Player")){
        readposition+=new Vector3 (0,0,81);
        Instantiate(road,readposition,quaternion.identity);

    }
}
}
