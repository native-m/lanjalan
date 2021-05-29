using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private List<PuzzlePiece> puzzlePieces = new List<PuzzlePiece>();

    private int score = 0;

    public void AddPiece(PuzzlePiece puzzlePiece)
    {
        puzzlePieces.Add(puzzlePiece);
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
