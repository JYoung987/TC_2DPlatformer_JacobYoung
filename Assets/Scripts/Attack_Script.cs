using JetBrains.Annotations;
using UnityEngine;

public class Attack_Script : MonoBehaviour
{
    public Animator myAnim;
    public bool isAttacking = false;
    public static Attack_Script instance;
    public Transform attackPos;
    public float attackRange = 1f;

    public int damageToDeal = 10;

    public AudioSource m_Attack1;
    public AudioSource m_Attack2;
    public AudioSource m_Attack3;

    public LayerMask whatIsEnemies;


    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        myAnim = GetComponent<Animator>();
    }
    void Update()
    {
        Attack();

    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            isAttacking = true;
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damageToDeal);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}