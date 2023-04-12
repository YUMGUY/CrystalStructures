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
    void Start()
    {
        print(Vector3.Distance(pos1.transform.position, pos2.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
