using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float destroyTime;
    public float speed;
    public float dmg;

    public GameObject effect;

    Rigidbody missileRigidbody;

    void Awake()
    {
        missileRigidbody = GetComponent<Rigidbody>();

        missileRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            RaycastHit[] hits;

            hits = Physics.SphereCastAll(transform.position, 4, Vector3.up, 0f, LayerMask.GetMask("enemy"));

            List<IDamageable> targets = new List<IDamageable>();

            for (int i = 0; i < hits.Length; i++)
            {
                targets.Add(hits[i].collider.GetComponent<IDamageable>());
            }

            for (int i = 0; i < targets.ToArray().Length; i++)
            {
                // 상대방으로 부터 IDamageable 오브젝트를 가져오는데 성공했다면
                if (targets[i] != null)
                {
                    // 상대방의 OnDamage 함수를 실행시켜서 상대방에게 데미지 주기
                    targets[i].OnDamage(dmg, hits[i].point, hits[i].normal);
                }
            }


            GameObject.Instantiate(effect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
