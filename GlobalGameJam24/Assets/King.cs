using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class King : MonoBehaviour
{
    // idea: neutral image could change to smiling image after a certain score threshold
    // idea: then the smiling reaction could be a laughing reaction

    public int reactionInSeconds = 1;

    public Sprite kingNeutral;
    public Sprite kingSmiling;
    public Sprite kingSad;

    public TextMeshProUGUI amusementScoreUI;

    private int amusementScore = 0;

    // change points
    public void AddPoints(int points)
    {
        amusementScore += points;
        ChangeSprite(kingSmiling);
        UpdatePointsUI();
    }

    public void SubtractPoints(int points)
    {
        amusementScore -= points;
        ChangeSprite(kingSad);
        UpdatePointsUI();
    }

    private void UpdatePointsUI()
    {
        amusementScoreUI.text = amusementScore.ToString();
    }

    // change sprite
    private void ChangeSprite(Sprite changeSprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        Sprite originalSprite = spriteRenderer.sprite;
        Sprite newSprite = changeSprite;
        spriteRenderer.sprite = newSprite;

        StartCoroutine(WaitAndChangeSpriteBack(originalSprite));
    }

    private IEnumerator WaitAndChangeSpriteBack(Sprite originalSprite)
    {
        yield return new WaitForSeconds(reactionInSeconds);

        GetComponent<SpriteRenderer>().sprite = originalSprite;
    }
}
