using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class FuseBox2 : MonoBehaviour
{
    [Header("Snap Settings")]
    public Transform snapPoint;      // Empty child where the fuse should sit
    public bool isOccupied = false;

    private void OnTriggerEnter(Collider other)
    {
        Fuse fuse = other.GetComponent<Fuse>();
        if (fuse != null && fuse.IsHeld() && !isOccupied)
        {
            fuse.SnapTo(snapPoint);
            isOccupied = true;
        }
    }
}