using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager instance;

    [Header("Panels")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject dayPanel;

    [Header("Texts")]
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI dayChangeText;
    public TextMeshProUGUI messageText;

    [Header("HUD Stats")]
    public TextMeshProUGUI gradesText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI stressText;
    public TextMeshProUGUI dayText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        dayPanel.SetActive(false);

        // Initialize HUD with default values
        UpdateHUD(0, 100, 0, 0, 1);

        Invoke("HideStartPanel", 5f);
    }

    void HideStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
    }

    public void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }

    public void ShowDay(int day)
    {
        dayPanel.SetActive(true);

        dayChangeText.text = "DAY " + day;

        CancelInvoke("HideDayPanel");
        Invoke("HideDayPanel", 2f);
    }

    void HideDayPanel()
    {
        dayPanel.SetActive(false);
    }

    public void ShowResult(string result)
    {
        Debug.Log("SHOWING RESULT");

        gameOverPanel.SetActive(true);

        resultText.text = result;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public void UpdateHUD(int grades, int energy, int hunger, int stress, int day = 0)
    {
        if(gradesText != null)
            gradesText.text = "Grades: " + grades;
        else
            Debug.LogError("gradesText is not assigned!");

        if(energyText != null)
            energyText.text = "Energy: " + energy;
        else
            Debug.LogError("energyText is not assigned!");

        if(hungerText != null)
            hungerText.text = "Hunger: " + hunger;
        else
            Debug.LogError("hungerText is not assigned!");

        if(stressText != null)
            stressText.text = "Stress: " + stress;
        else
            Debug.LogError("stressText is not assigned!");

        if(dayText != null && day > 0)
            dayText.text = "Day: " + day;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}