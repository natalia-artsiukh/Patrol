using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] 
    private float _playerSpeed;
    private List<GameObject> _targets = new();

    private int _nextTarget;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (_targets.Count == 0) return;

        var targetPosition = _targets[_nextTarget].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _playerSpeed * Time.deltaTime);
    }

    private void GetNextTarget()
    {
        _nextTarget += 1;
        if (_targets.Count == _nextTarget)
        {
            _nextTarget = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_targets.Count == 0) return;
        if (collision.gameObject == _targets[_nextTarget] && collision.gameObject.tag != "Floor")
        {
            GetNextTarget();
            var targetColor = _targets[_nextTarget].GetComponent<Renderer>().material.color;
            _renderer.material.color = targetColor;
        }
       
        
    }

    public void AddTargets(GameObject target)
    {
        _targets.Add(target);
    }
    
    
}
