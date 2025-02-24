using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;

    private Animator _animaotr;

    public bool CanActive { get; set; }

    private bool _paused;
    private bool _canRun;

    private void Awake()
    {
        _animaotr = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_paused) Close();
            else Open();
        }
    }

    public void Open()
    {
        if (CheckUI()) return;
        _paused = true;
        _pauseButton.SetActive(false);

        _canRun = false;
        PlayAnimation("PauseUI_OPEN");
    }

    public void Close()
    {
        if (CheckUI()) return;
        _paused = false;
        _pauseButton?.SetActive(true);

        _canRun = false;

        Time.timeScale = 1.0f;
        PlayAnimation("PauseUI_CLOSE");
    }

    public void OpenAnimEnd()
    {
        _canRun = true;

        Time.timeScale = 0f;
    }

    public void CloseAnimEnd()
    {
        _canRun = true;
    }

    private bool CheckUI()
    {
        if (_canRun == false) return false;
        if(CanActive == false) return false;
        return true;
    }

    private void PlayAnimation(string animationName)
    {
        _animaotr.Play(animationName);
    }
}
