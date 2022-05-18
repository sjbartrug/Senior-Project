using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Initializes controller and sprintbar
    public CharacterController controller;
    public SprintBar sprintBar;

    //Initialize the Coroutines that test for time to have passed for stamina to regen, as well as if the regen should be halted because sprint was pressed again
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    //Basic variables for controlling player speed, gravity, jump height, max stamina, and current stamina
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float maxStamina = 100f;
    public float currentStamina;

    //Initializes the ground check that makes sure the player is on the ground before they can jump again
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    private void Start()
    {
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
           velocity.y = -2f;
        }

        //Gets the position of the x and z axis for camera movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Moves the camera
        Vector3 move = transform.right * x + transform.forward * z;

        //Tests if player is on the ground so they can jump and then gets the distance
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            Sprinting(0.2f);
            controller.Move(move * (speed * 1.75f) * Time.deltaTime);
            
            if(regen != null)
            {
                StopCoroutine(regen);
            }
            
            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }


        void Sprinting(float staminaLoss)
        {
            currentStamina -= staminaLoss;
            sprintBar.setStamina(currentStamina);
        }
    }

    //This Coroutine checks if they player has let off the sprint key for a certain amount of time to begin regenerating the stamina
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            sprintBar.setStamina(currentStamina);
            yield return regenTick;
        }
        regen = null;
    }
}
