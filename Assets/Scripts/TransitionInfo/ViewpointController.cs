using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewpointController : MonoBehaviour
{

    public Transform teleportInLocation;
    public Transform teleportOutLocation;
    public Animator transitionRef;
    public GameObject player;
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
        player.transform.position = teleportInLocation.position;
    }

    public void TeleportOutside()
    {
        player.transform.position = teleportOutLocation.position;
    }
}
