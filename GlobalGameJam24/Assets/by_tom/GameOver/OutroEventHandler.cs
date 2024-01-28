using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutroEventHandler : MonoBehaviour
{

    [SerializeField] private GameOverContextSprite[] gameOverContextSprites;
    [SerializeField] private OutroAudioHandler outroAudioHandler;
    [SerializeField] private OutroFader outroFader;

    [SerializeField] private Button[] _buttons;

    private Coroutine gameOverRoutine;

    public enum GameOverState
    {
        Failure,
        Sadness,
        Laughter
    }

    public void HandleGameOver(GameOverState gameOverState)
    {
        GameContext.Instance.Jester.gameObject.SetActive(false);
        if (gameOverRoutine != null)
            StopCoroutine(gameOverRoutine);
        gameOverRoutine = StartCoroutine(Suspense(gameOverState));
    }

    public void TestHandleGameOver(int gameOverState)
    {
        HandleGameOver((GameOverState)gameOverState);
    }

    private void ExecuteGameOverEvent(GameOverState gameOverState)
    {
        foreach (var sprite in gameOverContextSprites)
        {
            sprite.HandleGameOver(gameOverState);
        }

        foreach (Button b in _buttons)
        {
            b.gameObject.SetActive(true);
        }

        outroAudioHandler.TriggerGameOverAudio(gameOverState);
    }

    private IEnumerator Suspense(GameOverState gameOverState)
    {
        GameContext.Instance.AudioPlayer.StopBGMusic();
        GameContext.Instance.AudioPlayer.RequestSFX(SFXType.DrumSet1);
        yield return outroFader.PerformOutroFade();
        yield return new WaitForSecondsRealtime(1);
        ExecuteGameOverEvent(gameOverState);
        yield return outroFader.UndoOutroFade();
    }

}
