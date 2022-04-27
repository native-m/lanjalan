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

    // 7x6 (0-6 and 0-5), start from bottom left
    private List<RoadData> roadDatas = new List<RoadData>()
    {
        new RoadData(new Vector2Int(0, 0), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(1, 0), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(2, 0), RoadData.RoadShape.LeftDown, false, 90f, 90f),
        new RoadData(new Vector2Int(3, 0), RoadData.RoadShape.Horizontal, false, 0f, 0f),
        new RoadData(new Vector2Int(4, 0), RoadData.RoadShape.LeftDown, false, 180f, 180f),
        new RoadData(new Vector2Int(5, 0), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(6, 0), RoadData.RoadShape.None, false, 0f, 0f),

        new RoadData(new Vector2Int(0, 1), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(1, 1), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(2, 1), RoadData.RoadShape.Horizontal, true, 0f, 90f),
        new RoadData(new Vector2Int(3, 1), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(4, 1), RoadData.RoadShape.Horizontal, false, 90f, 90f),
        new RoadData(new Vector2Int(5, 1), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(6, 1), RoadData.RoadShape.LeftDown, false, 90f, 90f),

        new RoadData(new Vector2Int(0, 2), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(1, 2), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(2, 2), RoadData.RoadShape.Horizontal, false, 90f, 90f),
        new RoadData(new Vector2Int(3, 2), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(4, 2), RoadData.RoadShape.LeftDown, false, 0f, 0f),
        new RoadData(new Vector2Int(5, 2), RoadData.RoadShape.LeftDown, true, 270f, 180f),
        new RoadData(new Vector2Int(6, 2), RoadData.RoadShape.Horizontal, true, 0f, 90f),

        new RoadData(new Vector2Int(0, 3), RoadData.RoadShape.Horizontal, false, 0f, 0f),
        new RoadData(new Vector2Int(1, 3), RoadData.RoadShape.LeftDown, true, 0f, 180f),
        new RoadData(new Vector2Int(2, 3), RoadData.RoadShape.LeftDown, false, 0f, 0f),
        new RoadData(new Vector2Int(3, 3), RoadData.RoadShape.LeftDown, false, 180f, 180f),
        new RoadData(new Vector2Int(4, 3), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(5, 3), RoadData.RoadShape.Horizontal, false, 90f, 90f),
        new RoadData(new Vector2Int(6, 3), RoadData.RoadShape.Horizontal, false, 90f, 90f),

        new RoadData(new Vector2Int(0, 4), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(1, 4), RoadData.RoadShape.Horizontal, false, 90f, 90f),
        new RoadData(new Vector2Int(2, 4), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(3, 4), RoadData.RoadShape.Horizontal, false, 90f, 90f),
        new RoadData(new Vector2Int(4, 4), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(5, 4), RoadData.RoadShape.Horizontal, true, 0f, 90f),
        new RoadData(new Vector2Int(6, 4), RoadData.RoadShape.Horizontal, false, 90f, 90f),

        new RoadData(new Vector2Int(0, 5), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(1, 5), RoadData.RoadShape.LeftDown, false, 0f, 0f),
        new RoadData(new Vector2Int(2, 5), RoadData.RoadShape.Horizontal, false, 0f, 0f),
        new RoadData(new Vector2Int(3, 5), RoadData.RoadShape.LeftDown, true, 0f, 270f),
        new RoadData(new Vector2Int(4, 5), RoadData.RoadShape.None, false, 0f, 0f),
        new RoadData(new Vector2Int(5, 5), RoadData.RoadShape.LeftDown, false, 0f, 0f),
        new RoadData(new Vector2Int(6, 5), RoadData.RoadShape.LeftDown, false, 270f, 270f),
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
