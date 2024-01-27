using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class King : MonoBehaviour
{
    [Tooltip("how long is the king's reaction to an acitivity shown?")]
    public int reactionDuration = 1;
    [Tooltip("how much time passes without activity before the king gets bored?")]
    public int reactionBoredomTime = 5;
    [Tooltip("how happy is the king before his face changes permanently?")]
    public int reactionBaseChangeThreshold = 10;

    public int minusPointsForBoredom = 1;

    public Sprite kingNeutral;
    public Sprite kingSmiling;
    public Sprite kingLaughing;
    public Sprite kingSad;

    private Sprite kingBase;
    private Sprite kingHappier;
    private Sprite kingSadder;

    public TextMeshProUGUI amusementScoreUI;

    private int amusementScore = 0;

    private float lastActivityTime;

    private void Start()
    {
        lastActivityTime = Time.time;
        StartCoroutine(CheckInactivity());

        kingBase = kingNeutral;
        kingHappier = kingSmiling;
        kingSadder = kingSad;
    }

    // change points
    public void AddPoints(int points)
    {
        lastActivityTime = Time.time;

        amusementScore += points;
        ChangeSpriteTemplate();
        ChangeSprite(kingHappier);
        UpdatePointsUI();
    }

    public void SubtractPoints(int points)
    {
        lastActivityTime = Time.time;

        amusementScore -= points;
        ChangeSpriteTemplate();
        ChangeSprite(kingSadder);
        UpdatePointsUI();
    }

    private void UpdatePointsUI()
    {
        amusementScoreUI.text = amusementScore.ToString();
    }

    // change sprite
    private void ChangeSpriteTemplate()
    {
        if (amusementScore > reactionBaseChangeThreshold)
        {
            kingBase = kingSmiling;
            kingHappier = kingLaughing;
            kingSadder = kingNeutral;
        }
        else
        {
            kingBase = kingNeutral;
            kingHappier = kingSmiling;
            kingSadder = kingSad;
        }
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = kingBase;
    }

    private void ChangeSprite(Sprite changeSprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = changeSprite;

        StartCoroutine(WaitAndChangeSpriteBack());
    }

    private IEnumerator WaitAndChangeSpriteBack()
    {
        yield return new WaitForSeconds(reactionDuration);

        GetComponent<SpriteRenderer>().sprite = kingBase;
    }

    // boredom
    IEnumerator CheckInactivity()
    {
        while (true)
        {
            if (Time.time - lastActivityTime > reactionBoredomTime)
            {
                SubtractPoints(minusPointsForBoredom);
            }
            yield return null;
        }
    }
}