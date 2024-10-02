using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private bool axesInverted = false;

    void Update()
    {
        // Get input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Invert axes if Q is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            axesInverted = !axesInverted;
        }

        // Apply inversion
        if (axesInverted)
        {
            moveHorizontal = -moveHorizontal;
            moveVertical = -moveVertical;
        }

        // Move the player
        Vector3 movement = new Vector3(moveHorizontal,moveVertical, 0.0f );
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
