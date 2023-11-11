using UnityEngine;

public class FridgeInteraction : MonoBehaviour
{
    public GameObject foodSelectionUI; // Reference to the FoodSelectionCanvas GameObject

    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left range");

            // Check if foodSelectionUI is not null before accessing its component
            if (foodSelectionUI != null)
            {
                FoodSelectionCanvas foodCanvas = foodSelectionUI.GetComponent<FoodSelectionCanvas>();

                // Further check if the component is not null
                if (foodCanvas != null)
                {
                    foodCanvas.ToggleFoodSelection(false);
                }
            }
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed");

            // Check if the holdPoint is empty before showing food selection UI
            if (foodSelectionUI != null && FoodSelection.Instance.IsHoldPointEmpty())
            {
                foodSelectionUI.SetActive(true);
            }
        }
    }
}



