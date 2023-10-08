using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MonsterAI : MonoBehaviour
{
    Rigidbody2D _rig;
    public int nextMove;
    public int _speed;
    GameObject _player;

    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rig = GetComponent<Rigidbody2D>();
        Invoke("MoveLogic", 3);
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(_player.transform.position, gameObject.transform.position) < 3f)
        {
            CancelInvoke("MoveLogic");
            playerFar();
        }
        else
        {
            _rig.velocity = new Vector2(nextMove * _speed, _rig.velocity.y);

            Vector2 frontVec = new Vector2(_rig.position.x + nextMove, _rig.position.y);
            Debug.DrawRay(_rig.position+ Vector2.right * nextMove, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(_rig.position + Vector2.right * nextMove, Vector3.down, 1, LayerMask.GetMask("Ground"));
            if (rayHit.collider == null)
            {
                // 애니메이션 낭떠러지에서 점프 
                // 지금은 반대로 가기 
                nextMove = nextMove * -1;
                CancelInvoke("MoveLogic"); 
                Invoke("MoveLogic", 3);
            }
        }
        
    }


    void MoveLogic()
    {
        nextMove= Random.Range(-1, 2);

        float nextLogicTime = Random.Range(2f, 4f);
        Invoke("MoveLogic", nextLogicTime);
    }

    void playerFar()
    {
        Vector3 moveVector = (_player.transform.position - gameObject.transform.position);
        Vector3 dirVector = moveVector.normalized;
        Vector3 lastVector = dirVector * _speed * 1.2f;
        gameObject.transform.position = gameObject.transform.position + lastVector * Time.deltaTime;
    }
}
