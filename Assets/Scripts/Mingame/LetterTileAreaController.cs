using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTileAreaController : MonoBehaviour
{
    [SerializeField] private GameObject letterTilePrefab;

    private List<char> availableChars = new List<char>();
    private List<GameObject> tileObjects = new List<GameObject>();
    private int tileAmount = 21;

    public void InitiateTiles(string answer)
    {
        ClearTilesAndCharas();
        GenerateLetterList(answer);
        GenerateTile();
    }
    public void ClearTilesAndCharas()
    {
        foreach(GameObject tileObject in tileObjects)
        {
            Destroy(tileObject);
        }

        availableChars.Clear();
        tileObjects.Clear();
    }

    private void GenerateLetterList(string answer)
    {
        availableChars.AddRange(answer);
        List<char> randomAdditionalChars = GetRandomCharacters(tileAmount - availableChars.Count);
        availableChars.AddRange(randomAdditionalChars);
        availableChars = ShuffleList<char>(availableChars);
    }

    private void GenerateTile()
    {
        float startX = -4.5f;
        float startY = 1.5f;
        int tileId = 0;

        for(float indY = startY; indY >= -1.5f; indY -= 1.5f)
        {
            for (float indX = startX; indX <= 4.5f; indX += 1.5f)
            {
                GameObject tempTile = Instantiate(letterTilePrefab, transform);
                tileObjects.Add(tempTile);
                LetterTile tempTileScript = tempTile.GetComponent<LetterTile>();
                tempTileScript.SetInitialPositiion(new Vector3(indX, indY, 0));
                tempTileScript.SetTile(tileId, availableChars[tileId]);
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
