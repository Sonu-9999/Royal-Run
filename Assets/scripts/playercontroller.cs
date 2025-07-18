
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroller : MonoBehaviour
{
    [SerializeField] float movespeed = 5f;
    [SerializeField] float xclamp = 5f;
    [SerializeField] float zclamp = 5f;

    Vector2 movement;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
        handlemovement();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        
    }
    void handlemovement()
    {
        Vector3 currentposition = rb.position;  //Transform.position is not used here to avoid issues with Rigidbody physics
        Vector3 movedirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newposition = currentposition + movedirection * (movespeed * Time.fixedDeltaTime);

        newposition.x=Mathf.Clamp(newposition.x, -xclamp, xclamp);
        newposition.z=Mathf.Clamp(newposition.z, -zclamp, zclamp);
        rb.MovePosition(newposition);  //Moves the player to the new position
    }
}
