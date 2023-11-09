using UnityEngine;

public class TransparentMaterialSetter : MonoBehaviour
{
    [SerializeField] private float transparency = 0.5f; // Set this to your desired transparency

    void Start()
    {
        SetTransparency(transparency);
    }

    private void SetTransparency(float alpha)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            Material material = renderer.material;
            if (material != null)
            {
                // Assuming the material is using the standard shader, '_BaseMap' is the Albedo property
                if (material.HasProperty("_BaseMap"))
                {
                    Color newColor = material.GetColor("_BaseColor");
                    newColor.a = alpha;
                    material.SetColor("_BaseColor", newColor);
                }
                else // Fallback for non-URP materials
                {
                    Color newColor = material.color;
                    newColor.a = alpha;
                    material.color = newColor;
                }
            }
        }
    }
}

