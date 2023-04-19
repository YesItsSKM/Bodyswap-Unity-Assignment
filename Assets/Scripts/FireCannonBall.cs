using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FireCannonBall : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    public Transform cannonBallEjectionTransform;
    public float cannonballSpeed = 100f;

    public Button fireButton;

    public TextMeshProUGUI numberOfCannonBallsLeftText;

    public int numberOfCannonBalls = 5;

    public void Start()
    {
        numberOfCannonBallsLeftText.text = "Cannon Balls Left : " + numberOfCannonBalls.ToString();
    }

    public void LaunchCannonball()
    {
        if (numberOfCannonBalls > 0)
        {
            // Instantiate a new cannonball
            GameObject cannonball = Instantiate(cannonBallPrefab);

            // Set its position to the position of the cannon transform
            cannonball.transform.position = cannonBallEjectionTransform.position;

            // Set its rotation to match the rotation of the cannon transform
            cannonball.transform.rotation = cannonBallEjectionTransform.rotation;

            // Get the rigidbody component of the ball
            Rigidbody rb = cannonball.GetComponent<Rigidbody>();

            // Apply a force to the cannonball in the direction of the cannon's forward vector
            rb.AddForce(cannonBallEjectionTransform.forward * cannonballSpeed, ForceMode.VelocityChange);

            // Decrease the number of cannon balls left and update it on the screen
            numberOfCannonBalls--;
            numberOfCannonBallsLeftText.text = "Cannon Balls Left : " + numberOfCannonBalls.ToString();
        }

        // If no cannon ball is left, disable the fire button
        if (numberOfCannonBalls == 0)
        {
            fireButton.interactable = false;
        }
    }
}
