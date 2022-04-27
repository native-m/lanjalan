using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    private static RoadManager _instance = null;
    public static RoadManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<RoadManager>();
            }
            return _instance;
        }
    }

    private List<RoadData> roadDatas = new List<RoadData>()
    {
        new RoadData(new Vector2Int(0, 0), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(1, 0), RoadData.RoadShape.LeftDown, false, 90f, 90f),
        new RoadData(new Vector2Int(2, 0), RoadData.RoadShape.None, true, 90f, 180f),
        new RoadData(new Vector2Int(3, 0), RoadData.RoadShape.LeftDown, true, 180f, 0f),
    };

    [SerializeField] private Grid roadGrid;
    [SerializeField] private Transform roadParent;
    [SerializeField] private GameObject roadPrefab;

    private void Start()
    {
        LoadRoadArea();
    }

    private void LoadRoadArea()
    {
        int halfX = 5;
        int halfY = 3;

        foreach(RoadData roadData in roadDatas)
        {
            GameObject tempPipeObj = Instantiate(
                roadPrefab,
                roadGrid.
                CellToWorld(new Vector3Int
                (roadData.coordinate.x - halfX, roadData.coordinate.y - halfY, 0)),
                Quaternion.identity,
                roadParent);
            tempPipeObj.GetComponent<Road>().Initialize(
                roadData.roadShape,
                roadData.isRotatable,
                roadData.initRotation,
                roadData.correctRotation);
        }
    }
}
