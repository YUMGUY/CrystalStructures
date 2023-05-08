using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public DistanceChecker distanceCheckerRef;
    public AudioSource sfxRef;
    public AudioClip completedSFX;
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
    public bool grab4;
    public bool grab5;
    public bool grab6;
    public bool finishedGrabTask;
    public bool measure1ex;
    public bool measure2ex;
    public bool measure3ex;
    public bool measure4ex;
    public bool measure5ex;
    public bool measure6ex;
    [Header("Final Flags")]
    public bool finishedEXmeasure;
    public bool finishedINmeasure;
    public bool finishedExterior;
    public bool finishedInterior;
    public bool playFinishEx;
    public bool playFinishIn;

    public bool startedCoroutine;
    public GameObject congratsScreen;
    public GameObject exteriorButtonStart;
    public GameObject rotateOnButton;
    public GameObject rotateOFFButton;
    public GameObject nextFloor;
    // public Button exTo_interiorButton;
    // public Button exTo_interiorButton2;
    [Header("External Measure Text")]
    public TextMeshProUGUI externalMeasuretext;
    public int ex_measured;

    private void Awake()
    {
        ex_measured = 0;
        numMeasured = 0;
        int start = Random.Range(0, 2);
        // external start
        if(start == 0)
        {
            finishedGrabTask = false;
            grabTask = true;
            currentGrabTaskIndex = 0;
            measureTask = false;
            ExternalView = true;
            InternalView = false;
        }
        // internal start
        else
        {
            InternalView = true;
            ExternalView = false;
           // grabTask = true;
           // measureTask = true;
            currentMeasureTaskIndex = 0;
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
            rotateOFFButton.SetActive(true);
            rotateOnButton.SetActive(true);
            nextFloor.SetActive(true);
            exteriorButtonStart.SetActive(true);
            playerRef.transform.position = internalLocations[0].position;
            taskText.text = "Current View: Internal";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  *do it once for each random task, branch off *
        // grab/rotate exterior task
        if(grab1 && grab2 && grab3 && grab4 && grab5 && grab6 && finishedGrabTask == false)
        {
            print("finished grab");
            //enable measure task button for now ********
          //  exTo_interiorButton.interactable = true;
            finishedGrabTask = true;
            // either begin measuring or grabbing, player choice
            // start it once
        }
        // exterior measuring
        CheckExternalMeasure();
        if(measure1ex && measure2ex && measure3ex && measure4ex && measure5ex && measure6ex && finishedEXmeasure == false)
        {
            print("finished measuring exterior, currently also finishes finishedExMeasure");
            finishedEXmeasure = true;
        }

        // done at exterior and interior
        if(finishedEXmeasure == true && finishedGrabTask == true && finishedINmeasure)
        {
         
            finishedExterior = true;
        }
        // check instruction text
        externalMeasuretext.text = "Measure Tasks Completed: " + ex_measured.ToString() + "/7";

        // final checking
        if(distanceCheckerRef.reachedEnd == true && finishedExterior == true && startedCoroutine == false)
        {
            StartCoroutine(CompletedTask());
            print("done");
        }

    }
    // also does internal, too lazy
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
        if (measureRef.measure4 >= 3 && measure4ex == false)
        {
            print("done 4em");
            ex_measured++;
            measure4ex = true;
        }
        if (measureRef.measure5 >= 3 && measure5ex == false)
        {
            print("done 5em");
            ex_measured++;
            measure5ex = true;
        }
        if (measureRef.measure6 >= 3 && measure6ex == false)
        {
            print("done 6em");
            ex_measured++;
            measure6ex = true;
        }
        if (measureRef.measureInt1 >= 3 && finishedINmeasure == false) 
        {
            finishedINmeasure = true;
            ex_measured++;
            print("done internal measure");

        }
    }

    public void CheckInternalMeasureCenter()
    {

    }

    public IEnumerator CompletedTask()
    {
        startedCoroutine = true;
        // play celebratory audio
        sfxRef.PlayOneShot(completedSFX);
        yield return new WaitForSeconds(1.5f);

        // enable congrats screen
        congratsScreen.SetActive(true);
        print("congrats screen open");
        yield return null;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
