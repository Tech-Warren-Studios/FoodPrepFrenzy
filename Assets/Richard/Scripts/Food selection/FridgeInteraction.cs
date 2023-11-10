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
            Debug.Log("Player entered range"); // Add this
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left range"); // Add this
            foodSelectionUI.GetComponent<FoodSelectionCanvas>().ToggleFoodSelection(false);
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed");
            foodSelectionUI.SetActive(true); // Directly set to active
        }
    }

}


