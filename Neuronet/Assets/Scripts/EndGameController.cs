using UnityEngine;

public class EndGameController : MonoBehaviour
{
    private void Awake()
    {
        Observer.EndGameEvent += EndGame;
    }

    private void Update()
    {
        var time = Time.time;
        if (time > 10)
        {
            EndGame(true);
        }
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
}
