using UnityEngine;

public class RandomColourGenerator : MonoBehaviour
{
    // Return a random colour
    public Color GenerateRandomColour()
    {
        return new Color(
            Random.value,
            Random.value,
            Random.value
        );
    }
}
