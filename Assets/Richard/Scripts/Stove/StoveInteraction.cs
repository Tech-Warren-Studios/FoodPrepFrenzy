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
        // Check if the player is in range
        if (playerInRange)
        {
            Debug.Log("Player is in range of the stove.");

            // Check for spacebar press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Spacebar pressed near the stove.");
                StartCoroutine(CookSteak());
            }
        }
    }

    private IEnumerator CookSteak()
    {
        Transform holdPoint = FoodSelection.Instance.holdPoint;

        if (holdPoint.childCount > 0)
        {
            GameObject steak = holdPoint.GetChild(0).gameObject;
            currentSteak = steak;

            // Cooking stages
            yield return new WaitForSeconds(5);
            ReplaceSteak(rareSteakPrefab);

            yield return new WaitForSeconds(5);
            ReplaceSteak(mediumSteakPrefab);

            yield return new WaitForSeconds(5);
            ReplaceSteak(wellDoneSteakPrefab);

            yield return new WaitForSeconds(15);
            ReplaceSteak(burntSteakPrefab);
        }
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

