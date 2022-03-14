using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    private static WordManager _instance = null;
    public static WordManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<WordManager>();
            }
            return _instance;
        }
    }

    [SerializeField] private Transform answerArea;
    [SerializeField] private Transform letterArea;

    private List<LetterTile> answerSlot = new List<LetterTile>();
    private int maxLetterAmount = 7;

    public void MoveToAnswerArea(LetterTile tile)
    {
        if(answerSlot.Count < maxLetterAmount)
        {
            answerSlot.Add(tile);
        }
        /*tile.transform.localPosition = Vector3.zero;*/
        tile.transform.parent = answerArea;
        tile.transform.localPosition = new Vector3(-6f + ((answerSlot.Count - 1) * 2), 0, 0);
    }

    public void MovetoLetterArea(LetterTile tile)
    {
        int tileIndex = answerSlot.FindIndex((x) => x.GetTileId() == tile.GetTileId());
        if(tileIndex != -1)
        {
            answerSlot[tileIndex].transform.parent = letterArea;
            answerSlot[tileIndex].transform.localPosition = answerSlot[tileIndex].GetInitialPositiion();
            answerSlot.RemoveAt(tileIndex);
        }
        for(int i = tileIndex; i < answerSlot.Count; i++)
        {
            answerSlot[i].transform.localPosition = new Vector3(answerSlot[i].transform.position.x - 2f, answerSlot[i].transform.position.y, answerSlot[i].transform.position.z);
        }
    }
}
