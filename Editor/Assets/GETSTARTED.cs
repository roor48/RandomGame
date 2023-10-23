using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GETSTARTED : MonoBehaviour
{
    public void Btn_Start()
    {
        SceneManager.LoadScene("InPlayScene");
    }
}
