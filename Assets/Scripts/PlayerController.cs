using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Editable in the Inspector to easily tweak movement speed
    public float speed = 8f;

    private Rigidbody rb;

    //Start is called once, before the first frame update
    void Start()
    {
        // Cache the Rigidbody component attached to this GameObject 
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called on a fixed timestep, in sync with the physics engine
    // Since we're moving a Rigidbody, movement logic belongs here, not in Update()
    void FixedUpdate()
    {
        //GetAxis("Horizontal") reads A/D and left/Right
        //GetAxis("Vertical") reads W/S and up/Down 
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Build a movement vector vector the X/Z plane only -- Y stays at 0,
        // so gravity (not this script) is the only thing affecting vertical movement
        Vector3 movement = new Vector3(moveX, 0f, moveZ) * speed * Time.fixedDeltaTime;

        // Move the Rigidbody by this offset, respecting physics collisions
        // (won't let the Player clip through maze walls)
        rb.MovePosition(rb.position + movement);
    }
}
