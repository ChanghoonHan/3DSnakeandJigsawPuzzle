using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {
    Vector3 HeadPos;

    private void Awake()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Item-")
        {
            Main.S.DeleteCubeLast();
            Main.S.itemcount--;
            Main.S.score++;
            HighScore.S.BestScoreRecord(Main.S.score);
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "Item")
        {
            Main.S.AddCubeLast(other.gameObject);
            Main.S.itemcount--;
            Main.S.score++;
            HighScore.S.BestScoreRecord(Main.S.score);
        }

        else if (other.transform.tag == "Body" && other.transform.position == this.transform.position)
        {
            Main.S.GameOver();
        }
    }
}
