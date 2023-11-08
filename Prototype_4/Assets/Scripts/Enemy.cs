using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Enemy : MonoBehaviour
{
    private float _speed = 70;

    private GameObject _player;

    private Rigidbody _rigidbody;

    private int _yDestroyTrigger = -2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = (_player.transform.position - transform.position).normalized; 
        _rigidbody.AddForce(playerDirection * _speed);
        if (transform.position.y < _yDestroyTrigger)
            Destroy(gameObject);
    }
}
