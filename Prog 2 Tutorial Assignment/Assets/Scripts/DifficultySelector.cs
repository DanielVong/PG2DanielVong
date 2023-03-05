using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    public DifficultySelectorEnum difficultySelector;
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate{LoadDifficultyScene(difficultySelector);});
    }

    public enum DifficultySelectorEnum
    {
        Easy = 1,
        Normal = 2,
        Hard = 3
    }

    public void LoadDifficultyScene(DifficultySelectorEnum difficulty)
    {
        SceneManager.LoadScene((int)difficulty);
    }
}
