using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class MeasurementController : MonoBehaviour
{
    // Start is called before the first frame update
    public XRRayInteractor rayInteractor_right;
    public XRRayInteractor rayInteractor_left;
    public bool selected1;
    public bool selected2;
    public Material selectedMat;
    public Material originalMat1;
    public Material originalMat2;
    public GameObject startingPoint;
    public GameObject endingPoint;
    public LineRenderer cameraLine;
    public TextMeshProUGUI measureText;
    public GameObject testCube1;
    public GameObject testCube2;

    void Start()
    {
        measureText.text = "";
        cameraLine.positionCount = 2;
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
            RaycastHit raycastHit;
            if (rayInteractor_right.TryGetCurrent3DRaycastHit(out raycastHit) || rayInteractor_left.TryGetCurrent3DRaycastHit(out raycastHit))
            {
                originalMat1 = raycastHit.collider.GetComponent<Renderer>().material;
                raycastHit.collider.GetComponent<MeshRenderer>().sharedMaterial = selectedMat;
                startingPoint = raycastHit.collider.gameObject;
                measureText.text = "Measuring";
                return;
            }
        }
        else if(selected1 == true && selected2 == false)
        {
            selected2 = true;
            // do checking, the measuring event is set off by pressing the grip button on either left or right controller
            RaycastHit raycastHit;
            if (rayInteractor_right.TryGetCurrent3DRaycastHit(out raycastHit) || rayInteractor_left.TryGetCurrent3DRaycastHit(out raycastHit))
            {
                // check if the 2nd object is still the first object
                if(raycastHit.collider.name == startingPoint.name || raycastHit.collider.CompareTag("Respawn"))
                {
                    print("you tried to measure with only 1 object or hit the plane");
                    selected2 = false;
                    
                    return; // just in case for some reason
                }
                else
                {
                    endingPoint = raycastHit.collider.gameObject;
                    originalMat2 = raycastHit.collider.GetComponent<Renderer>().material;
                    raycastHit.collider.GetComponent<MeshRenderer>().sharedMaterial = selectedMat;
                    selected2 = true;
                    print(endingPoint.name);
                }
                // have 2 objects selected
                // measure the distance between the 2 molecules
                print(Vector3.Distance(startingPoint.transform.position, endingPoint.transform.position));
                measureText.text = Vector3.Distance(startingPoint.transform.position, endingPoint.transform.position).ToString("N2");
                //cameraLine.enabled = true;
                //print(endingPoint.transform.position);
                //testCube1.transform.position = startingPoint.transform.position;
                //testCube2.transform.position = endingPoint.transform.position;
                //testCube1.transform.rotation = Quaternion.identity;
                //testCube2.transform.rotation = Quaternion.identity;
                //cameraLine.SetPosition(0, testCube1.transform.position);
                //cameraLine.SetPosition(1, testCube2.transform.position);
            }
        }
        else if(selected1 == true && selected2 == true)
        {
            ResetMeasure();
        }
        
    }

    public void TestMeasurement()
    {
        //RaycastHit raycastHit;
        //if(rayInteractor_right.TryGetCurrent3DRaycastHit(out raycastHit))
        //{
        //    print(raycastHit.collider.gameObject.name);
        //}
        // put line renderer reference
        // set the 2 transforms
        // color the 2 selected spheres

        // either do clear selected gameobject properties using button or just clicking on a different sphere
        
    }

    public void ResetMeasure()
    {
      //  cameraLine.enabled = false;
        measureText.text = "";
        startingPoint.GetComponent<MeshRenderer>().sharedMaterial = originalMat1;
        endingPoint.GetComponent<MeshRenderer>().sharedMaterial = originalMat2;
        selected1 = false;
        selected2 = false;
    }
}
