


using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class TorchLightController : MonoBehaviour
{
    public Transform _torchLightTransform;
    public bool _torchOn = true;
    public GameObject _torchLightObject;
    public float blinkDuration = .5f;
    public Light2D _centerSelfLight;
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        RotateTowardsInputDirection(horizontalInput, verticalInput);

        if(Input.GetKeyDown(KeyCode.R))
        {
            _torchOn = !_torchOn;
            _torchLightObject.SetActive(_torchOn);
            if (_torchOn) _centerSelfLight.intensity = 2f;
            else _centerSelfLight.intensity = 1f;
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(Blink());
        }
    }
    private IEnumerator Blink()
    {
        float timeElapsed = 0f;
        while (timeElapsed < blinkDuration)
        {
            _torchLightObject.SetActive(!_torchLightObject.activeSelf);
            timeElapsed += blinkDuration / 5f;
            yield return new WaitForSeconds(blinkDuration / 5f);
        }
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