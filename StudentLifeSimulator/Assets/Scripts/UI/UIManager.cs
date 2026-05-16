using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject hudPanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    private bool isPaused = false;

    void Start()
    {
        introPanel.SetActive(true);
        hudPanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        Invoke("StartGameUI", 5f);
    }

    void StartGameUI()
    {
        introPanel.SetActive(false);
        hudPanel.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}