using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingMechanics : MonoBehaviour
{

    public LayerMask layerToCheck; // The layer to check for objects
    public float checkRadius = 5f; // The radius to check for objects
    public float checkInterval = 1f; // The time interval between checks
    private Collider2D currentHideObject;

    [SerializeField] internal bool isHiding=false;

    public InteractableObject _currentItemDetected;
    private void Start()
    {
        
    }

    [SerializeField] private GameObject _HideUI;
    [SerializeField] private Image _backgroundHideUI;
   [SerializeField]  private float _targetAlphaforBackground;
   [SerializeField]  private RectTransform _characterCoverHideUI;
     [SerializeField] private float _targetAlphaofCover;

    [Header("references")]
    [SerializeField] S_Movement _movement;
    [SerializeField] GameObject[] itemsToHide;
   public void Hide()
    {
        _HideUI.SetActive(true);
        _backgroundHideUI.DOFade(_targetAlphaforBackground, .4f);
        Vector3 pos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y, -10f));
        _characterCoverHideUI.GetComponent<Image>().DOFade(_targetAlphaofCover, .3f).OnStart(() => { _characterCoverHideUI.DOMove(pos, .3f); });

        isHiding = true;
        _movement.GetComponent<Rigidbody2D>().velocity= Vector3.zero;
        foreach(GameObject g in itemsToHide)
        {
            g.SetActive(false);
        }
        _movement.enabled = !isHiding;
    }
    public void UnHide()
    {
        _backgroundHideUI.DOFade(0, .4f);
        _characterCoverHideUI.GetComponent<Image>().DOFade(0, .3f).OnComplete(() =>
        {

        _HideUI.SetActive(false);
        });

        isHiding = false;
        _movement.enabled = !isHiding;
        foreach (GameObject g in itemsToHide)
        {
            g.SetActive(true);
        }

    }
    private void ObjectFound()
    {
        // Code to run when an object is found
        
    }

}
