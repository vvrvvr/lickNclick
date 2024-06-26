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
    // Start is called before the first frame update
    void OnMouseEnter()
    {
        isHovering = true;
    }
    void OnMouseExit()
    {
        isHovering = false;
    }
    
    void OnMouseDown()
    {
        ChangeCamera();
    }

    void Update()
    {
        if (isHovering)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * 1.1f, Time.deltaTime * 10f);
        }
        else if (!isHovering)
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
