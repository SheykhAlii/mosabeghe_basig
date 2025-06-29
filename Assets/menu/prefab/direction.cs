using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class direction : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] Transform move;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
      transform.position=Vector3.MoveTowards(transform.position,move.position,5f*Time.deltaTime);
      print(rb.velocity);  
    }
}
