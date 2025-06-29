using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(readsss());

        transform.position += new Vector3(0,0.1f,0);
    }


IEnumerator readsss(){

        while(true){
        string salam=Console.ReadLine();
        

        }

}


}
