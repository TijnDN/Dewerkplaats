
using UnityEngine;

public class Radio : MonoBehaviour
{
    public RadioKnob[] knobs;
    private bool wasCorrect = false;
    public GameObject objectToActivate;

    private void Update()
    {
        bool allCorrect = true;
        foreach (RadioKnob knob in knobs)
        {
            if (knob == null || knob.IsCorrect() == false)
                {
                    allCorrect = false;
                    break;
            }
        }

        if (allCorrect && !wasCorrect)
        {
            Debug.Log("Correct radio frequency!");
            objectToActivate.SetActive(true);
        }

        wasCorrect = allCorrect;
    }
}