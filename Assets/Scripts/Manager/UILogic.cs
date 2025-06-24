using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILogic : MonoBehaviour,IObjectInScene
{
    public Text scoreText;
    public Text heighestScoreText;

    public GameObject dieUI;

    private int heighestScore_;

    private AudioSource adGameOver_;
    public AudioSource adGaming;//凑合一下
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddListener(this);
        try
        {
            heighestScore_ = PlayerPrefs.GetInt("heighestScore", 0);
            heighestScoreText.text = "最高分：" + heighestScore_.ToString();
        }
        catch (System.Exception e)
        {
            print(e);
        }

        adGameOver_ = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "得分："+GameManager.Instance.score.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            updateHeighestScore();
            SceneManager.LoadScene("Scenes/Start");
        }
    }

    void updateHeighestScore()
    {
        if (GameManager.Instance.score > heighestScore_)
        {
            PlayerPrefs.SetInt("heighestScore", GameManager.Instance.score);
        }
    }

    public void OnGameOver()
    {
        adGaming.Stop();
        adGameOver_.Play();
        dieUI.SetActive(true);
        updateHeighestScore();
    }
}
