using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float sensitivity = 1f;

    private Vector3 moveDirection = Vector3.zero;

    CharacterController characterController;

    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.y -= moveDirection.y;

            //Multiply it by speed.
            moveDirection *= speed;

            //Jumping
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        if (Input.GetAxis("Mouse X") != 0)
        {
            transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }

        if (Input.GetAxis("Mouse Y") != 0)
        {
            transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * sensitivity, 0, 0);
        }

        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;

        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<PlayerInteraction>().Interact();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MainMenu");
        }
    }
}