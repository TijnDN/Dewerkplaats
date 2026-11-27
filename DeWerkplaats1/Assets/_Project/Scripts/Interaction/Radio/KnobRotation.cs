using UnityEngine;
using UnityEngine.InputSystem;

public class KnobRotation : MonoBehaviour
{
    public InputActionProperty rotateInput;
    public float rotationSpeed = 100f;

    private static KnobRotation selectedKnob;

    private void Update()
    {
        if (selectedKnob != this)
            return;

        float input = rotateInput.action.ReadValue<Vector2>().x;

        transform.Rotate(
            Vector3.right,
            input * rotationSpeed * Time.deltaTime,
            Space.World
        );
    }

    public void SelectKnob()
    {
        selectedKnob = this;
    }

    public void DeselectKnob()
    {
        if (selectedKnob == this)
            selectedKnob = null;
    }
}
