using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class LaserScript : MonoBehaviour
{
    [Header("Settings")]
    public LayerMask layerMask;
    public float defaultLength = 50;
    public int numReflections = 2;

    private LineRenderer _lineRenderer;
    private Camera _myCam; 
    private RaycastHit hit;

    private Ray ray;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // NormalLaser();
        ReflectLaser();
    }

    void ReflectLaser()
    {
        //ray starts from shooting point and points forward
        ray = new Ray(transform.position, transform.forward);

        //when we hit something increase the number of position.linerenderer
        _lineRenderer.positionCount = 1;
        _lineRenderer.SetPosition(0, transform.position);

        float remainLength = defaultLength;

        for (int i = 0; i < numReflections; i++)
        {
            //Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainLength, layerMask))
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount -1, hit.point);

                remainLength -=Vector3.Distance(ray.origin, hit.point);

                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
            }
            else
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount -1, ray.origin + (ray.direction * remainLength));
            }
        }
    }

    void NormalLaser()
    {
        _lineRenderer.SetPosition(0, transform.position);

        //Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, defaultLength, layerMask))
        {
            _lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            _lineRenderer.SetPosition(1, transform.position + (transform.forward * defaultLength));
        }
    }
}
