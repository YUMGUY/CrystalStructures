using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ViewpointController : MonoBehaviour
{
    public XRInteractorLineVisual leftHandRay;
    public XRInteractorLineVisual rightHandRay;
    public ActionBasedContinuousMoveProvider leftMover;
    public Transform teleportInLocation;
    public Transform teleportOutLocation;
    public Transform startingFloorPos;
    public Transform birdEyePos;
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
        taskTextRef__.InternalView = true;
        taskTextRef__.ExternalView = false;
        taskTextRef__.taskText.text = "Current View: Interior";
        player.transform.position = teleportInLocation.position;
        leftHandRay.lineLength = 12;
        rightHandRay.lineLength = 12;
    }

    public void TeleportOutside()
    {
        taskTextRef__.InternalView = false;
        taskTextRef__.ExternalView = true;
        taskTextRef__.taskText.text = "Current View: Exterior";
        player.transform.position = teleportOutLocation.position;
        leftHandRay.lineLength = 12;
        rightHandRay.lineLength = 12;
    }

    public void EnableMovement()
    {
        leftMover.moveSpeed = 5;
    }
    public void DisableMovement()
    {
        leftMover.moveSpeed = 0;
    }
    public void FloorViewTransition()
    {
       // taskTextRef__.taskText.text = "Current View: Interior (Floor)";
        player.transform.position = startingFloorPos.position;
        leftHandRay.lineLength = 12;
        rightHandRay.lineLength = 12;
    }

    public void BirdEyeViewpoint()
    {
        taskTextRef__.taskText.text = "Current View: Exterior Overview";
        player.transform.position = birdEyePos.position;
        leftHandRay.lineLength = 150;
        rightHandRay.lineLength = 150;
    }
}
