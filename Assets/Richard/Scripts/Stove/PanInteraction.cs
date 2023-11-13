using UnityEngine;

public class PanInteraction : MonoBehaviour
{
    public Transform holdPoint; // The point where the pan will be held by the player
    public GameObject pan; // The pan GameObject
    public GameObject plate; // The plate GameObject

    private bool isCarryingPan = false;
    private bool playerInRange = false;
    private bool nearPlate = false;

    private void Update()
    {
        // Check for player input to pick up or place down the pan
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (!isCarryingPan)
            {
                PickUpPan();
            }
            else if (nearPlate)
            {
                PlaceDownPan();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pan)
        {
            playerInRange = true;
            Debug.Log("Player is near the pan.");
        }
        else if (other.gameObject == plate)
        {
            nearPlate = true;
            Debug.Log("Player is near the plate.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == pan)
        {
            playerInRange = false;
        }
        else if (other.gameObject == plate)
        {
            nearPlate = false;
        }
    }

    private void PickUpPan()
    {
        // Make the pan a child of the hold point and adjust its position and rotation
        pan.transform.SetParent(holdPoint);
        pan.transform.localPosition = Vector3.zero;
        pan.transform.localRotation = Quaternion.identity;
        isCarryingPan = true;
        Debug.Log("Picked up the pan.");
    }

    private void PlaceDownPan()
    {
        // Place the pan down near the plate
        pan.transform.SetParent(null); // Or set it to another parent if needed
        pan.transform.position = plate.transform.position + new Vector3(0, 1, 0); // Adjust this offset as needed
        isCarryingPan = false;
        Debug.Log("Placed down the pan.");
    }
}
