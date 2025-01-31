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
        print("마우스가 올라감" + _canClick);
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
    /// 오브젝트와 자식들의 레이어를 재귀적으로 변경하는 함수
    /// </summary>
    /// <param name="obj">변경할 게임 오브젝트</param>
    /// <param name="layer">변경할 레이어 ID</param>
    private void ChangeLayerRecursively(GameObject obj, int layer)
    {
        if (obj == null) return;

        // 현재 오브젝트의 레이어를 변경
        obj.layer = layer;

        // 자식 오브젝트가 있다면 재귀적으로 레이어 변경
        foreach (Transform child in obj.transform)
        {
            ChangeLayerRecursively(child.gameObject, layer);
        }
    }
}
