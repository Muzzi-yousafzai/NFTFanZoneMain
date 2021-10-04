using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelection : MonoBehaviour
{
    public GameObject Ring;
    public GameObject[] Prefabs;
    private void Awake()
    {
        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;
        gameObject.GetComponent<LeanDragTranslate>().enabled = false;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject model in objs)
        {
            model.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void OnMouseUp()
    {
        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;
        gameObject.GetComponent<LeanDragTranslate>().enabled = false;
        

    }
    private void OnMouseDown()
    { 
       gameObject.GetComponent<LeanTouch>().enabled = true;
       gameObject.GetComponent<LeanPinchScale>().enabled = true;
       gameObject.GetComponent<LeanTwistRotateAxis>().enabled = true;
       gameObject.GetComponent<LeanDragTranslate>().enabled = true;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject model in objs)
        {
            model.transform.GetChild(0).gameObject.SetActive(false);
        }
        Ring.SetActive(true);
    }

}

