using UnityEngine;

public class CubePileGenerator : MonoBehaviour
{
    public GameObject cubePrefab;                    // Reference to the cube prefab to be instantiated
    public int pyramidSize = 5;                      // Number of layers in the pyramid
    
    public float cubeSize;                           // Size of each cube
    public Transform parentTransform;                 // Reference to the parent transform for the pyramid
    public RandomColourGenerator colorGenerator;      // Reference to the script for generating random colors

    public float massOfCubes = 1f;                    // Mass of individual cubes
    float spaceBetweenLayers = 1f;                     // Spacing between layers

    void Start()
    {
        int cubesInLayer = pyramidSize;
        Vector3 currentPosition = parentTransform.position;

        spaceBetweenLayers = cubeSize + 1f;

        for (int layer = 0; layer < pyramidSize; layer++)
        {
            // Calculate the starting position of the current layer
            Vector3 layerStartPosition = new Vector3(
                parentTransform.position.x - ((cubesInLayer - 1) * cubeSize / 2f),
                currentPosition.y,
                parentTransform.position.z - ((cubesInLayer - 1) * cubeSize / 2f)
            );

            // Generate the grid of cubes for the current layer
            for (int i = 0; i < cubesInLayer; i++)
            {
                for (int j = 0; j < cubesInLayer; j++)
                {
                    // Instantiate a new cube
                    GameObject cube = Instantiate(cubePrefab);

                    // Set its position to the current position
                    Vector3 cubePosition = new Vector3(
                        layerStartPosition.x + (i * cubeSize),
                        currentPosition.y,
                        layerStartPosition.z + (j * cubeSize)
                    );
                    cube.transform.position = cubePosition;

                    // Set its scale to the desired cube size
                    cube.transform.localScale = Vector3.one * cubeSize;

                    // Set the color of the cube using the random color generator
                    cube.GetComponent<Renderer>().material.color = colorGenerator.GenerateRandomColor();

                    // Add a rigidbody component to enable physics
                    Rigidbody rb = cube.AddComponent<Rigidbody>();

                    // Set the mass and drag of the rigidbody
                    rb.mass = massOfCubes;
                    rb.drag = 0.5f;

                    // Set the cube's parent to the selected parent transform
                    cube.transform.parent = parentTransform;
                }
            }

            // Move to the next layer
            cubesInLayer--;
            currentPosition.y += spaceBetweenLayers;
        }
    }
}
