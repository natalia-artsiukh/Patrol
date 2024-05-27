using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidsSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject _pyramid;

    [SerializeField] 
    private PlayerHandler _player;
    

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PyramidSpawn();
        }
    }

    private void PyramidSpawn()
    {
        var positionX = Random.Range(-13f, 13f);
        var positionZ = Random.Range(-3f, 23f);
        var isSuitablePosition = Mathf.Pow(positionX, 2) + Mathf.Pow((positionZ - 10), 2) <= Mathf.Pow(13, 2);
        if (isSuitablePosition)
        {
            var pyramid = Instantiate(_pyramid, transform);
            pyramid.transform.position = new Vector3(positionX, -0.322f, positionZ);
            PyramidRecoloring(pyramid);
            _player.AddTargets(pyramid);
        }
        else
        {
            PyramidSpawn();
        }
    }

    private void PyramidRecoloring(GameObject pyramid)
    {
        var renderer = pyramid.GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 1f, 1f);
    }
}
