using UnityEngine;

public class Lever : MonoBehaviour
{
    public FuseBox fuseBox;
    public GameObject objectToActivate;
    public HingeJoint hinge;
    public float activationAngle = 35f;
    private bool activated = false;

    private void Update()
    {
        if (activated)
            return;

        if (hinge.angle >= activationAngle)
        {
            PullLever();
        }
    }

    public void PullLever()
    {
        foreach (FuseSpot spot in fuseBox.fuseSpots)
        {
            if (spot == null || !spot.IsCorrect())
            {
                Debug.Log("You need to insert the correct fuses first!");
                return;
            }
        }
        activated = true;
        objectToActivate.SetActive(true);
        Debug.Log("Lever activated!");
    }
}
