using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Keypad : MonoBehaviour
{
    public int[] correctCode = { 5, 2, 3, 4 };
    public GameObject objectToActivate;
    public TMP_Text displayText;

    private List<int> enteredCode = new List<int>();

    public void PressDigit(int digit)
    {
        enteredCode.Add(digit);

        // Keep only the most recent 4 digits
        if (enteredCode.Count > 4)
        {
            enteredCode.RemoveAt(0);
        }

        UpdateDisplay();
    }
    
    private void UpdateDisplay()
    {
        displayText.text = "";

        foreach (int digit in enteredCode)
        {
            displayText.text += digit.ToString();
        }
    }


    public void CheckCode()
    {
        if (enteredCode.Count != correctCode.Length)
        {
            Debug.Log("Incomplete code!");
            return;
        }

        for (int i = 0; i < correctCode.Length; i++)
        {
            if (enteredCode[i] != correctCode[i])
            {
                Debug.Log("Incorrect code!");
                enteredCode.Clear();
                return;
            }
        }

        Debug.Log("Correct code!");
        objectToActivate.SetActive(true);
    }
}
