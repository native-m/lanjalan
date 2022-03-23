using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    private static PipeManager _instance = null;
    public static PipeManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<PipeManager>();
            }
            return _instance;
        }
    }

    private List<PipeData> pipeDatas = new List<PipeData>()
    {
        new PipeData(new Vector2Int(0, 0), false, false, 0f, 0f),
        new PipeData(new Vector2Int(1, 0), true, false, 90f, 90f),
        new PipeData(new Vector2Int(2, 0), false, true, 90f, 180f),
        new PipeData(new Vector2Int(3, 0), true, true, 180f, 0f),
    };

    [SerializeField] private Grid pipeGrid;
    [SerializeField] private Transform pipeParent;
    [SerializeField] private GameObject pipePrefab;

    private void Start()
    {
        LoadPipeArea();
    }

    private void LoadPipeArea()
    {
        int halfX = 5;
        int halfY = 3;

        foreach(PipeData pipeData in pipeDatas)
        {
            GameObject tempPipeObj = Instantiate(
                pipePrefab,
                pipeGrid.
                CellToWorld(new Vector3Int
                (pipeData.coordinate.x - halfX, pipeData.coordinate.y - halfY, 0)),
                Quaternion.identity,
                pipeParent);
            tempPipeObj.GetComponent<Pipe>().Initialize(
                pipeData.isLShape,
                pipeData.isRotatable,
                pipeData.initRotation,
                pipeData.correctRotation);
        }
    }
}
