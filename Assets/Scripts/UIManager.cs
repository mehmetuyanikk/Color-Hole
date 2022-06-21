using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] Text _currentLevelText, _nextLevelText, _congratulationsText;
    [SerializeField] Image _progressFillImage;
    [SerializeField] int _sceneOffset;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _progressFillImage.fillAmount = 0f;
        SetLevelProgressText();
    }

    public void UpdateLevelProgress()
    {
        float val = 1f - ((float) Level.Instance._objectsInScene / Level.Instance._totalObjects);
        _progressFillImage.fillAmount = val;
    }

    void SetLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + _sceneOffset;
        _currentLevelText.text = level.ToString();
        _nextLevelText.text = (level + 1).ToString();

        if (level == 3)
        {
            _nextLevelText.text = "X";
        }

        if (level == 4)
        {
            _currentLevelText.text = "X";
            _nextLevelText.text = "X";
        }
    }

    public void ShowLevelCompleted()
    {
        _congratulationsText.text = "Congratulations!";
    }

}
