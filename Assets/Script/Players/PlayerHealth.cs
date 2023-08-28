using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerHealth : MonoBehaviour
{

    public float _startingHealth;
    private float health;
    public float minHealth;
    public RectTransform _healthBar;
    public bool isDecreasingHealth;
    public float _healthDecreaseRate;
    public float _healthIncreaseRate;
    public UnityEvent _dieEvent;

    public List<Enemy> chasingEnemies = new List<Enemy>();

    private void Start()
    {
        _healthBar.sizeDelta = new Vector2(_startingHealth, 17);
    }

    private void Update()
    {
        if(isDecreasingHealth)
        {

            if (!_healthBar.gameObject.activeInHierarchy)
                _healthBar.gameObject.SetActive(true);

            if (_healthBar.sizeDelta.x <= minHealth)
                DieFunction();
            else Decrease();
        }
        else
        {
            if (_healthBar.sizeDelta.x <= _startingHealth)
                Increase();
           
        }
       if (chasingEnemies.Count > 0)
            isDecreasingHealth = true;
        else
            isDecreasingHealth = false;

        if (!isDecreasingHealth && _healthBar.sizeDelta.x >= _startingHealth && _healthBar.gameObject.activeInHierarchy)
            _healthBar.gameObject.SetActive(false);

    }
    public void removeFromEnemyList(Enemy e)
    {
        if (chasingEnemies.Contains(e))
        {
            chasingEnemies.RemoveAt(chasingEnemies.Count - 1);
        }
    }
    public void addEnemy(Enemy e)
    {
        if (!chasingEnemies.Contains(e)) chasingEnemies.Add(e);
    }
    private void DieFunction()
    {
        if (_dieEvent != null) _dieEvent.Invoke();
    }
    public void Decrease()
    {
        _healthBar.sizeDelta = new Vector2(_healthBar.sizeDelta.x - _healthDecreaseRate*Time.deltaTime, _healthBar.sizeDelta.y);
        
    }
    public void Increase()
    {
        _healthBar.sizeDelta = new Vector2(_healthBar.sizeDelta.x + _healthIncreaseRate*Time.deltaTime, _healthBar.sizeDelta.y);
    }
}
