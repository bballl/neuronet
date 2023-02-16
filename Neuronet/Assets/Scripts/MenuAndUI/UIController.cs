using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text defenseValueText;
    [SerializeField] private Text experienceValueText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text infoText;

    [SerializeField] private GameObject pausePanel;
    
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button menuButton;

    private void Awake()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(() => OpenPauseMenu());
        backButton.onClick.AddListener(() => ClosePauseMenu());
        menuButton.onClick.AddListener(() => LoadMainMenu());

        defenseValueText.text = "������: " + Data.CharacterDefense.ToString();
        Observer.UIDataUpdateEvent += ChangeDataView;
    }

    private void FixedUpdate()
    {
        timerText.text = Mathf.Round(CurrentGameSessionTime.time).ToString();
    }

    /// <summary>
    /// ���������� ������ ������� UI.
    /// </summary>
    private void ChangeDataView()
    {
        defenseValueText.text = "������: " + CharacterAttributes.defense.ToString();
        experienceValueText.text = "����: " + CharacterAttributes.experience.ToString();
    }

    /// <summary>
    /// ������ ���� �� �����, ��������� ���� �����.
    /// </summary>
    private void OpenPauseMenu()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// ������� ���� � �����, ��������� ���� �����.
    /// </summary>
    private void ClosePauseMenu()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// �������� ����� �������� ���� ����.
    /// </summary>
    private void LoadMainMenu()
    {
        new ChangeScene().LoadScene((int)Scenes.MainMenu);
    }
    
    private void OnDestroy()
    {
        Observer.UIDataUpdateEvent -= ChangeDataView;
    }
}
