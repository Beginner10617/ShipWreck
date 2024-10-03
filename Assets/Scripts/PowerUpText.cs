using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI powerUpText; // Reference to the TextMeshPro UI Text component
    int total;
    int powerUpCount;
    void Start()
    {
        total=GameObject.FindGameObjectsWithTag("coin").Length;
        Debug.Log(total);
    }
    void Update()
    {
        if (powerUpText != null)
        {
            // Count the number of GameObjects with the tag "PowerUp"
            powerUpCount = GameObject.FindGameObjectsWithTag("coin").Length;

            // Display the count in the TextMeshPro UI Text
            powerUpText.text =  (total-powerUpCount).ToString();
        }
    }
}
