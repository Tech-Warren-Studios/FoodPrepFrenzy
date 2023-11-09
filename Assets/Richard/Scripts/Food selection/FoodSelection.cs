using UnityEngine;
using UnityEngine.UI;

public class FoodSelection : MonoBehaviour
{
    // Singleton instance
    public static FoodSelection Instance { get; private set; }

    public Text selectionText; // UI Text element that displays the current selection
    private string[] foodItems = { "Food 1", "Food 2", "Food 3" }; // Array of food items
    private int selectedIndex = 0; // Index of the currently selected food item

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
    }

    private void Update()
    {
        if (!gameObject.activeSelf)
        {
            return; // If the UI isn't active, don't listen for input
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            // Move selection to the left
            selectedIndex--;
            if (selectedIndex < 0) selectedIndex = foodItems.Length - 1;
            UpdateSelectionUI();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // Move selection to the right
            selectedIndex++;
            if (selectedIndex >= foodItems.Length) selectedIndex = 0;
            UpdateSelectionUI();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            // Select the current food item
            SelectFood();
        }
    }

    // Updates the UI text to show the currently selected food item
    private void UpdateSelectionUI()
    {
        selectionText.text = foodItems[selectedIndex];
    }

    // Handles the selection of the current food item
    private void SelectFood()
    {
        Debug.Log("Selected: " + foodItems[selectedIndex]);
        // Here you would typically handle what happens once an item is selected
        // For example, instantiate it, add it to the player's inventory, etc.

        // Close the selection UI and unpause the game
        PauseGame(false);
    }

    // Toggles the pause state of the game and the visibility of the selection UI
    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
        // If there's a need to disable other player controls, that should be handled here
        gameObject.SetActive(pause);
    }
}
