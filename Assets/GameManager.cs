using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public BalanceBar balanceBar;
    public float gameoverThreshold = 0.25f; // Use camelCase for consistency

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set instance if not already assigned
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    void Update()
    {
        CheckGameOver();
    }

    public void CheckGameOver()
    {
        if (balanceBar != null) // Ensure balanceBar is assigned
        {
            if (balanceBar.balance > gameoverThreshold)
            {
                // Work bar exceeds the threshold
                GameOverAnimation("work");
            }
            else if (balanceBar.balance < -gameoverThreshold)
            {
                // Life bar exceeds the threshold
                GameOverAnimation("life");
            }
        }
        else
        {
            Debug.LogError("BalanceBar reference is missing in GameManager!");
        }
    }

    public void GameOverAnimation(string type) // Fixed parameter type declaration
    {
        if (type == "work")
        {
            // Play overwork animation
            Debug.Log("Game Over due to overworking.");
        }
        else if (type == "life")
        {
            // Play dirt-poor animation
            Debug.Log("Game Over due to lack of work-life balance.");
        }

        // Play general animation
        Debug.Log("Game Over! You lost. There is no perfect answer in life’s choices.");
    }
}