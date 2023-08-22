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

    [SerializeField] private bool isHiding=false;
    private void Start()
    {
        // Start the CheckForObjects coroutine
        StartCoroutine(CheckForObjects());
    }

    private IEnumerator CheckForObjects()
    {
        while (true)
        {
            // Use OverlapCircle to check for objects within the checkRadius and on the layerToCheck layer
            currentHideObject = Physics2D.OverlapCircle(transform.position, checkRadius, layerToCheck);

            // If any objects were found
            if (currentHideObject)
            {
                // Run the ObjectFound function
                ObjectFound();
            }

            // Wait for the checkInterval before checking again
            yield return new WaitForSeconds(checkInterval);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && currentHideObject)
        {
            if(!isHiding)
            {
                Hide();
            }
            else
            {
                UnHide();
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Hide();
        }if(Input.GetKeyDown(KeyCode.Z))
        {
            UnHide();
        }
    }
    [SerializeField] private GameObject _HideUI;
    [SerializeField] private Image _backgroundHideUI;
   [SerializeField]  private float _targetAlphaforBackground;
   [SerializeField]  private RectTransform _characterCoverHideUI;
     [SerializeField] private float _targetAlphaofCover;

    [Header("references")]
    [SerializeField] S_Movement _movement;
    [SerializeField] GameObject[] itemsToHide;
    void Hide()
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
    private void UnHide()
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
