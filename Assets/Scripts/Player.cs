using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float _jumpForce = 5.0f;
    private float _doubleJumpForce = 2.5f;
    private float _gravity = -9.81f;
    private float _gravityScale = 5;
    private float _velocity;
    private float _speed = 5.0f;
    private int _coinScore = 0;
    private int _lives = 3;

    private UIManager _uiManager;

    private bool _canDoubleJump = false;

    private CharacterController _charController;

    private void Start()
    {
        _charController = transform.GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_uiManager == null)
        {
            Debug.LogError("UI Manager in player script is null");
        }
    }

    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal");

        if (_charController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
             _velocity = Mathf.Sqrt(_jumpForce * -2f * _gravity * _gravityScale);
            _canDoubleJump = true;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true)
            {
                _velocity += Mathf.Sqrt(_doubleJumpForce * -2f * _gravity * _gravityScale);
                _canDoubleJump = false;
            }
        }

        _velocity += _gravity * _gravityScale * Time.deltaTime;

        Vector3 distance = new Vector3(hInput, 0, 0);
        distance = distance * _speed;
        distance.y = _velocity;
        _charController.Move(distance * Time.deltaTime); 
    }

    public void coinCollected()
    {
        _coinScore += 10;
        _uiManager._coinScoreUpdate(_coinScore);
    }

    public void livesManager()
    {
        _lives--;

        if (_lives < 1)
        {
            SceneManager.LoadScene("GameScreen");
        }

        _uiManager.livesCountUpdate(_lives);
    }
}
