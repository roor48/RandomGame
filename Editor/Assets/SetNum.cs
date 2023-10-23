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
        
        Destroy(avgNum.gameObject);
    }

    public void Btn_Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
