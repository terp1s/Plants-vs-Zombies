using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizing : MonoBehaviour
{
    float ratio;
    public GameObject square;

    void RadsiNe()
    {
        Transform ogParent = gameObject.transform.parent;
        square = GameObject.Find("Square");
        gameObject.transform.SetParent(square.transform);

        //var baseRatio = gameObject.transform.parent.GetComponent<SpriteRenderer>().size.x / gameObject.GetComponent<SpriteRenderer>().size.x;
        var baseRatio = gameObject.transform.parent.lossyScale.x / gameObject.transform.lossyScale.x;

        if (gameObject.CompareTag("Zombie"))
        {
            ratio = 1.0f;
        }
        else if (gameObject.CompareTag("Plant"))
        {
            ratio = 1.0f;
        }
        else if (gameObject.CompareTag("Ammo"))
        {
            ratio = 0.25f;
        }
        else if (gameObject.CompareTag("Sun"))
        {
            ratio = 1f;
        }

        //gameObject.transform.localScale.Set(1f, 1f);

        Vector3 scale = gameObject.transform.localScale;
        scale.Set(ratio * baseRatio, ratio * baseRatio, 1);
        gameObject.transform.localScale = scale;

        //gameObject.transform.SetParent(ogParent);
    }

    public GameObject parentPrefab; // Assign your parent prefab in the inspector
    public GameObject childPrefab;  // Assign your child prefab in the inspector

    void Start()
    {
        parentPrefab = GameObject.Find("Square");
        childPrefab = gameObject;

        ResizeChildToParentSize(childPrefab, parentPrefab);
    }
    
    void ResizeChildToParentSize(GameObject child, GameObject parent)
    {
        // Get the SpriteRenderer components
        SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();
        SpriteRenderer parentRenderer = parent.GetComponent<SpriteRenderer>();

        // Check if both child and parent have SpriteRenderer components
        if (childRenderer != null && parentRenderer != null)
        {
            // Set the local scale of the child to match the parent's local scale
            child.transform.localScale = Vector3.one;

            // Get the size of the parent and child sprites
            Vector2 parentSize = parentRenderer.sprite.bounds.size;
            Vector2 childSize = childRenderer.sprite.bounds.size;

            // Adjust the local scale of the child based on the parent's size
            // Calculate the aspect ratio of the child
            float childAspectRatio = childSize.x / childSize.y;

            // Set the local scale of the child based on the parent's size and maintaining aspect ratio
            float newChildWidth = parentSize.x;
            float newChildHeight = newChildWidth / childAspectRatio;

            child.transform.localScale = new Vector3(newChildWidth / (7f * childSize.x), newChildHeight / (5f * childSize.x), 1f);
        }
        else
        {
            Debug.LogError("Both child and parent objects must have SpriteRenderer components for resizing to work.");
        }
    }
}
