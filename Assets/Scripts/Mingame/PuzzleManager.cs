using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private PuzzlePiece[] puzzlePieces;

    private int score = 0;

    private void Start() 
    {
        puzzlePieces = FindObjectsOfType<PuzzlePiece>();    
    }

    public void AddScore()
    {
        score +=1;
        print(score);
    }

    public void ResetGame()
    {
        foreach(PuzzlePiece puzzlePiece in puzzlePieces)
        {
            puzzlePiece.ResetPosition();
        }
        score = 0;
    }
}
