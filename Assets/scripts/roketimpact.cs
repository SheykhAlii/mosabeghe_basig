using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class roketimpact : MonoBehaviour
{

    public GameObject expelod;
    public AudioSource expelosivsond;

    private void Start()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "tank")
        {
            other.transform.position += new Vector3(0,-50,0);
            //Destroy(other.gameObject);
            impact();

        }

        GameObject ex = Instantiate(expelod, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
        Destroy(gameObject);


    }

    void impact()
    {

    }
}
