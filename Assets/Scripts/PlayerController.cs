using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private bool axesInverted = false;
    public List<Sprite> Sprites;
    float moveHorizontal;
    float moveVertical;
    Vector2 movement;
    public AudioManager audioManager;
    AudioSource SFX;
    AudioClip MoveSound;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SFX = audioManager.SFX;
        MoveSound = audioManager.Movement;
    }

    void Update()
    {
        // Get input for movement
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

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
        movement = new Vector2(moveHorizontal,moveVertical);
        if(moveHorizontal == 0)
        {
            GetComponent<SpriteRenderer>().sprite = Sprites[0];
        }
        else if(moveHorizontal != 0)
        {
            GetComponent<SpriteRenderer>().sprite = Sprites[1];
            transform.localScale = new Vector3(moveHorizontal/Mathf.Abs(moveHorizontal), 1, 1);
        }
        if(movement.magnitude != 0 && !SFX.isPlaying)
        {
            SFX.PlayOneShot(MoveSound);
        }
        rb.AddForce(movement.normalized * speed);
    }
}
