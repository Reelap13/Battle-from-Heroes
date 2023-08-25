using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinningPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _text;
    private void Awake()
    {
        Time.timeScale = 1.0f;
        GameController.Instance.Units.onWinningTeam.AddListener(ShowWinningPanel);
    }

    private void ShowWinningPanel(int teamId)
    {
        Time.timeScale = 0;
        _panel.SetActive(true);
        _text.text = $"The {(teamId == 1 ? "right" : "left")} team won the game!!!";
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
