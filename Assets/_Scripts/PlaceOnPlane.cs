using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using Siccity.GLTFUtility;
namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefabs;
        public UnityEvent onContentPlaced;
        public GameObject[] Prefabs;
        public Text debugLog;
        bool canAugment=false;
        public Animator animator;
        private int NewIndex;
        private int placedPrefabCount;
        private int maxPrefabSpwanCount = 20;
        public GameObject TakeImageButton;
        public GameObject Featheredplane;
        public GameObject EnableTrackingButton;
        public GameObject DisableTrackingButton;
        public ModelLoader ModelLoader;


        public ARPlaneManager m_ARPlaneManager;
        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        //   public GameObject placedPrefab
        // {
        // get { return m_PlacedPrefab; }
        //   set { m_PlacedPrefab = value; }
        //  }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        /// 
        public void EnableTracking()
        {
            foreach (var plane in m_ARPlaneManager.trackables)
                plane.gameObject.SetActive(true);
            EnableTrackingButton.SetActive(false);
            DisableTrackingButton.SetActive(true);
        }
        public void DisbleTracking()
        {
            foreach (var plane in m_ARPlaneManager.trackables)
                plane.gameObject.SetActive(false);
            DisableTrackingButton.SetActive(false);
            EnableTrackingButton.SetActive(true);
            
        }

        public GameObject spawnedObject { get; private set; }

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
            m_ARPlaneManager = GetComponent<ARPlaneManager>();
        }

        public void SelectModel(int index)
        {
            NewIndex = index;
            ModelLoader.LoadModel();
            Prefabs[NewIndex] = ModelLoader.result;
            debugLog.text = "Tap to place new Model!";
            animator.SetTrigger("Down");
            Invoke(nameof(TurnAugmentation), 1.0f);
            TakeImageButton.SetActive(false);
        }
        void TurnAugmentation()
        {
            canAugment = true;

        }
        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
    #if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;
                touchPosition = new Vector2(mousePosition.x, mousePosition.y);
                return true;
            }
    #else
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }
    #endif

            touchPosition = default;
            return false;
        }

        void Update()
        {
            if (!TryGetTouchPosition(out Vector2 touchPosition))
                return;

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hitPose = s_Hits[0].pose;
                
                if(canAugment)
                {
                    Instantiate(Prefabs[NewIndex], hitPose.position, hitPose.rotation);
                    onContentPlaced.Invoke();
                    Handheld.Vibrate();
                    canAugment = false;
                    debugLog.text = "Select Model!";
                    TakeImageButton.SetActive(true);
                    //placedPrefabCount++;
                    //  gameObject.GetComponent<ARPlaneManager>().enabled = false;
                   
                }
               
                
                //else
                //{
                //    spawnedObject.transform.position = hitPose.position;
                //}
            }
        }

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}