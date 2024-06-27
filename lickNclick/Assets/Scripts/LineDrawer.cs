using System.Collections;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject linePrefab;
    public Material lineMaterial;
    public float resolution = 0.1f;
    public float fadeTime = 2f;

    private LineRenderer currentLineRenderer;
    private Vector3 lastMousePosition;

    void Update()
    {
        if (MouseManager.Instance.isPressed)
        {
            if (currentLineRenderer == null)
            {
                CreateNewLine();
                lastMousePosition = GetMouseWorldPosition();
                AddPointToLine(lastMousePosition);
            }

            Vector3 currentMousePosition = GetMouseWorldPosition();
            if (Vector3.Distance(lastMousePosition, currentMousePosition) > resolution)
            {
                lastMousePosition = currentMousePosition;
                AddPointToLine(currentMousePosition);
            }
        }

        if (!MouseManager.Instance.isPressed && currentLineRenderer != null)
        {
            StartCoroutine(FadeAndDestroy(currentLineRenderer, fadeTime));
            currentLineRenderer = null;
        }
    }

    private void CreateNewLine()
    {
        GameObject lineObject = Instantiate(linePrefab);
        currentLineRenderer = lineObject.GetComponent<LineRenderer>();
        currentLineRenderer.positionCount = 0;
        currentLineRenderer.material = new Material(lineMaterial); // Use a copy of the material to avoid changing the original
    }

    private void AddPointToLine(Vector3 point)
    {
        currentLineRenderer.positionCount++;
        currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, point);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 3f; // Set this value according to your needs
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private IEnumerator FadeAndDestroy(LineRenderer lineRenderer, float fadeTime)
    {
        Material material = lineRenderer.material;
        Color startColor = material.color;
        float startAlpha = startColor.a;
        float rate = 1.0f / fadeTime;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color color = material.color;
            color.a = Mathf.Lerp(startAlpha, 0, progress);
            material.color = color;

            progress += rate * Time.deltaTime;

            yield return null;
        }

        Destroy(lineRenderer.gameObject);
    }
}
