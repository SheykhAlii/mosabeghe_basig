using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class carLife : MonoBehaviour
{

    Rigidbody rb;
    float record;
    bool eve=true;
    public Camera camera1;
    public Camera camera2;
    //public cameramanenger cameramanenger;
    public GameObject sun;
    public Canvas canvas;

    bool resspawin = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //print(rb.velocity.magnitude);
        record = transform.position.z;

        if (transform.position.x < -12 || transform.position.x > 14)
        {
            transform.position = new Vector3(4.18f, 7, record);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (rb.velocity.magnitude < 0.5)
        {
            StartCoroutine(respwain());
            if (resspawin&&eve||transform.rotation.eulerAngles.y < -124||transform.rotation.eulerAngles.y>112)
            {

                resspawin = false;
                SceneManager.LoadScene("car v4");



            }
            if(!eve)
            {
                camera1.gameObject.SetActive(false);
                camera2.gameObject.SetActive(true);
                canvas.enabled=false;
                camera2.transform.position += new Vector3(0, 0.02f, 0.05f);
                if(camera2.transform.position.y> 7)
                {
                    print("loaaad");
                    SceneManager.LoadScene("level");

                }


            }

        }
    }

    IEnumerator respwain()
    {
        yield return new WaitForSeconds(3f);
        resspawin = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("event"))
        {
            eve=false;
            print(eve);
            //cameramanenger.start = true;
            
        }
    }
}
