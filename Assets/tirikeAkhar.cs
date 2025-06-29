using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tirikeAkhar : MonoBehaviour
{
    // Start is called before the first frame update
    int i =0;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("tank"))
            {
            i++;
            print("i");

            if (i == 10)
            {
                SceneManager.LoadScene("finale");

            }


        }
    }
}
