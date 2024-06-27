using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ChangeCameraToChoosen : MonoBehaviour
{
    public CinemachineVirtualCamera ParentCam;
    public CinemachineVirtualCamera CamToChange;
    public bool isActive = false;
    private bool isHovering = false;

    void OnMouseEnter()
    {
        isHovering = true;
        if (MouseManager.Instance.isPressed)
        {
            ChangeCamera();
        }
    }

    void OnMouseExit()
    {
        isHovering = false;
    }

    void OnMouseDown()
    {
        if (isHovering)
        {
            ChangeCamera();
        }
    }

    void Update()
    {
        if (isHovering)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * 1.1f, Time.deltaTime * 10f);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * 10f);
        }
    }

    public void ChangeCamera()
    {
        Debug.Log("change camera");
        if (DialogueManager.instance != null)
        {
            DialogueManager.instance.FrogSay("startAgain");
        }
        ParentCam.Priority = 0;
        CamToChange.Priority = 100;
    }
}