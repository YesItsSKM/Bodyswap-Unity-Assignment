using UnityEngine;

public class RandomColourGenerator : MonoBehaviour
{
    public Color GenerateRandomColor()
    {
        return new Color(
            Random.value,
            Random.value,
            Random.value
        );
    }
}
