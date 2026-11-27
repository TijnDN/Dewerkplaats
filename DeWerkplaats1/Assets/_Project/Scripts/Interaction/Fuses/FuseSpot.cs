using UnityEngine;

public class FuseSpot : MonoBehaviour
{
    public string requiredFuseName;
    public string insertedFuseName;

    private void OnTriggerEnter(Collider other)
    {
        insertedFuseName = other.gameObject.name;
    }

    private void OnTriggerExit(Collider other)
    {
        if (insertedFuseName == other.gameObject.name)
        {
            insertedFuseName = "";
        }
    }

    public bool IsCorrect()
    {
        return insertedFuseName == requiredFuseName;
    }
}