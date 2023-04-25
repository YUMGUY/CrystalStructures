using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pos1;
    public GameObject pos2;

    // check waypoint system
    // use bool for stuff
    public GameObject playerVr;
    public Transform endPointpos;
    public Transform startPointpos;
    public bool reachedEnd;
    public AudioClip notifEnd;
    public AudioSource sfxRef;
    void Start()
    {
        reachedEnd = false;
       // print(Vector3.Distance(pos1.transform.position, pos2.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerVr.transform.position, endPointpos.position) < 20 && reachedEnd == false)
        {

            sfxRef.PlayOneShot(notifEnd);
            reachedEnd = true;
        }
    }
}
