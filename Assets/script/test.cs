using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour




{

public int xx;
public int yy;
public int zz;
Vector3 ofset;
    // Start is called before the first frame update
    void Start()
    {
        ofset=transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (xx,yy,zz);
    }
}
