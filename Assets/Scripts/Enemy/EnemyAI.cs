using LudumDare51.SO;
using UnityEngine;

namespace LudumDare51.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        public Node NextNode { set; private get; }

        public EnemyInfo Info { set; private get; }

        private Rigidbody2D _rb;

        private int _health;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _health = Info.BaseHealth;
            GetComponent<SpriteRenderer>().color = Info.Color;
        }

        private void FixedUpdate()
        {
            var targetPos = NextNode.transform.position;
            targetPos.x -= transform.position.x;
            targetPos.y -= transform.position.y;
            var angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            _rb.velocity = Info.Speed * Time.fixedDeltaTime * transform.right;
            if (Vector2.Distance(transform.position, NextNode.transform.position) < .1f)
            {
                NextNode = NextNode.NextNode;
            }
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}