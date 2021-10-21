using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;
using System;
using UnityEngine.XR.ARFoundation.Samples;
using Lean.Touch;

public class ModelLoader : MonoBehaviour
{
    private string filepath;
    public ModelDownloader ModelDownloader;
    public GameObject result;
    public GameObject Ring;

    private void ImportGLTF()
    {

        result = Importer.LoadFromFile(filepath);
        result.AddComponent<BoxCollider>();
        result.AddComponent<LeanTouch>();
        result.AddComponent<LeanPinchScale>();
        result.AddComponent<LeanTwistRotateAxis>();
        result.AddComponent<LeanDragTranslate>();
        result.AddComponent<ObjectSelection>();
        result.gameObject.tag = "Target";
        result.GetComponentInChildren<Camera>().enabled = false;
        GameObject newRing = Instantiate(Ring, Vector3.zero, Quaternion.identity) as GameObject;
        newRing.transform.parent = result.transform;
        //result.SetActive(false);
    }

    
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

}
