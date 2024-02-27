using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public GameObject cube;
    public float distance = 2f; // Distance between the original cube and the duplicated cube
    public int maxClones = 10;  // Maximum number of clones to keep
    private bool hasDuplicated = false;

    private void Start()
    {
        // Invoke the DuplicateCube method every 1 second, starting after 2 seconds
        InvokeRepeating("DuplicateCube", 2f, 1f);
    }

    private void DuplicateCube()
    {
        if (!hasDuplicated)
        {
            // Get the position and rotation of the current cube
            Vector3 currentPosition = transform.position;
            Quaternion currentRotation = transform.rotation;

            // Calculate the position for the new cube in front of the current cube
            Vector3 newPosition = currentPosition + transform.forward * distance;

            // Instantiate a new cube at the calculated position and rotation
            GameObject newCube = Instantiate(cube, newPosition, currentRotation);

            // Optionally, you can set the new cube as a child of the current cube
            newCube.transform.parent = transform.parent; // Set the parent to the same parent as the current cube

            // Destroy the new clone immediately after adding it to the parent
            Destroy(newCube);

            // Set the flag to true after the first duplication
            hasDuplicated = true;

            // Keep track of the clones
            DestroyOldClones();
        }
    }

    private void DestroyOldClones()
    {
        // Destroy old clones if there are more than the maximum allowed
        Transform parentTransform = transform.parent;
        int childCount = parentTransform.childCount;

        if (childCount > maxClones)
        {
            Destroy(parentTransform.GetChild(0).gameObject);
        }
    }
}
