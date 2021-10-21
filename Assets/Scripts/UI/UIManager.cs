using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI 
{
    public class UIManager : MonoBehaviour 
    {
        [SerializeField] private UIChooseDifficult _chooseDifficult;
        [SerializeField] private GameObject _uiGame;
        [SerializeField] private GameObject _uiEndGame;
        [SerializeField] private GameObject _hintReady;
        [SerializeField] private Button _btnRestart;

        private void Awake() 
        {
            GameEvent.OnChangeStage += OnChangeGameStage;
            _btnRestart.onClick.AddListener(GameController.RestartGame);
        }

        private void OnDestroy() 
        {
            GameEvent.OnChangeStage -= OnChangeGameStage;
        }

        private void OnChangeGameStage() 
        {
            var state = GameEvent.Current;
            
            _chooseDifficult.gameObject.SetActive(state == GameStage.PREPARE);
            _uiGame.SetActive(state == GameStage.READY || state == GameStage.START || state == GameStage.STOP);
            _hintReady.SetActive(state == GameStage.READY);
            _uiEndGame.SetActive(state == GameStage.STOP);
        }
    }
}
