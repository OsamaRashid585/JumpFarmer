using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstical;
    private Player _playersScript;

    void Start()
    {
        _playersScript = FindObjectOfType<Player>();
        InvokeRepeating("SpawnObstical", 1, Random.Range(2, 6));
    }

    void SpawnObstical()
    {
        if (_playersScript._gameOver == false)
        {
            Instantiate(_obstical, transform.position, Quaternion.identity);
        }

    }
}
