using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    [SerializeField] private InputActionReference clickAction;
    [SerializeField] private InputActionReference pointerPosAction;
    [SerializeField] private RectTransform panelTransform;
    public RectTransform canvas;
    public RectTransform parent;
    public Camera uiCamera;



    private Vector2 _offset;
    private bool _isDragging;


    private void OnEnable()
    {
        clickAction.action.started += OnClickStarted;
        clickAction.action.canceled += OnClickCanceled;
        pointerPosAction.action.performed += OnPointMoved;
  

    }

    private void OnDisable()
    {
        clickAction.action.started -= OnClickStarted;
        clickAction.action.canceled -= OnClickCanceled;
        pointerPosAction.action.performed -= OnPointMoved;
        _isDragging = false;
        

    }

    private bool IsPointerOverObject(Vector2 pointerPos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(panelTransform, pointerPos, uiCamera);
    }

    private void OnClickStarted(InputAction.CallbackContext ctx)
    {
        var pointerPos = pointerPosAction.action.ReadValue<Vector2>();
        if (IsPointerOverObject(pointerPos))
        {
            _isDragging = true;
            ChangeParent();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(panelTransform, pointerPos, uiCamera, out var localPos);
            _offset = panelTransform.anchoredPosition - localPos;
        }
    }

    private void OnClickCanceled(InputAction.CallbackContext ctx)
    {
        _isDragging = false;
    }

    private void OnPointMoved(InputAction.CallbackContext ctx)
    {
        
        if (!_isDragging) return;
        var  pointerPos = ctx.ReadValue<Vector2>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pointerPos, uiCamera, out var localPos);
        panelTransform.anchoredPosition = localPos + _offset;
    }

    public void ChangeParent()
    {
        Vector3 worldPos = panelTransform.position;
        Vector2 worldSize = panelTransform.rect.size;
        Vector3 worldScale = panelTransform.lossyScale;
        

        panelTransform.SetParent(parent, worldPositionStays: true);

        Vector2 newSize = new Vector2(worldSize.x / panelTransform.lossyScale.x, worldSize.y / panelTransform.lossyScale.y);

        panelTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newSize.x);
        panelTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newSize.x);

        panelTransform.position = worldPos;
    }
}
