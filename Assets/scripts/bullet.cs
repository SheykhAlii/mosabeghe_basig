using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
private void OnCollisionEnter(Collision other) {
    if (other.gameObject.tag == "enemy"){
    Destroy(other.gameObject);

    }
    Destroy(gameObject);
    

    

}}
