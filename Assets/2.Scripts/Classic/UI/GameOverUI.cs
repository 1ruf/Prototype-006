using Script.UIs;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private EventChannelSO uiEvent;

    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI resultTmp;

    public void OnReturnPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void Awake()
    {
        uiEvent.AddListener<GameOverEvent>(HandleGameover);
    }
    private void OnDestroy()
    {
        uiEvent.RemoveListener<GameOverEvent>(HandleGameover);
    }

    private void HandleGameover(GameOverEvent evt)
    {
        animator.gameObject.SetActive(true);
        resultTmp.text = evt.Result ? "WIN" : "LOSE";
        animator.Play("Gameover");
    }
}
