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
        Observer.AbilitiesEvent += OpenAbilitiesPanel;

        defenseValueText.text = "Защита: " + Data.CharacterDefense.ToString();
    }

    private void FixedUpdate()
    {
        timerText.text = Mathf.Round(CurrentGameSessionTime.time).ToString();
    }

    private void OnDestroy()
    {
        Observer.UIDataUpdateEvent -= ChangeDataView;
        Observer.AbilitiesEvent -= OpenAbilitiesPanel;
    }

    /// <summary>
    /// Обновление текста панелей UI.
    /// </summary>
    private void ChangeDataView()
    {
        defenseValueText.text = "Защита: " + CharacterAttributes.defense.ToString();
        experienceValueText.text = "Опыт: " + CharacterAttributes.experience.ToString();
    }

    /// <summary>
    /// Ставит игру на паузу, открывает меню паузы.
    /// </summary>
    private void OpenPauseMenu()
    {
        backButton.gameObject.SetActive(true);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Ставит игру на паузу, открывает меню выбора способностей.
    /// </summary>
    private void OpenAbilitiesPanel()
    {
        backButton.gameObject.SetActive(true);
        abilitiesPanel.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Снимает игру с паузы, закрывает открытые панели.
    /// </summary>
    private void ClosePanel()
    {
        backButton.gameObject.SetActive(false);
        pausePanel.SetActive(false);
        abilitiesPanel.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Выбрать способность.
    /// </summary>
    private void ChooseAbility(AbilityType type)
    {

    }

    /// <summary>
    /// Загрузка сцены главного меню игры.
    /// </summary>
    private void LoadMainMenu()
    {
        new ChangeScene().LoadScene((int)Scenes.MainMenu);
    }
    
}
