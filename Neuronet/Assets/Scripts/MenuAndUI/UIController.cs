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
    [SerializeField] private GameObject abilitiesPanel;
    
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button backButton;
    
    [SerializeField] private Button extraDefenseAbilityButton;
    [SerializeField] private Button extraDamageAbilityButton;
    [SerializeField] private Button regenerationAbilityButton;

    private bool isStartingAbilitySelection;

    private void Awake()
    {
        pausePanel.SetActive(false);
        backButton.gameObject.SetActive(false);

        pauseButton.onClick.AddListener(() => OpenPauseMenu());
        backButton.onClick.AddListener(() => ClosePanel());
        menuButton.onClick.AddListener(() => LoadMainMenu());

        extraDefenseAbilityButton.onClick.AddListener(() => ChooseAbility(AbilityType.ExtraDefense));
        extraDamageAbilityButton.onClick.AddListener(() => ChooseAbility(AbilityType.ExtraDamage));
        regenerationAbilityButton.onClick.AddListener(() => ChooseAbility(AbilityType.Regeneration));

        Observer.UIDataUpdateEvent += ChangeDataView;
        Observer.AbilitySelectionEvent += OpenAbilitiesPanel;

        defenseValueText.text = "������: " + Data.CharacterDefense.ToString();
    }

    private void Start()
    {
        if (isStartingAbilitySelection == false)
        {
            OpenAbilitiesPanel();
            isStartingAbilitySelection = true;
        }
    }

    private void FixedUpdate()
    {
        timerText.text = Mathf.Round(CurrentGameSessionTime.time).ToString();
    }

    private void OnDestroy()
    {
        Observer.UIDataUpdateEvent -= ChangeDataView;
        Observer.AbilitySelectionEvent -= OpenAbilitiesPanel;
    }

    /// <summary>
    /// ���������� ������ ������� UI.
    /// </summary>
    private void ChangeDataView()
    {
        defenseValueText.text = "������: " + CharacterCurrentAttributes.defense.ToString();
        experienceValueText.text = "����: " + CharacterCurrentAttributes.experience.ToString();
    }

    /// <summary>
    /// ������ ���� �� �����, ��������� ���� �����.
    /// </summary>
    private void OpenPauseMenu()
    {
        backButton.gameObject.SetActive(true);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// ������ ���� �� �����, ��������� ���� ������ ������������.
    /// </summary>
    private void OpenAbilitiesPanel()
    {
        backButton.gameObject.SetActive(true);
        abilitiesPanel.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// ������� ���� � �����, ��������� �������� ������.
    /// </summary>
    private void ClosePanel()
    {
        backButton.gameObject.SetActive(false);
        pausePanel.SetActive(false);
        abilitiesPanel.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// ������� �����������.
    /// </summary>
    private void ChooseAbility(AbilityType type)
    {
        Observer.AbilitiyApplyEvent.Invoke(type);

        switch (type)
        {
            case AbilityType.ExtraDefense:
                extraDefenseAbilityButton.onClick.RemoveAllListeners();
                extraDefenseAbilityButton.GetComponentInChildren<Text>().text = "������������";
                break;

            case AbilityType.ExtraDamage:
                extraDamageAbilityButton.onClick.RemoveAllListeners();
                extraDamageAbilityButton.GetComponentInChildren<Text>().text = "������������";
                break;

            case AbilityType.Regeneration:
                
                break;

            
        }
    }

    /// <summary>
    /// �������� ����� �������� ���� ����.
    /// </summary>
    private void LoadMainMenu()
    {
        new ChangeScene().LoadScene((int)Scenes.MainMenu);
    }
    
}
