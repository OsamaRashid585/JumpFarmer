using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    private Vector3 _startPos;
    private float _colliderWidth;
    private Player _playerScript;

    void Start()
    {
        _playerScript = FindObjectOfType<Player>();
        _startPos = transform.position;
        _colliderWidth = GetComponent<BoxCollider>().size.x / 2;

    }

    void FixedUpdate()
    {
        Movement();
        RepeatBackground();
    }
    private void Movement()
    {
        //background movement
        if (_playerScript._gameOver == false)
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }

    }
    private void RepeatBackground()
    {
        if (transform.position.x < _startPos.x - _colliderWidth)
        {
            transform.position = _startPos;
        }
    }

}
