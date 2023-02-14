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

    private void Awake()
    {
        defenseValueText.text = "������: " + Data.CharacterDefense.ToString();
        Observer.UIDataUpdate += ChangeDataView;
    }

    private void Update()
    {
        timerText.text = Mathf.Round(Time.time).ToString();
    }

    /// <summary>
    /// ���������� ������ ������� UI.
    /// </summary>
    private void ChangeDataView()
    {
        defenseValueText.text = "������: " + CharacterAttributes.defense.ToString();
        experienceValueText.text = "������: " + CharacterAttributes.experience.ToString();
    }

    private void OnDestroy()
    {
        Observer.UIDataUpdate -= ChangeDataView;
    }
}
