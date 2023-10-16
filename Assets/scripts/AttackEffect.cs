using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    [SerializeField] GameObject attackEffectPrefab;
    float _coolTime = 2f;
    public float Cooltime { get { return GameObject.Find("RollStats").GetComponent<RollAndStats>().AS; } }
    float _remainAttack = 0.2f;

    private Camera _camera;
    float _sColltime;

    private void Start()
    {
        _camera = Camera.main;
        attackEffectPrefab.transform.position = new Vector2(1,1);
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

   
    public void Attack()
    {
        
        if (_coolTime <= 0)
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                GameObject attack = Instantiate(attackEffectPrefab, transform.position, transform.rotation);
                //attack.transform.localPosition += Vector3.up;
                _coolTime = Cooltime;
                Destroy(attack, _remainAttack);
                rotator(attack.transform);
            }
        }
        _coolTime -= Time.deltaTime;
    }

    void rotator(Transform eff)
    {

        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dirVec = mousePos - (Vector2)transform.position;


        eff.up = dirVec.normalized;
        eff.position += eff.up;
    }

    // 조금 거리가 




}
