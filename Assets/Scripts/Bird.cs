using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public float velocity = 10f;
    private LogicScript logic;
    protected bool birdIsAlive = true;
    public float maxDownwardTilt = -90f;  // Maximum angle when falling down
    public float maxUpwardTilt = 35f;     // Angle when flapping up
    public float tiltSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            birdRigidBody.velocity = Vector2.up * velocity;
        }
        // Calculate the rotation angle based on the vertical velocity
        float angle;
        if (birdRigidBody.velocity.y > 0)
        {
            // Tilts upward while going up
            angle = Mathf.Lerp(0, maxUpwardTilt, birdRigidBody.velocity.y / velocity);
        }
        else
        {
            // Tilts downward while falling down
            angle = Mathf.Lerp(0, maxDownwardTilt, -birdRigidBody.velocity.y / velocity);
        }

        // Smoothly apply rotation for a natural tilt effect
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), tiltSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == 6)
        {
            birdRigidBody.velocity = new Vector2(5, 5);
            logic.gameOver();
            birdIsAlive = false;
        }
    }
}
