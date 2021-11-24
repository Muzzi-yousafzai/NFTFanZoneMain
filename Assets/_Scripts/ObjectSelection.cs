using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation.Samples;

public class ObjectSelection : MonoBehaviour
{
   
   

   
    private void Awake()
    {
        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;
        
        
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject model in objs)
        {
            model.GetComponentInChildren<Ring>().gameObject.SetActive(false);
        }
    }
    private void OnMouseUp()
    {
        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;

        TouchCounter.Instance.DeleteButton.SetActive(false);
        TouchCounter.Instance.Addbutton.interactable = true;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject model in objs)
        {
            model.GetComponentInChildren<Ring>().gameObject.SetActive(false);
        }
        GetComponentInChildren<Ring>().gameObject.SetActive(false );
        // transform.GetChild(0).gameObject.SetActive(false);
        //ModelLoader.Instance.newRing.SetActive(false);
    }
    private void OnMouseDown()
    {
        gameObject.GetComponent<LeanTouch>().enabled = true;
        gameObject.GetComponent<LeanPinchScale>().enabled = true;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = true;
        
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject model in objs)
        {
            model.GetComponentInChildren<Ring>().gameObject.SetActive(false);
        }
        GetComponentInChildren<Ring>().gameObject.SetActive(true);
        TouchCounter.Instance.Addbutton.interactable = false;
        TouchCounter.Instance.DeleteButton.SetActive(true);
        
        //transform.GetChild(0).gameObject.SetActive(true);
        //ModelLoader.Instance.newRing.SetActive(true);
    }

}

