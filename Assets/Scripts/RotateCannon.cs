using UnityEngine;
using UnityEngine.UI;

public class RotateCannon : MonoBehaviour
{
    public Button rotateLeftButton;
    public Button rotateRightButton;

    public float maxRotation = 20f;
    public float rotateAmount = 5f;
    public GameObject cannon;

    private float currentRotation = 0f;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private float rotationTime = 0.5f;
    private float rotationTimer = 0f;
    private bool canRotateLeft = true;
    private bool canRotateRight = true;

    private void Start()
    {
        initialRotation = cannon.transform.localRotation;
        targetRotation = initialRotation;
    }

    private void Update()
    {
        if (isRotating)
        {
            rotationTimer += Time.deltaTime;
            float t = Mathf.Clamp01(rotationTimer / rotationTime);
            cannon.transform.localRotation = Quaternion.Lerp(initialRotation, targetRotation, t);
            if (rotationTimer >= rotationTime)
            {
                isRotating = false;
            }
        }
    }

    public void RotateLeft()
    {
        if (canRotateLeft)
        {
            if (currentRotation > -maxRotation)
            {
                currentRotation -= rotateAmount;
                currentRotation = Mathf.Clamp(currentRotation, -maxRotation, maxRotation);
                targetRotation = Quaternion.Euler(new Vector3(0f, currentRotation, 0f));
                initialRotation = cannon.transform.localRotation;
                isRotating = true;
                rotationTimer = 0f;
            }

            // Cap the rotation at maxRotation
            if (currentRotation <= -maxRotation)
            {
                currentRotation = -maxRotation;
                canRotateLeft = false;
                rotateLeftButton.interactable = false;
            }
        }

        // Enable the rotate right button if it was disabled
        if (!rotateRightButton.interactable)
        {
            canRotateRight = true;
            rotateRightButton.interactable = true;
        }
    }

    public void RotateRight()
    {
        if (canRotateRight)
        {
            if (currentRotation < maxRotation)
            {
                currentRotation += rotateAmount;
                currentRotation = Mathf.Clamp(currentRotation, -maxRotation, maxRotation);
                targetRotation = Quaternion.Euler(new Vector3(0f, currentRotation, 0f));
                initialRotation = cannon.transform.localRotation;
                isRotating = true;
                rotationTimer = 0f;
            }

            // Cap the rotation at maxRotation
            if (currentRotation >= maxRotation)
            {
                currentRotation = maxRotation;
                canRotateRight = false;
                rotateRightButton.interactable = false;
            }
        }

        // Enable the rotate right button if it was disabled
        if (!rotateLeftButton.interactable)
        {
            canRotateLeft = true;
            rotateLeftButton.interactable = true;
        }
    }
}
