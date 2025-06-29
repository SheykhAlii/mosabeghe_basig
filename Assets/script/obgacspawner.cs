using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obgacspawner : MonoBehaviour
{


    GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Instantiate(cube,transform.position,Quaternion.identity);
        cube.transform.SetPositionAndRotation(new Vector3(0,0,0),Quaternion.EulerAngles(0f,0f,0f));
    }
}
