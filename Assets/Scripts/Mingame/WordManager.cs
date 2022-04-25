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
    private int maxLetterAmount = 9;

    public void MoveToAnswerArea(LetterTile tile)
    {
        if(answerSlot.Count < maxLetterAmount)
        {
            answerSlot.Add(tile);
            tile.transform.parent = answerArea;
            tile.transform.localPosition = new Vector3(-6f + ((answerSlot.Count - 1f) * 1.5f), 0, 0);
            tile.SetIsInAnswer(true);
        }
        
    }

    public void MovetoLetterArea(LetterTile tile)
    {
        int tileIndex = answerSlot.FindIndex((x) => x.TileId == tile.TileId);
        if(tileIndex != -1)
        {
            answerSlot[tileIndex].transform.parent = letterArea;
            answerSlot[tileIndex].transform.localPosition = answerSlot[tileIndex].GetInitialPositiion();
            answerSlot.RemoveAt(tileIndex);
            tile.SetIsInAnswer(false);
        }
        for(int i = tileIndex; i < answerSlot.Count; i++)
        {
            answerSlot[i].transform.localPosition = new Vector3(answerSlot[i].transform.localPosition.x - 1.5f, answerSlot[i].transform.localPosition.y, answerSlot[i].transform.localPosition.z);
        }
    }
}
