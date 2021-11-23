using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation.Samples;

public class ObjectSelection : MonoBehaviour
{
    public GameObject[] Prefabs;

    public RingManager RingManager;
   
    private void Awake()
    {
        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;
      
        
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
       
    }
    private void OnMouseUp()
    {
        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;
        RingManager.DeleteButton.SetActive(false);
        RingManager.AddButton.enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
        ModelLoader.Instance.newRing.SetActive(false);
    }
    private void OnMouseDown()
    {
        gameObject.GetComponent<LeanTouch>().enabled = true;
        gameObject.GetComponent<LeanPinchScale>().enabled = true;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = true;
        RingManager.DeleteButton.SetActive(true);
        RingManager.AddButton.enabled = false;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
       
        transform.GetChild(0).gameObject.SetActive(true);
        ModelLoader.Instance.newRing.SetActive(true);
    }

}

