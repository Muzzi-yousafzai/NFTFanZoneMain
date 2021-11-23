using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ModelDownloader : MonoBehaviour
{
    private string serverURL = "https://xlmoose.com/nft/poodlTest/PoodlFinalWithAccessories.glb";
    public string localURL;
    public GameObject Downloadbutton;
  
    public Text loadingProgress;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        localURL = string.Format("{0}/{1}.glb", Application.persistentDataPath, "Poodle"); ;
        print(localURL);
    }
    private void Update()
    {
        
       
    }

    public void Download()
    {
        if (File.Exists(localURL))
        {
            Debug.Log("File Already Downloaded!");

            Downloadbutton.SetActive(false);

        }
        else
        {
            
            StartCoroutine(DownloadVideo());
            Downloadbutton.SetActive(false);
        }
        
    }

    IEnumerator DownloadVideo()
    {
            UnityWebRequest www = UnityWebRequest.Get(serverURL);
            StartCoroutine(WaitForResponse(www));
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                File.WriteAllBytes(localURL, www.downloadHandler.data);
                
            }
    }

    IEnumerator WaitForResponse(UnityWebRequest request)
    {
        while (!request.isDone)
        {
            loadingProgress.text = "" + (request.downloadProgress*100).ToString("F0")+ "%";
            print(loadingProgress);
            yield return null;
        }
    }
}
