using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Stats")]
    public int energy = 100;
    public int hunger = 0;
    public int stress = 0;
    public int grades = 0;

    [Header("Day System")]
    public int currentDay = 1;

    bool gameEnded = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Initialize HUD display
        if(GameUIManager.instance != null)
        {
            GameUIManager.instance.UpdateHUD(grades, energy, hunger, stress, currentDay);
        }
    }

    // SLEEP
    public void Sleep()
    {
        if(gameEnded)
        {
            return;
        }

        energy += 40;
        stress -= 20;
        hunger += 10;

        energy = Mathf.Clamp(energy, 0, 100);
        stress = Mathf.Clamp(stress, 0, 100);
        hunger = Mathf.Clamp(hunger, 0, 100);

        currentDay++;

        Debug.Log("Player Slept - DAY = " + currentDay);

        // STOP AT DAY 5
        if(currentDay > 5)
        {
            EndGame();
            return;
        }

        // SHOW DAY PANEL
        if(GameUIManager.instance != null)
        {
            GameUIManager.instance.ShowDay(currentDay);
            GameUIManager.instance.UpdateHUD(grades, energy, hunger, stress, currentDay);
        }
    }

    // STUDY
    public void Study()
    {
        if(gameEnded)
        {
            return;
        }

        grades += 10;
        stress += 15;
        energy -= 10;

        grades = Mathf.Clamp(grades, 0, 100);
        stress = Mathf.Clamp(stress, 0, 100);
        energy = Mathf.Clamp(energy, 0, 100);

        Debug.Log("Player Studied - Grades: " + grades);
        UpdateHUD(currentDay);
    }

    // EAT
    public void Eat()
    {
        if(gameEnded)
        {
            return;
        }

        hunger -= 30;
        energy += 10;

        hunger = Mathf.Clamp(hunger, 0, 100);
        energy = Mathf.Clamp(energy, 0, 100);

        Debug.Log("Player Ate - Hunger: " + hunger);
        UpdateHUD(currentDay);
    }

    // GAMING
    public void PlayGame()
    {
        if(gameEnded)
        {
            return;
        }

        stress -= 20;
        grades -= 5;
        energy -= 5;

        stress = Mathf.Clamp(stress, 0, 100);
        grades = Mathf.Clamp(grades, 0, 100);
        energy = Mathf.Clamp(energy, 0, 100);

        Debug.Log("Player Played Games - Stress: " + stress);
        UpdateHUD(currentDay);
    }

    // GAME END
    void EndGame()
    {
        gameEnded = true;

        Debug.Log("GAME ENDED - Final Grades: " + grades);

        if(GameUIManager.instance != null)
        {
            if(grades < 40)
            {
                GameUIManager.instance.ShowResult("FAILED");
            }
            else if(grades >= 40 && grades < 80)
            {
                GameUIManager.instance.ShowResult("PASSED");
            }
            else
            {
                GameUIManager.instance.ShowResult("EXCELLENT");
            }
        }
    }

    // UPDATE HUD DISPLAY
    void UpdateHUD(int day = 0)
    {
        if(GameUIManager.instance != null)
        {
            GameUIManager.instance.UpdateHUD(grades, energy, hunger, stress, day);
        }
    }
}