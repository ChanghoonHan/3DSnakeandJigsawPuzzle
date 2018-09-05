using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour {
    public Slider horizontalSlider;
    public Slider verticalSlider;

    // Use this for initialization
    public void SubmitSliderSetting()
    {
        this.gameObject.transform.localRotation = Quaternion.Euler(verticalSlider.value, horizontalSlider.value, 0);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
