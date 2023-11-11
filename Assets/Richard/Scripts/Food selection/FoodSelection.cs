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

    // Canvas GameObject
    public GameObject canvasGameObject; // Public variable to assign the Canvas

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

        canvasGameObject.SetActive(false); // Start with the UI not visible

        // Assign button click listeners
        steakButton.onClick.AddListener(() => ButtonClicked(steakPrefab));
        carrotButton.onClick.AddListener(() => ButtonClicked(carrotPrefab));
        cheeseButton.onClick.AddListener(() => ButtonClicked(cheesePrefab));
    }

    // Called when any of the buttons is clicked
    private void ButtonClicked(GameObject foodPrefab)
    {
        SelectFood(foodPrefab);
        HideUI();
    }

    // Handles the selection of the food item
    private void SelectFood(GameObject foodPrefab)
    {
        // Check if holdPoint is empty and foodPrefab is not null
        if (IsHoldPointEmpty() && foodPrefab != null)
        {
            Instantiate(foodPrefab, holdPoint.position, Quaternion.identity, holdPoint);
            // Additional logic if needed, e.g., replacing existing food, etc.
        }
    }

    // Hides the UI
    private void HideUI()
    {
        canvasGameObject.SetActive(false); // Deactivates the Canvas
        PauseGame(false);
    }

    // Toggles the pause state of the game and the visibility of the selection UI
    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
        canvasGameObject.SetActive(pause);
    }

    // Check if holdPoint is empty
    public bool IsHoldPointEmpty()
    {
        return holdPoint.childCount == 0;
    }
}

