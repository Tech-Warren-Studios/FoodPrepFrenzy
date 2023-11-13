using UnityEngine;
using System.Collections;

public class CuttingBoardInteraction : MonoBehaviour
{
    public GameObject carrotPrefab; // The original carrot prefab
    public GameObject cutCarrotPrefab; // The cut carrot prefab
    public Transform carrotPositionOnCuttingBoard; // The position where the carrot will be placed

    private bool playerInRange = false;
    private GameObject currentCarrot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered range of cutting board");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left range of cutting board");
        }
    }

    private void Update()
    {
        // Check if the player is in range and the 'E' key is pressed
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("E key pressed near the cutting board");
            StartCuttingProcess();
        }
    }

    private void StartCuttingProcess()
    {
        if (currentCarrot == null) // Ensure there's no carrot already on the board
        {
            PlaceCarrotOnBoard();
            StartCoroutine(CutCarrotAfterDelay(5)); // Start the cutting process with a 5-second delay
        }
    }

    private void PlaceCarrotOnBoard()
    {
        // Instantiate the original carrot prefab at the specified position
        if (carrotPositionOnCuttingBoard != null)
        {
            currentCarrot = Instantiate(carrotPrefab, carrotPositionOnCuttingBoard.position, carrotPositionOnCuttingBoard.rotation, carrotPositionOnCuttingBoard);
            Debug.Log("Carrot placed on the cutting board");
        }
        else
        {
            Debug.LogError("Carrot position transform is not set on the cutting board");
        }
    }

    private IEnumerator CutCarrotAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        if (currentCarrot != null)
        {
            Vector3 position = currentCarrot.transform.position;
            Quaternion rotation = currentCarrot.transform.rotation;

            Destroy(currentCarrot); // Remove the original carrot

            // Instantiate the cut carrot prefab at the same position
            currentCarrot = Instantiate(cutCarrotPrefab, position, rotation, carrotPositionOnCuttingBoard);
            Debug.Log("Carrot has been cut");
        }
    }
}
