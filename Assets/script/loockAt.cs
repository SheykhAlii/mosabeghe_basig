using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loockAt : MonoBehaviour
{

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(target.position.x,target.position.y,transform.position.z));
    }
}
