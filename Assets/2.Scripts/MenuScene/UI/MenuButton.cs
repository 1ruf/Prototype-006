using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Animator _defaultAnimator;
    [SerializeField] private Animator _modeAnimator;

    [SerializeField] private GameObject _Blocker;

    private bool _isCool;

    #region DefalutUI
    public void D_PlayBtnClicked()
    {
        if (_isCool) return;

        _defaultAnimator.Play("DefaultAnim_CLOSE");
        StartCoroutine(DelyaAnimPlay(0.5f, _modeAnimator, "ModeUI_OPEN"));

        StartCoroutine(BtnCool(0.5f));
    }

    public void D_SettingBtnClicked()
    {
        if (_isCool) return;

        _defaultAnimator.Play("DefaultAnim_CLOSE");

        StartCoroutine(BtnCool(0.5f));
    }
        
    public void D_ExitBtnClicked()
    {
        if (_isCool) return;
        Application.Quit();
    }
    #endregion

    #region ModeUI
    public void M_Classic()
    {
        if (_isCool) return;

        _Blocker.SetActive(true);
        StartCoroutine(SceneChange(3.5f, "Classic"));

        StartCoroutine(BtnCool(0.5f));
    }

    public void M_Back()
    {
        if (_isCool) return;
        
        _modeAnimator.Play("ModeUI_CLOSE");
        StartCoroutine(DelyaAnimPlay(0.5f, _defaultAnimator, "DefaultAnim_OPEN"));

        StartCoroutine(BtnCool(0.5f));
    }
    #endregion
    private IEnumerator DelyaAnimPlay(float time,Animator animator, string name)
    {
        yield return new WaitForSeconds(time);
        animator.Play(name);
    }

    private IEnumerator SceneChange(float time, string scene)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }

    private IEnumerator BtnCool(float time)
    {
        _isCool = true;
        yield return new WaitForSeconds(time);
        _isCool = false;
    }
}
