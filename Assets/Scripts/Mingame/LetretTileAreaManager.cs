using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetretTileAreaManager : MonoBehaviour
{
    [SerializeField] private GameObject letterTilePrefab;

    private void Start()
    {
        GenerateTile();
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
                tempTileScript.SetTileId(tileId);
                tileId++;
            }
        }
    }
}
