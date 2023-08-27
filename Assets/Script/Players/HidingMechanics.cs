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
    public Transform player;
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
    public PlayerHealth _playerHealth;

    [Header("inform enemies")]
    public float _informRadius;
    public LayerMask enemyLayer;
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

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _informRadius,enemyLayer);
        foreach(Collider2D en in enemies)
        {
            if(en.TryGetComponent<Enemy>(out Enemy e))  e._playerHide = true;
        }

        _movement.enabled = !isHiding;
    }
    public void Hide(Transform hidePlace)
    {
        player.position = hidePlace.position;
        _HideUI.SetActive(true);
        _backgroundHideUI.DOFade(_targetAlphaforBackground, .4f);
        Vector3 pos = Camera.main.WorldToScreenPoint(hidePlace.position);
        _characterCoverHideUI.GetComponent<Image>().DOFade(_targetAlphaofCover, .3f).SetDelay(.1f).OnStart(() => { _characterCoverHideUI.DOMove(pos, .3f); });
        //_characterCoverHideUI.position = pos;
        isHiding = true;
        _movement.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        foreach (GameObject g in itemsToHide)
        {
            g.SetActive(false);
        }
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _informRadius, enemyLayer);
        foreach (Collider2D en in enemies)
        {
            if (en.TryGetComponent<Enemy>(out Enemy e))
            {
                e._playerHide = true;
                _playerHealth.removeFromEnemyList(e);
               // _playerHealth.isDecreasingHealth = false;
            }
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
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _informRadius, enemyLayer);
        foreach (Collider2D en in enemies)
        {
            if(en.TryGetComponent<Enemy>(out Enemy E)) E._playerHide = false;
        }

    }
    private void ObjectFound()
    {
        // Code to run when an object is found
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _informRadius);
    }
}
