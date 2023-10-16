using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    Vector3 cameraPosition;

    [SerializeField]
    Vector2 center;
    [SerializeField]
    Vector2 mapSize;

    [SerializeField]
    float cameraMoveSpeed;
    float height;
    float width;

    [SerializeField]
    GameObject[] _maps;
    int _mapIndex;
    public int nextMap { get { return _mapIndex; } set { _mapIndex = value; } }

    public static CameraLimit instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        center = _maps[0].transform.position;
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void Update()
    {
        center = _maps[nextMap].transform.position;
    }

    void FixedUpdate()
    {
        LimitCameraArea();
    }

    void LimitCameraArea()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          playerTransform.position + cameraPosition,
                                          Time.deltaTime * cameraMoveSpeed);
        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}




