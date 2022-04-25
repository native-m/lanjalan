using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class LetterTile : MonoBehaviour
{
    private int tileId;
    public int TileId { get { return tileId; } }
    private bool isInAnswer;
    private Vector3 initialPosition = Vector3.zero;

    [SerializeField] private Sprite[] letterSprites;
    private SpriteRenderer spriteRenderer;

    private char tileLetter;
    public char TileLetter { get { return tileLetter; } }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        isInAnswer = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!isInAnswer)
            {
                WordManager.Instance.MoveToAnswerArea(this);
            }
            else
            {
                WordManager.Instance.MovetoLetterArea(this);
            }
        }
    }

    private void UpdateLetterSprite()
    {
        Regex regAlphabet = new Regex(@"^[a-zA-z]*$");
        if(!regAlphabet.IsMatch(tileLetter.ToString()))
        {
            return;
        }
        int spriteIndex = char.ToUpper(tileLetter) - 65;
        spriteRenderer.sprite = letterSprites[spriteIndex];
    }

    public void SetInitialPositiion(Vector3 initPos)
    {
        initialPosition = initPos;
        transform.localPosition = initialPosition;
    }

    public Vector3 GetInitialPositiion()
    {
        return initialPosition;
    }

    public void SetTile(int id, char letter)
    {
        tileId = id;
        tileLetter = letter;
        UpdateLetterSprite();
    }

    public void SetIsInAnswer(bool value)
    {
        isInAnswer = value;
    }
}
