using JetBrains.Annotations;
using Unity.VisualScripting;
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

    // Assign this in the Inspector (or rely on SwordCooldownManager.instance)
    public SwordCooldownManager swordCooldownManager;

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
            // Preferred: use the reference assigned in the Inspector
            if (swordCooldownManager != null)
            {
                swordCooldownManager.CooldownStart(1f);
            }
            // Fallback: use the manager's static instance (if it sets instance in Awake)
            else if (SwordCooldownManager.instance != null)
            {
                SwordCooldownManager.instance.CooldownStart(1f);
            }
            else
            {
                Debug.LogWarning("SwordCooldownManager not assigned and instance is null.");
            }

            isAttacking = true;
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyScript>().TakeDamage(damageToDeal);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}