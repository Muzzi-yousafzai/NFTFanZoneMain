using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;
using System;

public class ModelLoader : MonoBehaviour
{
    public string filepath;
    public ModelDownloader ModelDownloader;
    // Start is called before the first frame update

    void Start()
    {
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
    // Single thread


   private void ImportGLTF()
   {
    GameObject result = Importer.LoadFromFile(filepath);
   }

}
