using UnityEngine;

public class FoodSelectionCanvas : MonoBehaviour
{
    public GameObject steakPrefab; // Assign the prefab for the steak in the inspector
    public GameObject carrotPrefab; // Assign the prefab for the carrot
    public GameObject cheesePrefab; // Assign the prefab for the cheese
    public Transform holdPoint; // Assign the hold point, a child of the player where the food will be attached
    public GameObject player; // Assign the player GameObject

    // You could use an enum to represent the different food types
    public enum FoodType
    {
        None,
        Steak,
        Carrot,
        Cheese
    }

    private FoodType heldFood = FoodType.None;

    // Start with the canvas disabled
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Call this method to toggle the visibility of the selection canvas
    public void ToggleFoodSelection(bool show)
    {
        gameObject.SetActive(show);
        if (!show && heldFood != FoodType.None)
        {
            AttachFoodToPlayer(heldFood);
        }
    }

    // Call these methods from the UI button's onClick event to select a food
    public void SelectSteak()
    {
        heldFood = FoodType.Steak;
        ToggleFoodSelection(false); // Hide the canvas after selection
    }

    public void SelectCarrot()
    {
        heldFood = FoodType.Carrot;
        ToggleFoodSelection(false); // Hide the canvas after selection
    }

    public void SelectCheese()
    {
        heldFood = FoodType.Cheese;
        ToggleFoodSelection(false); // Hide the canvas after selection
    }

    // Instantiate the food item and attach it to the player
    private void AttachFoodToPlayer(FoodType food)
    {
        GameObject foodPrefab = null;
        switch (food)
        {
            case FoodType.Steak:
                foodPrefab = steakPrefab;
                break;
            case FoodType.Carrot:
                foodPrefab = carrotPrefab;
                break;
            case FoodType.Cheese:
                foodPrefab = cheesePrefab;
                break;
        }

        if (foodPrefab != null)
        {
            GameObject foodObject = Instantiate(foodPrefab, holdPoint.position, Quaternion.identity);
            foodObject.transform.SetParent(holdPoint, false);
        }
    }
}

