using UnityEngine;

public class TrashCanInteraction : MonoBehaviour
{
    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered range of trash can");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left range of trash can");
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed near trash can");
            DisposeFood();
        }
    }

    private void DisposeFood()
    {
        if (FoodSelection.Instance != null)
        {
            Transform holdPoint = FoodSelection.Instance.holdPoint;

            if (holdPoint != null && holdPoint.childCount > 0)
            {
                GameObject foodItem = holdPoint.GetChild(0).gameObject;
                Destroy(foodItem);
                Debug.Log("Food item disposed");
            }
        }
    }
}

