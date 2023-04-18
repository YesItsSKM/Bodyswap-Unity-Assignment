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
        numberOfCannonBallsLeftText.text = "Cannon Balls Left - " + numberOfCannonBalls.ToString();
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

            // Add a rigidbody component to enable physics
            Rigidbody rb = cannonball.AddComponent<Rigidbody>();

            // Set the mass and drag of the rigidbody
            rb.mass = 10f;
            rb.drag = 0.5f;

            // Apply a force to the cannonball in the direction of the cannon's forward vector
            rb.AddForce(cannonBallEjectionTransform.forward * cannonballSpeed, ForceMode.VelocityChange);

            numberOfCannonBalls--;

            numberOfCannonBallsLeftText.text = "Cannon Balls Left - " + numberOfCannonBalls.ToString();
        }

        if (numberOfCannonBalls == 0)
        {
            fireButton.interactable = false;
        }
    }
}
