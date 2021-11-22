using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchCounter : MonoBehaviour
{
    public GameObject AddButton;
    void Update()
    {
        {
            if (Input.GetMouseButton(0))
            {
                AddButton.SetActive(true);  
            }
        }
    }
    public void delete()
    {
        SceneManager.LoadScene(0);
    }
}