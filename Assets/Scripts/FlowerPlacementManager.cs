using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FlowerPlacementManager : MonoBehaviour
{
    public GameObject[] flowers;

    public XROrigin XROrigin;

    public ARRaycastManager raycastManager;

    public ARPlaneManager planeManager;

    private List<ARRaycastHit> hits = new();



    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                //Shoot Raycast
                //Place random GameObject (here, flower from flowers)
                //Disable the planes and the plane manager

                bool hasHit = raycastManager.Raycast(Input.mousePosition, hits, TrackableType.PlaneWithinPolygon);

                if (hasHit)
                {
                    GameObject _newFlower = Instantiate(flowers[Random.Range(0, flowers.Length - 1)]);
                    _newFlower.transform.position = hits[0].pose.position;
                }

                foreach (var plane in planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }

                planeManager.enabled = false;
            }

        }
    }
}
