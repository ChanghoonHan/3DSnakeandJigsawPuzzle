using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour {
    public static StartText S;

    private void Awake()
    {
        S = this;
        this.gameObject.SetActive(true);
    }

    public void SetActiveToFalse()
    {
        this.gameObject.SetActive(false);
    }
}
