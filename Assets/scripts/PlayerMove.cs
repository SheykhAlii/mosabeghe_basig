using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    public int impact;

    public FixedJoystick joystick;
    public float SpeedMove = 5f;
    private CharacterController controller;
    public Animator animatorcamera;
    public Animator animatorhand;

    public Transform hand;
    bool shootdelay=true;
    int magazin;
    
    public ParticleSystem ps;

    public int gunInHand = 0;
    private Transform currentGun; // نگهداری اسلحه فعلی

    public GameObject bulletPrefab; // Prefab گلوله
    public GameObject rokcet; // Prefab گلوله
    bool rpgInHand=false;

    public Transform shootPoint; // نقطه شلیک گلوله
    public float bulletSpeed ; // سرعت گلوله
    public GameObject roceekvisiol;
    
    bool shoooooooot;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        if(impact == 3)
        {
            SceneManager.LoadScene("finale");

        }

        // حرکت بازیکن
        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;

        controller.Move(Move * SpeedMove * Time.deltaTime);

        // تنظیم انیمیشن راه رفتن
        if (Move.magnitude > 0)
        {
            animatorcamera.SetBool("isWalking", true);
        }
        else
        {
            animatorcamera.SetBool("isWalking", false);
        }

        // پرت کردن اسلحه با کلید G
        if ((Input.GetKeyDown(KeyCode.G)  ) && gunInHand == 1)
        {
            DropGun();

        }

        // شلیک با کلید Mouse0 (چپ ماوس)
        if ( shoooooooot && gunInHand == 1 && shootdelay==true)
        {

            Shoot();
            
           shootdelay=false;

        } 
        if (!shoooooooot) {
            animatorhand.SetBool("shoot", false);
            ps.Stop();

        }

  
    }

    private void OnTriggerStay(Collider other) // این متد باید خارج از Update باشد
    {
        // بررسی برخورد با آبجکت دیگر
        if (other.gameObject.tag == "gun" && gunInHand == 0)
        {
            gunInHand = 1;

            if(other.gameObject.name=="GameObject"){rpgInHand=true;}

            

            // تنظیم والد اسلحه به دوربین
            other.transform.SetParent(hand);
            currentGun = other.transform; // ذخیره مرجع اسلحه

            // تنظیم موقعیت محلی اسلحه نسبت به والد جدید
            other.transform.localPosition = new Vector3(0.3f, -0.26f, 0.4f);

            // تنظیم چرخش اسلحه
            other.transform.localRotation = Quaternion.Euler(0, 180, 0);

            // غیرفعال کردن Rigidbody
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.detectCollisions = false;
            }

            Debug.Log("Picked up the pistol!");
        }
    }

    public void DropGun()
    {
        if (currentGun != null)
        {
            // جدا کردن اسلحه از دوربین
            currentGun.SetParent(null);
            rpgInHand=false;
            
            // فعال کردن Rigidbody
            Rigidbody rb = currentGun.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.detectCollisions = true;

                // اضافه کردن نیروی پرت کردن اسلحه
                rb.AddForce(hand.forward * 200f);
            }
            StartCoroutine(ResetGunInHand());

            Debug.Log("Gun dropped!");
        }
    }

    IEnumerator ResetGunInHand()
    {
        yield return new WaitForSeconds(0.3f);
        gunInHand = 0;
    }


    
    IEnumerator shootdeelay()
    {
        if (rpgInHand) {
            roceekvisiol.gameObject.SetActive(false);

            yield return new WaitForSeconds(5f);
        }
    
        else { yield return new WaitForSeconds(0.3f); }
        shootdelay =true;
        roceekvisiol.gameObject.SetActive(true);

    }

    public void Shoot(){

            StartCoroutine(shootdeelay());

            if (rpgInHand){           
            GameObject rokct = Instantiate(rokcet, shootPoint.position, shootPoint.rotation);

            // اعمال نیروی به گلوله
            Rigidbody rbc = rokct.GetComponent<Rigidbody>();
            if (rbc != null)
            {
                rbc.velocity = shootPoint.forward *20;
            }
            ps.Play();
            Debug.Log("Shot fired!");

            animatorhand.SetBool("shoot", true);}

        else if (bulletPrefab != null && shootPoint != null)
        {
            // ایجاد گلوله
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

            // اعمال نیروی به گلوله
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = shootPoint.forward * bulletSpeed;
            }
            ps.Play();
            Debug.Log("Shot fired!");

            animatorhand.SetBool("shoot", true);

        }}


    public void Shootbtn(){
            shoooooooot=true;
        }

        

        public void noShootbtn()
        {
            
        shoooooooot=false;

        }


        public void Drop(){
            DropGun();
        }
    





        
    


              
       }
            
   





        


