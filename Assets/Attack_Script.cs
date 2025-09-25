using UnityEngine;

public class Attack_Script : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    private object camAnim;
    private object playerAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenAttack <= 0) {

            if (Input.GetKey(KeyCode.F))
            {
                camAnim.SetTrigger("shake");
                playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, );
                for (int i = 0; i < enemiesToDamage.Length; i++) {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }

                timeBetweenAttack = startTimeBetweenAttack;

            }
            else
            {
                timeBetweenAttack -= Time.deltaTime;
            }
            void OnDrawGizmosSelected()
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(attackPos.position, attackRange);
            }
        }
    }
}

        