using UnityEngine;
using UnityEngine.UI;

public class FoodSelection : MonoBehaviour
{
    // Singleton instance
    public static FoodSelection Instance { get; private set; }

    // UI Buttons for food selection
    public Button steakButton;
    public Button carrotButton;
    public Button cheeseButton;

    // Food prefabs
    public GameObject steakPrefab;
    public GameObject carrotPrefab;
    public GameObject cheesePrefab;

    // Hold point
    public Transform holdPoint; // Point on the player where food will be held

    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Optionally, make this object persistent across scenes:
        // DontDestroyOnLoad(gameObject);

        gameObject.SetActive(false); // Start with the UI not visible

        // Assign button click listeners
        steakButton.onClick.AddListener(() => SelectFood(steakPrefab));
        carrotButton.onClick.AddListener(() => SelectFood(carrotPrefab));
        cheeseButton.onClick.AddListener(() => SelectFood(cheesePrefab));
    }

    // Handles the selection of the food item
    private void SelectFood(GameObject foodPrefab)
    {
        if (foodPrefab != null)
        {
            Instantiate(foodPrefab, holdPoint.position, Quaternion.identity, holdPoint);
            // Additional logic if needed, e.g., replacing existing food, etc.
        }

        // Close the selection UI and unpause the game
        PauseGame(false);
    }

    // Toggles the pause state of the game and the visibility of the selection UI
    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
        gameObject.SetActive(pause);
    }
}
