using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelection : MonoBehaviour
{
    
    private void Awake()
    {
        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotate>().enabled = false;
    }
    private void OnMouseUp()
    {
        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotate>().enabled = false;
    }
    private void OnMouseDown()
    { 
       gameObject.GetComponent<LeanTouch>().enabled = true;
       gameObject.GetComponent<LeanPinchScale>().enabled = true;
       gameObject.GetComponent<LeanTwistRotate>().enabled = true;  
    }
   
}

