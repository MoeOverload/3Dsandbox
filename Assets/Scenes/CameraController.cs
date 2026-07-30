using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    //refernce to the player model
    public Transform player;

    //camera sensitivity
    public float sensitivity = 0.2f;

    float xRotation = 0f;
    float yRotaion = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInput = Mouse.current.delta.ReadValue();
        
        
        xRotation -= mouseInput.y * sensitivity* Time.deltaTime;
        yRotaion += mouseInput.x * sensitivity * Time.deltaTime;

       
        
        // stops camera from flipping
        xRotation = Mathf.Clamp(xRotation, -20f, 20f);
        transform.localRotation = Quaternion.Euler(xRotation,yRotaion,0f);

    }
}
