using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance { get; private set; }

    public bool isPressed { get; private set; }
    public bool isDragging { get; private set; }

    private Vector3 lastMousePosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            isDragging = false;
        }

        if (isPressed)
        {
            if (Input.mousePosition != lastMousePosition)
            {
                isDragging = true;
            }
            lastMousePosition = Input.mousePosition;
        }
    }
}