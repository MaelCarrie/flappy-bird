using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int Score = 0;
    public TextMeshProUGUI scoreText;
    public Button restartButton;

    // Audio
    public AudioSource soundScore;
    public AudioSource soundMusic;
    public AudioSource soundDead;
    public AudioSource soundSpawn;

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
        soundSpawn.Play();
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
            soundSpawn.Play();
        }
    }

    public void killPlayer()
    {
        soundDead.Play();
        OnPlayerDie();
    }

    void OnPlayerDie()
    {
        Time.timeScale = 0f;
        scoreText.text = "You died. Press R to restart. Your best score is : " + Score;
        restartButton.gameObject.SetActive(true);
        soundMusic.Stop();
    }

    public void addScore()
    {
        soundScore.Play();
        Score++;
        scoreText.text = Score.ToString();
    }
}
