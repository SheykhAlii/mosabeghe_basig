using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramanenger : MonoBehaviour

{
    public bool start=false;

    public Camera camera1;
    public Camera camera2;
    // Start is called before the first frame update

    private void Start()
    {
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
    }
    void Update()
    {
        if (start)
        {
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
        }
    }

}
