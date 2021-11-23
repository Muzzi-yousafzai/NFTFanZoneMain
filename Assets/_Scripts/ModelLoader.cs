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
<<<<<<< HEAD
    public GameObject refObj;
    public PlaceOnPlane placeOnPlane;
    public GameObject loadingButton;
    public GameObject Load;
    public GameObject newRing;
=======
    public GameObject Ring;
    public GameObject newRing;
    public GameObject ShadowPlane;
>>>>>>> parent of 40de708 (Model from server)

    public static ModelLoader Instance = null;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }
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
        newRing = Instantiate(Ring, Vector3.zero, Quaternion.identity);
        GameObject newshadowplane = Instantiate(ShadowPlane, Vector3.zero, Quaternion.identity) as GameObject;
        newRing.transform.parent = result.transform;
        newshadowplane.transform.parent = result.transform;
        result.SetActive(false);
        newRing.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD

        
=======
        
        if(Input.GetKeyDown(KeyCode.L))
        {
            filepath = ModelDownloader.localURL;

            ImportGLTF();
        }
>>>>>>> parent of 40de708 (Model from server)
    }
    public void LoadModel()
    {
        {
            loadingButton.SetActive(true);
            filepath = ModelDownloader.localURL;
<<<<<<< HEAD
            Load.SetActive(false);
=======

>>>>>>> parent of 40de708 (Model from server)
            ImportGLTF();
            result.AddComponent<ObjectSelection>();
            loadingButton.SetActive(false);
            
        }
    }

}
