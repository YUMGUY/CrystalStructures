using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ViewpointController : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider leftMover;
    public Transform teleportInLocation;
    public Transform teleportOutLocation;
    public Animator transitionRef;
    public GameObject player;
    public TaskManager taskTextRef__;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateFadeTransitionInside()
    {
        print("Transitioned to different viewpoint");
        transitionRef.SetTrigger("transition_in");
    }
    public void ActivateFadeTransitionOutside()
    {
        print("Transitioned to different viewpoint");
        transitionRef.SetTrigger("transition_out");
    }

    public void TeleportInside()
    {
        taskTextRef__.taskText.text = "Current View: Interior";
        player.transform.position = teleportInLocation.position;
    }

    public void TeleportOutside()
    {
        taskTextRef__.taskText.text = "Current View: Exterior";
        player.transform.position = teleportOutLocation.position;
    }

    public void EnableMovement()
    {
        leftMover.moveSpeed = 5;
    }
    public void DisableMovement()
    {
        leftMover.moveSpeed = 0;
    }
}
