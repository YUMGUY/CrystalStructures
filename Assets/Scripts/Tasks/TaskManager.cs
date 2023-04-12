using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    public MeasurementController measureRef;

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
    public bool measure1ex;
    public bool measure2ex;
    public bool measure3ex;
    [Header("Final Flags")]
    public bool finishedEXmeasure;
    public bool finishedINmeasure;
    public bool finishedExterior;
    public bool finishedInterior;
    public bool playFinishEx;
    public bool playFinishIn;

    public bool startedCoroutine;
    public Button exTo_interiorButton;
    public Button exTo_interiorButton2;
    [Header("External Measure Text")]
    public TextMeshProUGUI externalMeasuretext;
    public int ex_measured;

    private void Awake()
    {
        ex_measured = 0;
        numMeasured = 0;
        int start = Random.Range(0, 2);
        if(start == 0)
        {
            finishedGrabTask = false;
            grabTask = true;
            currentGrabTaskIndex = 0;
            measureTask = false;
            ExternalView = true;
            InternalView = false;
        }
        else
        {
            InternalView = true;
            ExternalView = false;
           // grabTask = true;
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
        //  *do it once for each random task, branch off *
        // grab/rotate exterior task
        if(grab1 && grab2 && grab3 && finishedGrabTask == false)
        {
            print("finished grab");
            //enable measure task button for now ********
            exTo_interiorButton.interactable = true;
            finishedGrabTask = true;
            // either begin measuring or grabbing, player choice
            // start it once
        }
        // exterior measuring
        CheckExternalMeasure();
        if(measureRef.measure1 >= 3 && finishedEXmeasure == false)
        {
            print("finished measuring exterior, currently also finishes finishedExMeasure");
            finishedEXmeasure = true;
            finishedEXmeasure = true;
        }

        // done at exterior
        if(finishedEXmeasure == true && finishedGrabTask && ExternalView == false)
        {
            // show interior button
            exTo_interiorButton.interactable = true;
            exTo_interiorButton2.interactable = true;
            finishedExterior = true;
        }
        // check instruction text
        externalMeasuretext.text = "Measure Tasks Completed: " + ex_measured.ToString() + "/3";
    }

    public void CheckExternalMeasure()
    {
        if(measureRef.measure1 >= 3 && measure1ex == false)
        {
            print("done 1em");
            ex_measured++;
            measure1ex = true;
        }
        if (measureRef.measure2 >= 3 && measure2ex == false)
        {
            print("done 2em");
            ex_measured++;
            measure2ex = true;
        }
        if (measureRef.measure3 >= 3 && measure3ex == false)
        {
            print("done 3em");
            ex_measured++;
            measure3ex = true;
        }
    }

    public void CheckInternalMeasureCenter()
    {

    }

    //public IEnumerator CompletedTask(string task)
    //{
    //    startedCoroutine = true;
    //    taskText.text = "You Completed";
    //    yield return new WaitForSeconds(3f);
    //    switch(task)
    //    {
    //        case "External":
    //            measureTask = true;
    //            grabTask = false;
    //            taskText.text = "Current View: Internal";
    //            break;
    //        case "Internal":
    //            taskText.text = "Current View: External";
    //            break;
    //    }

    //    print("finished announcement");
    //    yield return null;
    //    startedCoroutine = false;
    //    yield return null;
    //}
}
