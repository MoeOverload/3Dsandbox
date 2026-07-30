
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    //get refernce to the character controller
    CharacterController controller;
    PlayerControls  controls;
    Vector2 moveInput;
    //set speed variable
    public float speed = 5f;
    //refernce to the camera
    public Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //refernce the character controller on scene start
        controller = GetComponent<CharacterController>();
        controls = new PlayerControls();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;

        Vector3 movement = forward * moveInput.y + right *moveInput.x;
        movement.Normalize();
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
        controller.Move(movement * speed * Time.deltaTime);
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }
}
