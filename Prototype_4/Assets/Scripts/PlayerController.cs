using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int _speed = 150;
    private Rigidbody _rigidbody;
    private GameObject _focalPoint;
    private GameObject _powerUpIndicator;
    private bool _hasPowerUp;
    private const int _powerUpKnockbackForce = 500;
    private Vector3 _powerUpOffset = new Vector3(0, -0.5f, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("FocalPoint");
        _powerUpIndicator = GameObject.Find("PowerUpIndicator");
        _powerUpIndicator.gameObject.SetActive(false);
        _hasPowerUp = false;

    }

    // Update is called once per frame
    void Update()
    {
        float v_input = Input.GetAxis("Vertical");
        _rigidbody.AddForce(_focalPoint.transform.forward * (_speed * v_input),ForceMode.Force);
        _powerUpIndicator.transform.position = transform.position+_powerUpOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            _hasPowerUp = true;
            _powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        _hasPowerUp = false;
        _powerUpIndicator.gameObject.SetActive(false);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && _hasPowerUp)
        {
            Rigidbody enemyRB = other.gameObject.GetComponent<Rigidbody>();
            Vector3 direction = (other.transform.position - transform.position).normalized;
            enemyRB.AddForce(direction * _powerUpKnockbackForce, ForceMode.Impulse);
        }
            
    }
}
