using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackCooldown;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(Cooldown());
            animator.SetTrigger("Atack");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null && isAttacking)
        {
            health.TakeDamage(_damage);
        }

    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_attackCooldown);
        isAttacking = false;
    }
}