using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GETSTARTED : MonoBehaviour
{
    private void Start()
    {
        for (int i = 1; i <= 5; i++)
            if (!PlayerPrefs.HasKey($"rank{i}"))
                PlayerPrefs.SetInt($"rank{i}", 0);
    }

    public void Btn_Menu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Btn_Leader()
    {
        SceneManager.LoadScene("RankingScene");
    }
    public void Btn_Start()
    {
        SceneManager.LoadScene("InPlayScene");
    }
}
