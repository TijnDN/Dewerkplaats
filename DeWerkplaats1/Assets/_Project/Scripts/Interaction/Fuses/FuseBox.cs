using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public FuseSpot[] fuseSpots = new FuseSpot[4];

    public void CheckFuses()
    {
        foreach (FuseSpot spot in fuseSpots)
        {
            if (!spot.IsCorrect())
            {
                Debug.Log("Wrong fuse!");
                return;
            }
        }
    }
}