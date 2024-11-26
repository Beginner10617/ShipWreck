using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool AndroidController;
    public GameObject JoystickIcon;
    public float speed = 5f;
    public InputActionReference playerInput;
    private bool axesInverted = false;
    public List<Sprite> Sprites;
    public Pause pause;
    float moveHorizontal;
    float moveVertical;
    Vector2 movement;
    public AudioManager audioManager;
    AudioSource SFX;
    AudioClip MoveSound;
    Rigidbody2D rb;
    void Start()
    {
        if(!AndroidController)
        {
            JoystickIcon.SetActive(false);
        }
        else
        {
            JoystickIcon.SetActive(true);
        }
        rb = GetComponent<Rigidbody2D>();
        SFX = audioManager.SFX;
        MoveSound = audioManager.Movement;
    }

    void Update()
    {
        if(pause.isPaused) return;
        // Move the player
        if(AndroidController)
        {
            movement = playerInput.action.ReadValue<Vector2>();
            moveHorizontal = movement.x;
            moveVertical = movement.y;
        }
        else
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
            movement = new Vector2(moveHorizontal,moveVertical);
        }
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
