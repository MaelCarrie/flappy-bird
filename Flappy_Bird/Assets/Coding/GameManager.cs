using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int Score = 0;
    public TextMeshProUGUI scoreText;
    public Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
        restartButton.onClick.AddListener(() => restartGame());
        restartButton.gameObject.SetActive(false);
    }

    void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void killPlayer()
    {
        OnPlayerDie();
    }

    void OnPlayerDie()
    {
        Time.timeScale = 0f;
        scoreText.text = "You died. Press R to restart. Your best score is : " + Score;
        restartButton.gameObject.SetActive(true);
    }

    public void addScore()
    {
        Score++;
        scoreText.text = Score.ToString();
    }
}
