using UnityEngine;

public class FridgeInteraction : MonoBehaviour
{
    public GameObject foodSelectionUI; // The UI for selecting food items

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // The player has entered the trigger zone, show some UI indication if you want
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // If the player leaves the trigger zone, close the food selection UI and unpause the game if it's open
            if (foodSelectionUI.activeSelf)
            {
                foodSelectionUI.SetActive(false);
                FoodSelection.Instance.PauseGame(false);
            }
        }
    }

    private void Update()
    {
        // Check if the food selection UI is active in the scene
        if (foodSelectionUI.activeSelf)
        {
            // If it's active, don't proceed with interaction checks
            return;
        }

        // Detect if the player presses the interaction key while inside the trigger
        if (Input.GetKeyDown(KeyCode.Space)) // Replace with KeyCode.E if 'E' is the desired interaction key
        {
            // If the food selection UI is not active and the player presses the interaction key, activate the UI and pause the game
            foodSelectionUI.SetActive(true);
            FoodSelection.Instance.PauseGame(true);
        }
    }
}
