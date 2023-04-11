using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTaskController : MonoBehaviour
{
    public TaskManager taskManagerRef;
    public GameObject[] grabTasks;
    public AudioClip grabbing;
    public AudioClip endGrab;
    public AudioSource sfxPlayerRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabTasks[0].transform.rotation.eulerAngles.y > 90 || grabTasks[0].transform.rotation.eulerAngles.y < -90)
        {
            taskManagerRef.grab1 = true;
            taskManagerRef.grab2 = true;
            taskManagerRef.grab3 = true;
        }
    }

    public void GrabSound()
    {
        sfxPlayerRef.PlayOneShot(grabbing);
    }
    public void EndGrab()
    {
        sfxPlayerRef.PlayOneShot(endGrab);
    }
    public void RotateObj(Transform location)   
    {
        print(location.rotation.eulerAngles.y);
    }
    
}
