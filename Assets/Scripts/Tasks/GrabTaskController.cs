using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GrabTaskController : MonoBehaviour
{
    public TaskManager taskManagerRef;
    public TextMeshProUGUI grabtrackerText;
    public int numTaskCompleted;
    public GameObject[] grabTasks;
    public AudioClip grabbing;
    public AudioClip endGrab;
    public AudioClip completeRotate;
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
                rotateTracker = 0;
                taskManagerRef.grab1 = true;
                sfxPlayerRef.PlayOneShot(completeRotate);
                numTaskCompleted += 1;
                //  grabtrackerText.text = "Grab/Rotate Tasks Completed: 1/3";
            }
            else if(rotateTracker >= 100.0f && currObj.name == grabTasks[1].name )
            {
                rotateTracker = 0;
                taskManagerRef.grab2 = true;
                sfxPlayerRef.PlayOneShot(completeRotate);
                numTaskCompleted += 1;
                //   grabtrackerText.text = "Grab/Rotate Tasks Completed: 2/3";
            }
            else if(rotateTracker >= 100.0f && currObj.name == grabTasks[2].name )
            {
                sfxPlayerRef.PlayOneShot(completeRotate);
                rotateTracker = 0;
                taskManagerRef.grab3 = true;
                numTaskCompleted += 1;
               // grabtrackerText.text = "Grab/Rotate Tasks Completed: 3/3";

            }
            else if (rotateTracker >= 100.0f && currObj.name == grabTasks[3].name)
            {
                rotateTracker = 0;
                taskManagerRef.grab4 = true;
                sfxPlayerRef.PlayOneShot(completeRotate);
                numTaskCompleted += 1;
                //   grabtrackerText.text = "Grab/Rotate Tasks Completed: 2/3";
            }
            else if (rotateTracker >= 100.0f && currObj.name == grabTasks[4].name)
            {
                sfxPlayerRef.PlayOneShot(completeRotate);
                rotateTracker = 0;
                taskManagerRef.grab5 = true;
                numTaskCompleted += 1;
                // grabtrackerText.text = "Grab/Rotate Tasks Completed: 3/3";

            }
            else if (rotateTracker >= 100.0f && currObj.name == grabTasks[5].name)
            {
                sfxPlayerRef.PlayOneShot(completeRotate);
                rotateTracker = 0;
                taskManagerRef.grab6 = true;
                numTaskCompleted += 1;
                // grabtrackerText.text = "Grab/Rotate Tasks Completed: 3/3";

            }

        }
        if(numTaskCompleted > 6)
        {
            numTaskCompleted = 6;
        }
        grabtrackerText.text = "Grab/Rotate Tasks Completed: " + numTaskCompleted.ToString() + "/6";

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
