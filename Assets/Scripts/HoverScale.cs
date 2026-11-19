using UnityEngine;

public class HoverScale : MonoBehaviour
{
    public float scaleFactor = 1.2f; // Hoeveel de kinderen moeten schalen
    private Vector3[] originalScales; // Opslaan van de originele schaalgroottes
    private Transform[] children;

    void Start()
    {
        // Alle kinderen opslaan
        children = GetComponentsInChildren<Transform>();

        // Originele schalen opslaan
        originalScales = new Vector3[children.Length];
        for (int i = 0; i < children.Length; i++)
        {
            originalScales[i] = children[i].localScale;
        }
    }

    void OnMouseEnter()
    {
        // Schaal alle kinderen
        for (int i = 0; i < children.Length; i++)
        {
            children[i].localScale = originalScales[i] * scaleFactor;
        }
    }

    void OnMouseExit()
    {
        // Zet de schaal terug
        for (int i = 0; i < children.Length; i++)
        {
            children[i].localScale = originalScales[i];
        }
    }
}
