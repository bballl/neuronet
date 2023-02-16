using UnityEngine;

public class GameStateController : MonoBehaviour
{
    private void Start()
    {
        CharacterAttributes.SetDefaultAttributesValues();
        Observer.EndGameEvent += EndGame;
    }

    private void FixedUpdate()
    {
        WinTimer();
    }

    private void OnDestroy()
    {
        Observer.EndGameEvent -= EndGame;
    }
    
    /// <summary>
    /// Окончание игровой сессии. isGameWin в значении true соответствует победе.
    /// </summary>
    private void EndGame(bool isGameWin)
    {
        GameSessionResult.IsGameWin = isGameWin;
        new ChangeScene().LoadScene((int)Scenes.ResultGameMenu);
    }

    /// <summary>
    /// Таймер игровой сессии. При достижении заданного времени присуждается победа.
    /// </summary>
    private void WinTimer()
    {
        CurrentGameSessionTime.time -= Time.deltaTime;

        if (CharacterAttributes.isQuickFind)
            CurrentGameSessionTime.time -= Data.QuickFindValue;

        if (CurrentGameSessionTime.time <= 0)
            EndGame(true);
    }
}
