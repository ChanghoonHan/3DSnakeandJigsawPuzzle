using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCube : MonoBehaviour {
    public static bool StartGame;
    // Use this for initialization

    private void Awake()
    {
        StartGame = false;
    }

    public void OnMouseDown()
    {
        StartGame = true;
        float toVoidPlaceLength;
        Vector3 toVoidPlaceVec;
        Vector3 temp;
        toVoidPlaceVec = BigCube.voidPlace - this.gameObject.transform.localPosition;
        toVoidPlaceLength = toVoidPlaceVec.magnitude;
        if(toVoidPlaceLength == 1)
        {
            temp = this.gameObject.transform.localPosition;
            this.gameObject.transform.localPosition = BigCube.voidPlace;
            BigCube.voidPlace = temp;
        }
    }
}
