using Cysharp.Threading.Tasks;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    public void SetUp(Vector2 moveDirection)
    {
        GetComponent<Rigidbody2D>().velocity = moveDirection * speed;

        DestroyAfterLifetime();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: Deal damage

        Destroy(gameObject);
    }

    private async void DestroyAfterLifetime()
    {
        await UniTask.Delay((int) lifeTime * 1000);

        Destroy(gameObject);
    }
}
