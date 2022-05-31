using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCameraManager : MonoBehaviour
{
    public GameObject[] cameraList;
    private Dictionary<string, GameObject> cameraDict =
        new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var cam in cameraList)
        {
            if (cam != null)
            {
                cameraDict.Add(cam.name, cam);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCamera(string cameraName)
    {
        if (cameraDict.ContainsKey(cameraName))
        {
            cameraDict[cameraName].SetActive(true); 
        }
    }
}
