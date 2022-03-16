using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private float movementSpeed;
    private Rigidbody playerRigidbody;
    private Vector2 inputVector;
    [SerializeField] private bool isInteracting;
    [SerializeField] private GameObject ceaseAndDesist;

    [Header("Instances")]
    private GameManager gameManager;
    private SoundManager soundManager;
    private UiManager uiManager;

    void Start()
    {
        gameManager = GameManager.instance;
        soundManager = SoundManager.instance;
        playerRigidbody = GetComponent<Rigidbody>();
        uiManager = UiManager.instance;
        ceaseAndDesist.SetActive(false);
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void OnMove(InputAction.CallbackContext context) // AD (Keyboard), Left Stick (Gamepad)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    public void OnInteraction(InputAction.CallbackContext context) // E (Keyboard), Button West (Gamepad)
    {
        isInteracting = context.performed;
    }

    void Movement()
    {
        Vector3 move = transform.right * inputVector.x + transform.forward * inputVector.y;
        playerRigidbody.MovePosition(playerRigidbody.position + move * movementSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isInteracting)
        {
            if(collision.gameObject.name == "CeaseAndDesistItem")
            {
                collision.gameObject.SetActive(false);
                ceaseAndDesist.SetActive(true);
            }

            if(collision.gameObject.name == "ButtonYes")
            {
                collision.gameObject.GetComponent<Animator>().Play("btnyes");
            }

            if (collision.gameObject.name == "ButtonNo")
            {
                collision.gameObject.GetComponent<Animator>().Play("btnno");
            }

            if (collision.gameObject.name == "Button")
            {
                collision.gameObject.GetComponent<Animator>().Play("btn");
                gameManager.LevelUp();
            }
        }
    }
}
