using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;
using System;
using UnityEngine.XR.ARFoundation.Samples;
using Lean.Touch;

public class ModelLoader : MonoBehaviour
{
    public string filepath;
    public ModelDownloader ModelDownloader;
    public GameObject result;
    public GameObject Ring;


  /* private void Awake()
    {
        result.GetComponent<LeanTouch>().enabled = false;
        result.GetComponent<LeanPinchScale>().enabled = false;
        result.GetComponent<LeanTwistRotateAxis>().enabled = false;
        result.GetComponent<LeanDragTranslate>().enabled = false;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject model in objs)
        {
            model.transform.GetChild(0).gameObject.SetActive(false);
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.L))
        {
            filepath = ModelDownloader.localURL;

            ImportGLTF();
        }
    }
    public void LoadModel()
    {
        {
            filepath = ModelDownloader.localURL;

            ImportGLTF();
        }
    }
    // Single thread


    private void ImportGLTF()
    {

        result = Importer.LoadFromFile(filepath);
        result.AddComponent<BoxCollider>();
        result.AddComponent<LeanTouch>();
        result.AddComponent<LeanPinchScale>();
        result.AddComponent<LeanTwistRotateAxis>();
        result.AddComponent<LeanDragTranslate>();
        result.gameObject.tag = "Target";
        result.GetComponentInChildren<Camera>().enabled = false;
        GameObject newRing = Instantiate(Ring, Vector3.zero, Quaternion.identity) as GameObject;
        newRing.transform.parent = result.transform;
        result.SetActive(false);
    }
    
    private void OnMouseUp()
    {
        result.GetComponent<LeanTouch>().enabled = false;
        result.GetComponent<LeanPinchScale>().enabled = false;
        result.GetComponent<LeanTwistRotateAxis>().enabled = false;
        result.GetComponent<LeanDragTranslate>().enabled = false;


    }
    private void OnMouseDown()
    {
        result.GetComponent<LeanTouch>().enabled = true;
        result.GetComponent<LeanPinchScale>().enabled = true;
        result.GetComponent<LeanTwistRotateAxis>().enabled = true;
        result.GetComponent<LeanDragTranslate>().enabled = true;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject model in objs)
        {
            model.transform.GetChild(0).gameObject.SetActive(false);
        }
        Ring.SetActive(true);
    }

}
