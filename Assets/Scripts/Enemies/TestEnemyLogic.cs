using System.Collections;
using Data;
using Game;
using Map;
using UnityEngine;

public class TestEnemyLogic : MonoBehaviour
{
    [SerializeField] private TestEnemy _enemy;
    [SerializeField] private GameObject _target;
    
    private void Awake() 
    {
        GameEvent.OnReady += OnGameReady;
    }

    private void OnDestroy() 
    {
        GameEvent.OnReady -= OnGameReady;
    }

    private void OnGameReady() 
    {
        StopCoroutine(nameof(UpdateGame));
        StartCoroutine(nameof(UpdateGame));
    }
    
    private IEnumerator UpdateGame() 
    {
        while (GameEvent.Current == GameStage.READY) 
        {
            _enemy.WarpTo(new Vector3(170, 0, 170));
            _enemy.MoveTo(_target.transform.position);
            yield return null;
        }
    }
}
