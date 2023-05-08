using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RotateInterior : MonoBehaviour
{
    // Start is called before the first frame update
    public bool rotate;
    public TextMeshProUGUI childText;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
            //childText.text = "Rotate On";
        }

        else
        {
            //childText.text = "Rotate Off";
        }
    }

    public void RotateInteriorOn()
    {
        rotate = true;
    }
    public void RotateInteriorOff()
    {
        rotate = false;
    }
}
