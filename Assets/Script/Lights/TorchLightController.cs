/*using UnityEngine;

public class TorchLightController : MonoBehaviour
{
    private Camera mainCamera;
    public Transform _torchLightTransform;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RotateTowardsMousePosition(mousePosition);
    }

    private void RotateTowardsMousePosition(Vector2 targetPosition)
    {
        Vector2 objectPosition = _torchLightTransform.position;
        Vector2 direction = targetPosition - objectPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        _torchLightTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}*/


using UnityEngine;
using UnityEngine.UIElements;

public class TorchLightController : MonoBehaviour
{
    public Transform _torchLightTransform;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        RotateTowardsInputDirection(horizontalInput, verticalInput);
    }

    private void RotateTowardsInputDirection(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg - 90f;
            _torchLightTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        if (horizontal == 0 && vertical == 0)
        {
          //  _torchLightTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
    }
}