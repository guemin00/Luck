using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rig;
    [SerializeField] float _speed;
    [SerializeField] float _jump;
    [SerializeField] float _dashSpeed;


    

    bool _isground = true;
    float _jumping = 0;
    public float _playerDmg;




    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal") * _speed;
        _rig.velocity = new Vector2(x, _rig.velocity.y);
    }
    void Update()
    {

        jumpable();
        // Dash();
        

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

 

   



    /*
    void Dash()
    {
        
        if(Input.GetMouseButtonDown(1)) 
        {
            _isDash = true;
            _rig.gravityScale = 0f;
            _rig.AddForce(Vector2.right* 40f, ForceMode2D.Impulse);
            _dashCount--;
            _coolTime = 5f;
            if(_dashCount < 0)
            {
                _dashCount = 2;
            }
        }
        _coolTime -= Time.deltaTime;
    }

    */


}
    