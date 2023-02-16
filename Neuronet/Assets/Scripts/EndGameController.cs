using UnityEngine;

public class EndGameController : MonoBehaviour
{
    private void Start()
    {
        //задать обнуление атрибутов
        
        Observer.EndGameEvent += EndGame;
        CurrentGameSessionTime.time = 0;
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
    /// ќкончание игровой сессии. isGameWin в значении true соответствует победе.
    /// </summary>
    private void EndGame(bool isGameWin)
    {
        GameSessionResult.IsGameWin = isGameWin;
        new ChangeScene().LoadScene((int)Scenes.ResultGameMenu);
    }

    /// <summary>
    /// “аймер игровой сессии. ѕри достижении заданного времени присуждаетс€ победа.
    /// </summary>
    private void WinTimer()
    {
        CurrentGameSessionTime.time += Time.deltaTime;

        if (CurrentGameSessionTime.time > Data.GameSessionMaxTime)
            EndGame(true);
    }
}
