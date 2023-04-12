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
    public bool rotate;
    public GameObject currObj;
    public Transform originalPos;
    public float rotateSpeed;
    public float rotateTracker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate == true && currObj != null)
        {
            currObj.transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
            rotateTracker += rotateSpeed * Time.deltaTime;

        }
        if(currObj != null)
        {
            if (rotateTracker >= 100.0f && currObj.name == grabTasks[0].name)
            {
                print("do it");
                rotateTracker = 0;
                taskManagerRef.grab1 = true;
                taskManagerRef.grab2 = true;
                taskManagerRef.grab3 = true;
            }
        }
        
        // add saftey to object position

    }

    public void GrabSound()
    {
        rotateTracker = 0;
        
       sfxPlayerRef.PlayOneShot(grabbing);
    }
    public void EndGrab()
    {
        originalPos = null;
        currObj = null;
        sfxPlayerRef.PlayOneShot(endGrab);
    }
    // trigger function
    public void RotateObj(Transform location)   
    {
        //if(location.name == grabTasks[0].name)
        //{
        //    print(grabTasks[0].transform.rotation.eulerAngles);
        //    //grabTasks[0].transform.rotation = Quaternion.Euler(0, , 0);
        //}
        originalPos = location;
        currObj = location.gameObject;
        rotate = true;
        
    }
    public void ReturnStructure()
    {
        currObj.transform.position = originalPos.position;
    }

    public void RotateOff()
    {
        print("stop rotating");
        rotate = false;
    }
    
    
}
