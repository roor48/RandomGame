using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetNum : MonoBehaviour
{
    public Text avgText;
    private Result avgNum;
    private void Start()
    {
        avgNum = GameObject.Find("Result").GetComponent<Result>();
        avgText.text = $"평균 속도: {avgNum.miliSecs/5}ms";
        SaveRank(avgNum.miliSecs/5);
        
        Destroy(avgNum.gameObject);
    }

    private void SaveRank(int num)
    {
        for (int i = 1; i <= 5; i++)
        {
            if (num < PlayerPrefs.GetInt($"rank{i}") || PlayerPrefs.GetInt($"rank{i}") == 0)
            {
                for (int j = 5; j > i; j--)
                {
                    PlayerPrefs.SetInt($"rank{j}", PlayerPrefs.GetInt($"rank{j-1}"));
                }
                PlayerPrefs.SetInt($"rank{i}", num);

                return;
            }
        }
    }
    
    public void Btn_Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
