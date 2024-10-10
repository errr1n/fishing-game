using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingBar : MonoBehaviour
{

    [SerializeField]
    private Slider fishingBar; 

    // private float currSpeed = 0;
    // private float targetSpeed = 0;
    // private float needleSpeed = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        fishingBar.value = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
