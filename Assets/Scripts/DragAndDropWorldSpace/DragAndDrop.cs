using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{

    [Header("Input")]
    public InputActionReference trackingAction;
    public InputActionReference clickingAction;

    [Header("Camera")]
    public Camera cam;

    //Stores the position the player clicks on the screen
    private Vector2 currentTouchPos;

    //Stores the position of the object on the screen
    private Transform selectedObject;

    //Determines the exit position of the selected object
    private Vector3 offset;

    //Allow the selected object to move on the screen
    private Plane dragPlane;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        trackingAction.action.Enable();
        clickingAction.action.Enable();

        trackingAction.action.performed += OnTouchPosition;
        clickingAction.action.performed += OnTouchPress;
        clickingAction.action.canceled += OnTouchRelease;
    }

    // Update is called once per frame
    private void OnDisable()
    {
        trackingAction.action.performed += OnTouchPosition;
        clickingAction.action.performed += OnTouchPress;
        clickingAction.action.canceled += OnTouchRelease;

        trackingAction.action.Disable();
        clickingAction.action.Disable();
    }

    private void OnTouchPress(InputAction.CallbackContext context)
    {
        Ray ray = cam.ScreenPointToRay(currentTouchPos);
        if(Physics.Raycast(ray, out RaycastHit  hit))
        {
            selectedObject= hit.transform;
            dragPlane = new Plane(-cam.transform.forward, hit.point);
            offset = selectedObject.position - hit.point;
        }
    }

    private void OnTouchPosition(InputAction.CallbackContext context)
    {
        currentTouchPos = context.ReadValue<Vector2>();

        if (selectedObject != null)
        {
            Ray ray = cam.ScreenPointToRay(currentTouchPos);
            if (dragPlane.Raycast(ray, out float distance))
            {
                selectedObject.position = ray.GetPoint(distance) + offset;
            }
        }
    }

    private void OnTouchRelease(InputAction.CallbackContext context)
    {
        selectedObject = null;
    }
}
