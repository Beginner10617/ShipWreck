using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI powerUpText; // Reference to the TextMeshPro UI Text component
    public int total;
    void Start()
    {
        int total=GameObject.FindGameObjectsWithTag("coin").Length;
    }
    void Update()
    {
        if (powerUpText != null)
        {
            // Count the number of GameObjects with the tag "PowerUp"
            int powerUpCount = GameObject.FindGameObjectsWithTag("coin").Length;

            // Display the count in the TextMeshPro UI Text
            powerUpText.text = "Coins Taken: " + (total-powerUpCount).ToString();
        }
    }
}
