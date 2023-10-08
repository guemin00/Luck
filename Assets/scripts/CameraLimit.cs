using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{

    public Transform _target;
    public float _speed;

    Transform _cameraLimit;

    public Transform[] Limit;

    Vector3 _cameraPosition = new Vector3(0, 0, -10);



    float _height;
    float _width;

  


    // Start is called before the first frame update
    void Start()
    {
        _height = Camera.main.orthographicSize;
        _width = _height*Screen.width/Screen.height;
        ChangeLimit(0);
    }

    public void ChangeLimit(int x)
    {
        _cameraLimit = Limit[x];
    }


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position =Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime*_speed );
        float lx = _cameraLimit.localScale.x*0.5f - _width;
        float clampX = Mathf.Clamp(transform.position.x, -lx+_cameraLimit.position.x, lx+_cameraLimit.position.x);

        float ly = _cameraLimit.localScale.y * 0.5f - _height;
        float clampY = Mathf.Clamp(transform.position.y, -ly+_cameraLimit.position.y, ly+_cameraLimit.position.y);

        transform.position = new Vector3(clampX, clampY, -10f );
    }
}
