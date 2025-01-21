using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager_Cla : MonoBehaviour
{
    public static ButtonManager_Cla Instance;

    [SerializeField] private ClasicSystem _system;
    [SerializeField] private GameObject _btnA;
    [SerializeField] private GameObject _btnB;
    [SerializeField] private GameObject _btnC;

    [SerializeField] private TextMeshProUGUI _btnTxt_A_1;

    public ButtonMode_A CurrentA;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void SetBtn_A(bool value)
    {
        _btnA.SetActive(value);
    }



    public void A_1_ButtonClicked()
    {
        switch (CurrentA)
        {
            case ButtonMode_A.ChooseTurn:
                SetBtn_A(false);
                _system.ChooseTure();
                //_btnTxt_A_1.text = "choose turn";
                break;
        }
    }
    public void B_ButtonsClicked()
    {

    }
    public void C_ButtonClicked()
    {

    }
}
public enum ButtonMode_A
{
    ChooseTurn
}
