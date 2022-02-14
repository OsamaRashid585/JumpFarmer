using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstical : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    private Player _playerScript;

    void Start()
    {
        _playerScript = FindObjectOfType<Player>();
    }

    void Update()
    {
        Movement();
        OffsetDestroy();
    }
    private void Movement()
    {
        //obstical movement
        if (_playerScript._gameOver == false)
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }
    }
    private void OffsetDestroy()
    {
        //offset destory
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
   
}
