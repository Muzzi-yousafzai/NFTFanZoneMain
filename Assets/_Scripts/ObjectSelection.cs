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
<<<<<<< HEAD
       
=======
        foreach (GameObject model in objs)
        {
            model.transform.GetChild(0).gameObject.SetActive(false);
        }
>>>>>>> parent of 40de708 (Model from server)
    }
    private void OnMouseUp()
    {
        gameObject.GetComponent<LeanTouch>().enabled = false;
        gameObject.GetComponent<LeanPinchScale>().enabled = false;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;
<<<<<<< HEAD
        RingManager.DeleteButton.SetActive(false);
        RingManager.AddButton.enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
=======
        gameObject.GetComponent<LeanDragTranslate>().enabled = false;

>>>>>>> parent of 40de708 (Model from server)
        ModelLoader.Instance.newRing.SetActive(false);
    }
    private void OnMouseDown()
    {
<<<<<<< HEAD
        gameObject.GetComponent<LeanTouch>().enabled = true;
        gameObject.GetComponent<LeanPinchScale>().enabled = true;
        gameObject.GetComponent<LeanTwistRotateAxis>().enabled = true;
        RingManager.DeleteButton.SetActive(true);
        RingManager.AddButton.enabled = false;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
       
        transform.GetChild(0).gameObject.SetActive(true);
=======
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
>>>>>>> parent of 40de708 (Model from server)
        ModelLoader.Instance.newRing.SetActive(true);
    }

}

