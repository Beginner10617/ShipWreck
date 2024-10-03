using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private bool axesInverted = false;
    public List<Sprite> Sprites;
    float move=1;

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
        if(moveHorizontal == 0)
        {
            GetComponent<SpriteRenderer>().sprite = Sprites[0];
        }
        else if(moveHorizontal != 0)
        {
            GetComponent<SpriteRenderer>().sprite = Sprites[1];
            transform.localScale = new Vector3(moveHorizontal/Mathf.Abs(moveHorizontal), 1, 1);
        }
        transform.Translate(Vector3.Normalize(movement) * speed * Time.deltaTime, Space.World);
    }
}
