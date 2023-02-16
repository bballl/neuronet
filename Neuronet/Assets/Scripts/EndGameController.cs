using UnityEngine;

public class EndGameController : MonoBehaviour
{
    private void Start()
    {
        //������ ��������� ���������
        
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
    /// ��������� ������� ������. isGameWin � �������� true ������������� ������.
    /// </summary>
    private void EndGame(bool isGameWin)
    {
        GameSessionResult.IsGameWin = isGameWin;
        new ChangeScene().LoadScene((int)Scenes.ResultGameMenu);
    }

    /// <summary>
    /// ������ ������� ������. ��� ���������� ��������� ������� ������������ ������.
    /// </summary>
    private void WinTimer()
    {
        CurrentGameSessionTime.time += Time.deltaTime;

        if (CurrentGameSessionTime.time > Data.GameSessionMaxTime)
            EndGame(true);
    }
}
