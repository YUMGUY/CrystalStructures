using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeasurementController : MonoBehaviour
{
    // Start is called before the first frame update
    public XRRayInteractor rayInteractor_right;
    public XRRayInteractor rayInteractor_left;
    public bool selected1;
    public bool selected2;
    public GameObject startingPoint;
    public GameObject endingPoint;

    void Start()
    {
        selected1 = false;
        selected2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // left or right hand can select atoms ( the balls )
    public void Measure()
    {
        if(selected1 == false)
        {
            selected1 = true;
        }
        else if(selected1 == true && selected2 == false)
        {
            selected2 = true;
            // do checking, the measuring event is set off by pressing the grip button on either left or right controller
            RaycastHit raycastHit;
            if (rayInteractor_right.TryGetCurrent3DRaycastHit(out raycastHit) || rayInteractor_left.TryGetCurrent3DRaycastHit(out raycastHit))
            {
                // check if the 2nd object is still the first object
                if(raycastHit.collider.name == startingPoint.name)
                {
                    print("you tried to measure with only 1 object");
                    selected2 = false;
                    return; // just in case for some reason
                }
            }
        }
        // measure the distance between the 2 molecules
        else if(selected1 == true && selected2 == true)
        {
            
        }
        
    }

    public void TestMeasurement()
    {
        print("measured");
        RaycastHit raycastHit;
        if(rayInteractor_right.TryGetCurrent3DRaycastHit(out raycastHit))
        {
            print(raycastHit.collider.gameObject.name);
        }
        // put line renderer reference
        // set the 2 transforms
        // color the 2 selected spheres

        // either do clear selected gameobject properties using button or just clicking on a different sphere
        
    }
}
