using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArcadeVehicleController
{
public class qrplayercontroler : MonoBehaviour
{
        [SerializeField] private Vehicle m_Vehicle;
        [SerializeField] GameObject qrfarman;
     

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("new");
            }

            if (m_Vehicle == null) return;



            m_Vehicle.SetSteerInput(-qrfarman.transform.localRotation.z);


            

            m_Vehicle.SetAccelerateInput(0.5f);



        }
    }
}
