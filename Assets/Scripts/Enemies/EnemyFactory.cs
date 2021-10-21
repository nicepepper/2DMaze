using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "2DMaze/EnemyFactory")]
public class EnemyFactory : GameObjectFactory
{
    [SerializeField] private Enemy _enemyPrefab;

    public Enemy Get()
    {
        Enemy instance = CreateGameObjectInstance(_enemyPrefab);
        instance.OriginFactory = this;
        return instance;
    }

    public void Reclainm(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
