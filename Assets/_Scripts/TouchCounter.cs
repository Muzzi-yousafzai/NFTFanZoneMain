using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchCounter : MonoBehaviour
{
    private int check;
    public GameObject AddButton;
    void Update()
    {
        {
            if (Input.GetMouseButton(0))
            {
                if (check != 1)
                {
                    AddButton.SetActive(true);
                    check = 1;
                }
                
            }
        }
    }
    public void delete()
    {
        SceneManager.LoadScene(0);
    }
}