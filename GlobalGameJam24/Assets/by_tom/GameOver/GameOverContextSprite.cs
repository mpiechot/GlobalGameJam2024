using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OutroEventHandler;

public class GameOverContextSprite : MonoBehaviour
{

    [Header("0 = Failure, 1 = Sadness, 2 = Laughter"), SerializeField] private Sprite[] gameOverSprites;

    private Image image;
    private OutroSpriteAnimation outroSpriteAnimation;

    private void Start()
    {
        image = GetComponent<Image>();
        outroSpriteAnimation = GetComponent<OutroSpriteAnimation>();
    }

    public void HandleGameOver(GameOverState gameOverState)
    {
        image.sprite = gameOverSprites[(int)gameOverState];
        outroSpriteAnimation.TriggerPulse();
    }
}
