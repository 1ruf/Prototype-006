using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Animator _defaultAnimator;
    [SerializeField] private Animator _modeAnimator;

    [SerializeField] private GameObject _Blocker;

    #region DefalutUI
    public void D_PlayBtnClicked()
    {
        _defaultAnimator.Play("DefaultAnim_CLOSE");
        StartCoroutine(DelyaAnimPlay(0.5f, _modeAnimator, "ModeUI_OPEN"));
    }

    public void D_SettingBtnClicked()
    {
        _defaultAnimator.Play("DefaultAnim_CLOSE");
    }
        
    public void D_ExitBtnClicked()
    {
        Application.Quit();
    }
    #endregion

    #region ModeUI
    public void M_Classic()
    {
        _Blocker.SetActive(true);
        StartCoroutine(SceneChange(3.5f, "Classic"));
    }

    public void M_Back()
    {
        _modeAnimator.Play("ModeUI_CLOSE");
        StartCoroutine(DelyaAnimPlay(0.5f, _defaultAnimator, "DefaultAnim_OPEN"));
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
}
