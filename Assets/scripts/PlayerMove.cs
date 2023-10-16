using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rig;
    [SerializeField] float _speed;
    [SerializeField] float _jump;
    [SerializeField] float _dashSpeed;



    bool _isJump = false;
    bool _isground = true;
    float _jumping = 0;
    public float _playerDmg;




    private void FixedUpdate()
    {
        Move();
    }
    void Update()
    {

        jumpable();
    }

    void Move()
    {
        Vector3 movePosition = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal" )< 0)
        {
            movePosition = Vector3.left;
            GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<Animator>().Play("IsMove");
        }
        else if(Input.GetAxisRaw("Horizontal")  > 0)
        {
            movePosition = Vector3.right;
            GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<Animator>().Play("IsMove");
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("Idle");
        }
        transform.position += movePosition * _speed * Time.deltaTime;
    }
    


    void jumpable()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isground == true)
        {
            _rig.AddForce(Vector2.up * _jump, ForceMode2D.Impulse);
            _jumping++;
            if (_jumping > 1)
            {
                _isground = false;
                if (_isground == false)
                {
                    gameObject.GetComponent<Animator>().Play("IsJump");
                }
                _jumping = 0;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isground = true;
            _jumping = 0;
        }
    }
}
    