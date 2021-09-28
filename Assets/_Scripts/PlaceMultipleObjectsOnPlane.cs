using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Events;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceMultipleObjectsOnPlane : MonoBehaviour
    {
        

        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        public GameObject[] prefabs;
        private int NewIndex;
        public UnityEvent onContentPlaced;
        

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject { get; private set; }

        /// <summary>
        /// Invoked whenever an object is placed in on a plane.
        /// </summary>
        public static event Action onPlacedObject;

        ARRaycastManager m_RaycastManager;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }
        public void SelectModel(int index)
        {
      
            spawnedObject.GetComponent<ModelSwitchController>().SelectModel(index);
           
            

        }

        void Update()
        {
            print(NewIndex);
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                    {
                        Pose hitPose = s_Hits[0].pose;

                        spawnedObject = Instantiate(prefabs[NewIndex], hitPose.position, hitPose.rotation);
                        onContentPlaced.Invoke();


                        if (onPlacedObject != null)
                        {
                            onPlacedObject();
                        }
                    }
                }
            }
        }
    }
}