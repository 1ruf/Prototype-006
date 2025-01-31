using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.VirtualTexturing;

public class Gun : MonoBehaviour
{
    [SerializeField] private string _outlineLayerName = "Outline";
    [SerializeField] private string _gunLayerName = "Gun";

    public UnityEvent GunClicked;

    private bool _canClick;

    public void SetGunClick(bool value)
    {
        _canClick = value;
    }

    private void OnMouseEnter()
    {
        print("���콺�� �ö�" + _canClick);
        SetLayer(gameObject, LayerMask.NameToLayer(_outlineLayerName));
    }
    private void OnMouseExit()
    {
        SetLayer(gameObject, LayerMask.NameToLayer(_gunLayerName));
    }
    private void OnMouseDown()
    {
        if (_canClick == false) return;
        SetLayer(gameObject, LayerMask.NameToLayer(_gunLayerName));
        _canClick = false;
        GunClicked?.Invoke();
    }

    private void SetLayer(GameObject target,int targetLayer)
    {
        if (_canClick == false) return;
        ChangeLayerRecursively(target, targetLayer);
    }

    //----------------------by.ChatGPT----------------------
    /// <summary>
    /// ������Ʈ�� �ڽĵ��� ���̾ ��������� �����ϴ� �Լ�
    /// </summary>
    /// <param name="obj">������ ���� ������Ʈ</param>
    /// <param name="layer">������ ���̾� ID</param>
    private void ChangeLayerRecursively(GameObject obj, int layer)
    {
        if (obj == null) return;

        // ���� ������Ʈ�� ���̾ ����
        obj.layer = layer;

        // �ڽ� ������Ʈ�� �ִٸ� ��������� ���̾� ����
        foreach (Transform child in obj.transform)
        {
            ChangeLayerRecursively(child.gameObject, layer);
        }
    }
}
