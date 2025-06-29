using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour

{
  
    // Start is called before the first frame update
    void Start()
    {
    WebCamDevice[] devices = WebCamTexture.devices;
    WebCamTexture cam = new WebCamTexture(devices[3].name);
    Debug.Log(cam.deviceName);

    Renderer renderer = GetComponent<Renderer>();
    renderer.material.mainTexture = cam;
    cam.Play();
    }
}
