using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigCube : MonoBehaviour {
    public GameObject[] cubePrefabs;
    public static GameObject[] cube = new GameObject[26];
    public static Vector3[] cubePos = new Vector3[27];
    public static Vector3 voidPlace;
    List<int> CubePosIndexTable = new List<int>();

    public Slider horizontalSlider;
    public Slider verticalSlider;

    //Invoked when a submit button is clicked.
    public void SubmitSliderSetting()
    {
        this.gameObject.transform.localRotation = 
            Quaternion.Euler(verticalSlider.value, horizontalSlider.value, 0) ;
    }

    void Awake()
    {
        cubePos[0] = new Vector3(-1f, 1f, 1f);
        cubePos[1] = new Vector3(0f, 1f, 1f);
        cubePos[2] = new Vector3(1f, 1f, 1f);
        cubePos[3] = new Vector3(-1f, 1f, 0f);
        cubePos[4] = new Vector3(0f, 1f, 0f);
        cubePos[5] = new Vector3(1f, 1f, 0f);
        cubePos[6] = new Vector3(-1f, 1f, -1f);
        cubePos[7] = new Vector3(0f, 1f, -1f);
        cubePos[8] = new Vector3(1f, 1f, -1f);

        cubePos[9] = new Vector3(-1f, 0f, 1f);
        cubePos[10] = new Vector3(0f, 0f, 1f);
        cubePos[11] = new Vector3(1f, 0f, 1f);
        cubePos[12] = new Vector3(-1f, 0f, 0f);
        cubePos[13] = new Vector3(0f, 0f, 0f);
        cubePos[14] = new Vector3(1f, 0f, 0f);
        cubePos[15] = new Vector3(-1f, 0f, -1f);
        cubePos[16] = new Vector3(0f, 0f, -1f);
        cubePos[17] = new Vector3(1f, 0f, -1f);

        cubePos[18] = new Vector3(-1f, -1f, 1f);
        cubePos[19] = new Vector3(0f, -1f, 1f);
        cubePos[20] = new Vector3(1f, -1f, 1f);
        cubePos[21] = new Vector3(-1f, -1f, 0f);
        cubePos[22] = new Vector3(0f, -1f, 0f);
        cubePos[23] = new Vector3(1f, -1f, 0f);
        cubePos[24] = new Vector3(-1f, -1f, -1f);
        cubePos[25] = new Vector3(0f, -1f, -1f);
        cubePos[26] = new Vector3(1f, -1f, -1f);

        CubeSet();
        for (int i = 0; i < 1000; i++)
        {
            cubeMix();
        }
        //for (int i = 0; i < 100; i++)
        //{
        //    cubeMixTest();
        //}
    }

    void CubeSet()
    { 
        for (int i = 0; i < 26; i++)
        {
            cube[i] = Instantiate(cubePrefabs[i]);
            cube[i].transform.parent = this.gameObject.transform;
            cube[i].transform.localPosition = cubePos[i];
            cube[i].transform.localScale = new Vector3(30f, 30f, 30f);
        }

        voidPlace = cubePos[26];
    }

    void cubeMix()
    {
        List<GameObject> nearCube = new List<GameObject>();
        int nearCubeCount = 0;
        float voidPlaceTCubeLength;
        Vector3 voidPlaceToCubeVec;
        Vector3 temp = voidPlace;
        int selectCubeNum = 0;

        for (int i = 0; i < 26; i++)
        {
            voidPlaceToCubeVec = BigCube.voidPlace - cube[i].gameObject.transform.localPosition;
            voidPlaceTCubeLength = voidPlaceToCubeVec.magnitude;
            if(voidPlaceTCubeLength == 1)
            {
                nearCube.Add(cube[i].gameObject);
                nearCubeCount++;
            }
        }
        selectCubeNum = Random.Range(0, nearCubeCount);
        temp = nearCube[selectCubeNum].transform.localPosition;
        nearCube[selectCubeNum].transform.localPosition = voidPlace;
        voidPlace = temp;
    }

    void cubeMixTest()
    {
        List<GameObject> nearCube = new List<GameObject>();
        int nearCubeCount = 0;
        float voidPlaceTCubeLength;
        Vector3 voidPlaceToCubeVec;
        Vector3 temp = voidPlace;
        int selectCubeNum = 0;

        for (int i = 18; i < 26; i++)
        {
            voidPlaceToCubeVec = BigCube.voidPlace - cube[i].gameObject.transform.localPosition;
            voidPlaceTCubeLength = voidPlaceToCubeVec.magnitude;
            if (voidPlaceTCubeLength == 1)
            {
                nearCube.Add(cube[i].gameObject);
                nearCubeCount++;
            }
        }
        selectCubeNum = Random.Range(0, nearCubeCount);
        temp = nearCube[selectCubeNum].transform.localPosition;
        nearCube[selectCubeNum].transform.localPosition = voidPlace;
        voidPlace = temp;
    }

    public static bool isGameClear()
    {
        bool Clear = false;
        for (int i = 0; i < 26; i++)
        {
            if (cubePos[i] == cube[i].transform.localPosition)
            {
                Clear = true;
            }
            else
            {
                Clear = false;
                return Clear;
            }
        }

        return Clear;
    }

}
