using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetretTileAreaManager : MonoBehaviour
{
    //Temp Database//
    private List<string> answerList = new List<string>
    {
        "BUGISAN",
        "PRAMBANAN",
    };

    [SerializeField] private GameObject letterTilePrefab;

    private List<char> availableTiles = new List<char>();
    private int tileAmount = 21;

    private void Start()
    {
        GenerateLetterList();
        GenerateTile();
    }

    private void GenerateLetterList()
    {
        availableTiles.Clear();
        availableTiles.AddRange(answerList[0]);
        List<char> randomAdditionalChars = GetRandomCharacters(tileAmount - availableTiles.Count);
        availableTiles.AddRange(randomAdditionalChars);
        availableTiles = ShuffleList<char>(availableTiles);
    }

    private void GenerateTile()
    {
        float startX = -6f;
        float startY = 2f;
        int tileId = 0;

        for(float indY = startY; indY >= -2f; indY -= 2f)
        {
            for (float indX = startX; indX <= 6f; indX += 2f)
            {
                GameObject tempTile = Instantiate(letterTilePrefab, transform);
                LetterTile tempTileScript = tempTile.GetComponent<LetterTile>();
                tempTileScript.SetInitialPositiion(new Vector3(indX, indY, 0));
                tempTileScript.SetTile(tileId, availableTiles[tileId]);
                tileId++;
            }
        }
    }

    private List<char> GetRandomCharacters(int charAmount)
    {
        List<char> chars = new List<char>();
        while(--charAmount >= 0)
        {
            char tempChar = (char)('A' + Random.Range(0, 26));
            chars.Add(tempChar);
        }

        return chars;
    }

    private List<T> ShuffleList<T>(List<T> listToShuffle) 
    {
        for(int x = 0; x < listToShuffle.Count; x++)
        {
            T temp = listToShuffle[x];
            int randomIndex = Random.Range(x, listToShuffle.Count);
            listToShuffle[x] = listToShuffle[randomIndex];
            listToShuffle[randomIndex] = temp;
        }

        return listToShuffle;
    }
}
