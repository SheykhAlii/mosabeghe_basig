using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pont : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("event"))
        {
            print("eve");
        }
    }
}
