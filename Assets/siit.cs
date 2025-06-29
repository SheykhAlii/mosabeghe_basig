//This asset was uploaded by https://unityassetcollection.com

using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;




    public class Dialog : MonoBehaviour
    {
        
        public GameObject ppanel;

        public void puse()
        {
            ppanel.SetActive(true);
        Time.timeScale = 0f;
        }

        public void con()
        {
        ppanel.SetActive(false);   
        Time.timeScale = 1f;
        }

        public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }

    public void Res()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("car v4");
    }
    public void Res1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("level");
    }
}

