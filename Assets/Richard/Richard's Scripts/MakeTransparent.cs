using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    [SerializeField] private float transparency = 0.5f; // Set your desired transparency level between 0 (fully transparent) and 1 (fully opaque)

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        // Check if the Renderer and Material exist
        if (renderer != null)
        {
            Material material = renderer.material;

            // Check if the material has an '_BaseColor' property (used in URP)
            if (material.HasProperty("_BaseColor"))
            {
                Color baseColor = material.GetColor("_BaseColor");
                baseColor.a = transparency; // Set transparency
                material.SetColor("_BaseColor", baseColor);
            }
            else if (material.HasProperty("_Color"))
            {
                // Fallback for materials using the '_Color' property instead
                Color color = material.color;
                color.a = transparency;
                material.color = color;
            }
        }
    }
}
