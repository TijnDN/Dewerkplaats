using UnityEngine;

public class RadioKnob : MonoBehaviour
{
    public float correctAngle;
    public float tolerance = 5f;

    

    public bool IsCorrect()
    {
        float currentAngle = transform.eulerAngles.x;

        float difference = Mathf.Abs(
            Mathf.DeltaAngle(currentAngle, correctAngle)
        );

        return difference <= tolerance;
    }
}
