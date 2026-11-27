using UnityEngine;

public class FuseSlot : MonoBehaviour
{
    [Header("Instellingen")]
    public string requiredFuseID = "FuseA";   
    public Transform snapPoint;             
    public GameObject[] lightsToTurnOn;      

    private bool isOccupied = false;

    void OnTriggerEnter(Collider other)
    {
        if (isOccupied) return;

        FuseItem fuse = other.GetComponent<FuseItem>();
        if (fuse == null) return;

        // Snap de zekering naar de plek
        other.transform.position = snapPoint.position;
        other.transform.rotation = snapPoint.rotation;

        // Zorg dat hij blijft liggen (geen physics meer)
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Maak hem kind van de slot zodat hij meedraait
        other.transform.SetParent(transform);

        isOccupied = true;

        // Check of het de juiste zekering is
        if (fuse.fuseID == requiredFuseID)
        {
            Debug.Log("Juiste zekering geplaatst!");

            // Lampen aanzetten
            foreach (GameObject light in lightsToTurnOn)
            {
                if (light != null)
                    light.SetActive(true);
            }

            // Puzzel afronden
            if (PuzzleManager.Instance != null)
            {
                PuzzleManager.Instance.CompletePuzzle();
            }
        }
        else
        {
            Debug.Log("Verkeerde zekering.");
        }
    }
}