using UnityEngine;
using UnityEngine.UI;

public class GetRank : MonoBehaviour
{
    public Text rankText;
    private void Start()
    {
        rankText.text = "";
        for (int i = 1; i <= 5; i++)
        {
            rankText.text += $"{i}. {PlayerPrefs.GetInt($"rank{i}")}ms";
            if (i < 5) rankText.text += "\n\n";
        }
    }
}
