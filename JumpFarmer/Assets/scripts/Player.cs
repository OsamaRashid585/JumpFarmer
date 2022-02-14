using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private float _jumpPower = 12f;
   [SerializeField] private float _physicsModifier = 2.5f;
    private bool _isGrounded;
    public bool _gameOver = false;

    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _crashSound;
    [SerializeField] private ParticleSystem _explosionPartical;
    [SerializeField] private ParticleSystem _footDustPartical;
    [SerializeField] private AudioSource _bgSound;
    [SerializeField] private GameObject _reStartButton;
    private AudioSource _audioSource;
    private Animator _animator;
    private Rigidbody _rb;

    void Start()
    {
        _reStartButton.SetActive(false);
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        Physics.gravity *= _physicsModifier;
    }

    void FixedUpdate()
    {
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _isGrounded = true;
            _footDustPartical.Play();
        }

        GameOver(collision);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _isGrounded = false;
            _animator.SetTrigger("Jump_trig");
            _audioSource.PlayOneShot(_jumpSound, 1f);
            _footDustPartical.Stop();
        }
    }

    private void GameOver(Collision col)
    {
        if (col.gameObject.CompareTag("obs"))
        {
            _isGrounded = false;
            _gameOver = true;
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            _explosionPartical.Play();
            _footDustPartical.Stop();
            _audioSource.PlayOneShot(_crashSound, 1f);
            _bgSound.Stop();
            _reStartButton.SetActive(true);

        }
    }
}
