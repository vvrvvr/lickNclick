using System;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 lastMousePosition;
    private bool isHovering = false;
    private bool isDragging = false;

    public Texture2D cursorTexture;

    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseEnter()
    {
        isHovering = true;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        isHovering = false;
    }

    void OnMouseDown()
    {
        lastMousePosition = Input.mousePosition;
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isHovering)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * 1.1f, Time.deltaTime * 10f);
        }
        else if (!isHovering && !isDragging)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * 10f);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        // Проверяем, зажата ли кнопка мыши и находится ли курсор над объектом
        if (Input.GetMouseButton(0) && isHovering)
        {
            if (!isDragging)
            {
                lastMousePosition = Input.mousePosition;
                isDragging = true;
            }

            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotationX = delta.y * speed * Time.deltaTime;
            float rotationY = -delta.x * speed * Time.deltaTime;
            Vector3 rotation = new Vector3(rotationX, rotationY, 0);
            transform.Rotate(Camera.main.transform.TransformDirection(rotation), Space.World);
            lastMousePosition = Input.mousePosition;
        }
        else
        {
            isDragging = false;
        }
    }
}