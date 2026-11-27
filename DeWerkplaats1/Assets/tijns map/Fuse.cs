using UnityEngine;

public class Fuse : MonoBehaviour
{
    private Rigidbody rb;
    private bool isSnapped = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Returns true when the fuse is currently being held
    public bool IsHeld()
    {
        // Most grab systems set the Rigidbody to kinematic while holding
        return rb != null && rb.isKinematic && !isSnapped;
    }

    public void SnapTo(Transform snapPoint)
    {
        isSnapped = true;

        // Stop any physics
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Snap into place
        transform.SetParent(snapPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}