using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TaskManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool grabTask;
    public int currentGrabTaskIndex;  
    public bool measureTask;
    public int currentMeasureTaskIndex;
    public bool ExternalView;
    public bool InternalView;
    public TextMeshProUGUI taskText;

    [Header("Task Locations and Numbers")]
    public GameObject playerRef;
    public Transform[] externalLocations;
    public Transform[] internalLocations;
    public Transform[] grabLocations;
    public Transform[] measureLocations;
    public int numMeasured;

    [Header("Task Flags")]
    // one for each structure
    public bool grab1;
    public bool grab2;
    public bool grab3;
    public bool finishedGrabTask;
    public bool measure1;
    public bool measure2;
    public bool measure3;
    public bool startedCoroutine;
    private void Awake()
    {
        numMeasured = 0;
        int start = Random.Range(0, 2);
        if(start == 0)
        {
            finishedGrabTask = false;
            grabTask = true;
            currentGrabTaskIndex = 0;
            measureTask = false;
            ExternalView = true;
            InternalView = true;
        }
        else
        {
            InternalView = true;
            ExternalView = false;
            grabTask = true;
           // measureTask = true;
            currentMeasureTaskIndex = 0;
            //grabTask = false;
        }
    }
    void Start()
    {
        if(ExternalView)
        {
            playerRef.transform.position = externalLocations[0].position;
            taskText.text = "Current View: External";
            
        }
        else
        {
            playerRef.transform.position = internalLocations[0].position;
            taskText.text = "Current View: Internal";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // do it once for each random task, branch off
        if(grab1 && grab2 && grab3 && finishedGrabTask == false)
        {
            print("finished grab");
            finishedGrabTask = true;
            // start it once
        }
      

    }

    public IEnumerator CompletedTask(string task)
    {
        startedCoroutine = true;
        taskText.text = "You Completed";
        yield return new WaitForSeconds(3f);
        switch(task)
        {
            case "External":
                measureTask = true;
                grabTask = false;
                taskText.text = "Current View: Internal";
                break;
            case "Internal":
                taskText.text = "Current View: External";
                break;
        }

        print("finished announcement");
        yield return null;
        startedCoroutine = false;
        yield return null;
    }
}
