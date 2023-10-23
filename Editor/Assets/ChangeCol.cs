using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChangeCol : MonoBehaviour
{
    [SerializeField] private Result result;
    [SerializeField] private Image bg;
    [SerializeField] private Text fastNess;

    private readonly Color[] errorCols =
    {
        Color.yellow, Color.blue
    };

    private float littleDelay = 0;
    private float delay = 3f;
    public float time = 0;

    public int sum = 0;
    public int cnt = 0;

    private bool isGreen = false;
    private bool isShown = false;

    private void Start()
    {
        DontDestroyOnLoad(result.gameObject);
    }

    private void Update()
    {
        if (cnt >= 5)
        {
            result.miliSecs = sum;
            SceneManager.LoadScene("ResultScene");
        }

        if (littleDelay > 0)
        {
            littleDelay -= Time.deltaTime;
            return;
        }

        if (isShown)
        {
            time += Time.deltaTime;
        }

        if (time >= 1f)
        {
            if (isGreen)
            {
                sum += 1000;
                fastNess.text = "1000ms!";
                bg.color = Color.red;
                littleDelay = 0.5f;
                Invoke(nameof(ReturnToWhite), 0.5f);
                
                fastNess.gameObject.SetActive(true);
                Invoke(nameof(DisableFastness), 0.5f);
                cnt++;
            }
            else
            {
                ReturnToWhite();
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGreen)
            {
                sum += Mathf.RoundToInt(time * 1000);
                fastNess.text = $"{Mathf.RoundToInt(time * 1000)}ms!";
                ReturnToWhite();
                cnt++;
            }
            else
            {
                sum += 1000;
                fastNess.text = "1000ms!";
                bg.color = Color.red;
                Invoke(nameof(ReturnToWhite), 0.5f);
            }
            
            fastNess.gameObject.SetActive(true);
            Invoke(nameof(DisableFastness), 0.5f);
            littleDelay = 0.5f;

            return;
        }

        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            ChangeColor();
            isShown = true;
            delay = Random.Range(1f, 4f);
        }
    }

    private void DisableFastness()
    {
        fastNess.gameObject.SetActive(false);
    }

    private void ReturnToWhite()
    {
        bg.color = Color.white;
        time = 0;
        isShown = false;
        isGreen = false;
        delay = Random.Range(1f, 4f);
    }

    private void ChangeColor()
    {
        int color = Random.Range(0, 2);
        if (color == 0)
        {
            bg.color = Color.green;
            isGreen = true;
        }
        else
        {
            bg.color = errorCols[Random.Range(0, errorCols.Length)];
            isGreen = false;
        }
    }

    public void Btn_Leave()
    {
        Destroy(result.gameObject);
        SceneManager.LoadScene("SampleScene");
    }
}
