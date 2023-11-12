using UnityEngine;
using System.Collections;

public class StoveInteraction : MonoBehaviour
{
    public GameObject rawSteakPrefab;
    public GameObject rareSteakPrefab;
    public GameObject mediumSteakPrefab;
    public GameObject wellDoneSteakPrefab;
    public GameObject burntSteakPrefab;

    public Transform steakPositionOnPan; // Transform for steak position on the pan

    private bool playerInRange = false;
    private GameObject currentSteak;
    private bool isCooking = false; // Flag to check if cooking is already in progress
    private float inputCooldown = 0.5f; // Cooldown time in seconds to debounce input
    private float lastInputTime = -1f; // Time when the last input was registered

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered range of stove");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left range of stove");
        }
    }

    private void Update()
    {
        // Check if the player is in range and if the cooldown period has passed
        if (playerInRange && Time.time >= lastInputTime + inputCooldown)
        {
            Debug.Log("Player is in range of the stove.");

            // Check for spacebar press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lastInputTime = Time.time; // Update the last input time
                Debug.Log("Spacebar pressed near the stove.");
                if (!isCooking)
                {
                    PlaceSteakOnStove();
                    StartCoroutine(CookSteak());
                }
            }
        }
    }

    private void PlaceSteakOnStove()
    {
        Transform holdPoint = FoodSelection.Instance.holdPoint;

        if (holdPoint.childCount > 0)
        {
            GameObject steak = holdPoint.GetChild(0).gameObject;
            currentSteak = steak;
            ReplaceSteak(rawSteakPrefab); // Immediately replace with raw steak prefab
        }
    }

    private IEnumerator CookSteak()
    {
        isCooking = true; // Set cooking flag to true

        // Cooking stages
        yield return new WaitForSeconds(5);
        ReplaceSteak(rareSteakPrefab);

        yield return new WaitForSeconds(5);
        ReplaceSteak(mediumSteakPrefab);

        yield return new WaitForSeconds(5);
        ReplaceSteak(wellDoneSteakPrefab);

        yield return new WaitForSeconds(15);
        ReplaceSteak(burntSteakPrefab);

        isCooking = false; // Reset cooking flag after coroutine
    }

    private void ReplaceSteak(GameObject newSteakPrefab)
    {
        if (currentSteak != null && steakPositionOnPan != null)
        {
            Destroy(currentSteak);
            currentSteak = Instantiate(newSteakPrefab, steakPositionOnPan.position, steakPositionOnPan.rotation, steakPositionOnPan);
        }
    }
}

