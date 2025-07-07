using System.Collections.Generic;
using UnityEngine;

public class ObjectSorter : MonoBehaviour
{
    public List<Transform> childObjects = new List<Transform>();

    void Start()
    {
        // Step 1: Assign random Y scale
        foreach (Transform obj in childObjects)
        {
            float randomScaleY = Random.Range(0.5f, 3f);
            Vector3 scale = obj.localScale;
            scale.y = randomScaleY;
            obj.localScale = scale;
        }

        // Step 2: Sort using bubble sort based on Y scale
        for (int i = 0; i < childObjects.Count - 1; i++)
        {
            for (int j = 0; j < childObjects.Count - i - 1; j++)
            {
                if (childObjects[j].localScale.y > childObjects[j + 1].localScale.y)
                {
                    Transform temp = childObjects[j];
                    childObjects[j] = childObjects[j + 1];
                    childObjects[j + 1] = temp;
                }
            }
        }

        // Step 3: Position them based on sorted order
        for (int i = 0; i < childObjects.Count; i++)
        {
            childObjects[i].position = new Vector3(i * 2, 0, 0); // spacing on X-axis
        }
    }
}

