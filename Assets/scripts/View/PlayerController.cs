using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // برای استفاده از دکمه‌ها
using UnityEngine.EventSystems; // برای استفاده از EventTrigger
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Android;


namespace ArcadeVehicleController
{

    
    public class PlayerController : MonoBehaviour
    {

        
        [SerializeField] private Vehicle m_Vehicle;
        [SerializeField] public GameObject btnl; // دکمه چپ
        [SerializeField] public GameObject btnr; // دکمه راست
        [SerializeField] public GameObject btngass; // دکمه گاز
        int eve=1;
         private float steerInput = 0f;
        private float accelerateInput = 0f;


        float horizental;
        float gass=1;




        private void Start()
        {
            Application.targetFrameRate = 60;
        
            // تنظیم رویداد دکمه‌ها برای ورودی‌ها


        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("new");
            }



            if (m_Vehicle == null) return;

            m_Vehicle.SetSteerInput(horizental*eve);
            m_Vehicle.SetAccelerateInput(gass*eve);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("event"))
            {
                eve = 0;
                print(eve);
            }
        }
        // تنظیم ورودی‌های فرمان


        // تنظیم ورودی‌های گاز

        // افزودن رویداد لمس صفحه به دکمه‌ها


        public void moverighOn(){
            
horizental=1;
        }

        public void moveleftOn(){

horizental=-1;

            
        }
                public void moverighOff(){
            
horizental=0;
        }

        public void moveleftOff(){

horizental=0;

            
        }

        public void brakOn(){


            gass=0.1f;}
    
        public void brakOff(){


            gass=1;}


    }
}
