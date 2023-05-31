using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    private Vector2 direction;

    private void Start()
    {
        InitializeMovement();
    }

    private void Update()
    {
        // Move the object in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the collision normal and reflect the direction vector
        Vector2 collisionNormal = collision.GetContact(0).normal;
        Vector2 collidedObjectVelocity = collision.rigidbody ? collision.rigidbody.velocity : Vector2.zero;

        direction = Vector2.Reflect(direction, collisionNormal).normalized;

        if(collidedObjectVelocity.x != 0) {
            // Calculate the dot product between the collision normal and the velocity of the collided object
            float relativeMotion = Vector2.Dot(collisionNormal, collidedObjectVelocity);

            // Check if the magnitude of collidedObjectVelocity is below a threshold
            float velocityThreshold = 0.1f;
            if (collidedObjectVelocity.magnitude < velocityThreshold)
            {
                relativeMotion = 0f;
            }

            // Calculate the reflected direction
            direction = Vector2.Reflect(direction, collisionNormal).normalized;

            // Adjust the angle of reflection based on the relative motion
            float angleAdjustment = Mathf.Atan2(relativeMotion, direction.y) * Mathf.Rad2Deg;
            direction = Quaternion.Euler(0f, 0f, angleAdjustment) * direction;
        }
    }  

    private void InitializeMovement() {
        // Calculate a random angle within the range of -22.5 to -67.5 degrees
        float angle = Random.Range(-67.5f, -22.5f);

        // Convert the angle to radians
        float radianAngle = angle * Mathf.Deg2Rad;

        // Calculate the x and y components of the direction vector
        float directionX = Mathf.Cos(radianAngle);
        float directionY = Mathf.Sin(radianAngle);

        // Randomly set the sign of the x-component
        directionX *= Random.Range(-1f, 1f);

        // Set the direction vector
        direction = new Vector2(directionX, directionY).normalized;
    }
}