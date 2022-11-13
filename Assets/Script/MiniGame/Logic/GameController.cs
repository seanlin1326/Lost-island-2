using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Sean
{
    public class GameController : Singleton<GameController>
    {
        public UnityEvent OnFinish;


        [Header("遊戲數據")]
        public GameH2A_SO gameData;
        public GameObject lineParent;

        public LineRenderer linePrefab;
        public Ball ballPrefab;

        public Transform[] holderTransforms;


        private void OnEnable()
        {
            EventHandler.CheckGameStateEvent += OnCheckGameStateEvent;
        }


        private void OnDisable()
        {
            EventHandler.CheckGameStateEvent -= OnCheckGameStateEvent;
        }
        private void Start()
        {
            DrawLine();
            CreateBall();
        }
        private void OnCheckGameStateEvent()
        {
            foreach (var ball in FindObjectsOfType<Ball>())
            {
                if (!ball.isMatch)
                {
                    return;
                }
            }
            Debug.Log("遊戲結束");
            foreach (var holder in holderTransforms)
            {
                holder.GetComponent<Collider2D>().enabled = false;
            }
                OnFinish?.Invoke();
        }
        public void ResetGame()
        {
            foreach (var holder in holderTransforms)
            {
                if(holder.childCount > 0)
                {
                    Destroy(holder.GetChild(0).gameObject);
                }
            }
            CreateBall();
        }
        public void DrawLine()
        {
            foreach (var connection in gameData.lineConnections)
            {
                var line = Instantiate(linePrefab, lineParent.transform);
                line.SetPosition(0, holderTransforms[connection.from].position);
                line.SetPosition(1, holderTransforms[connection.to].position);

                //創建每個holder的連接關係
                var holderFrom = holderTransforms[connection.from].GetComponent<Holder>();
                var holderTo = holderTransforms[connection.to].GetComponent<Holder>();
                holderFrom.linkHolders.Add(holderTo);
                holderTo.linkHolders.Add(holderFrom);
            }
        }
        public void CreateBall()
        {
            for (int i = 0; i < gameData.startBallOrder.Count; i++)
            {
                if(gameData.startBallOrder[i] == BallName.None)
                {
                    holderTransforms[i].GetComponent<Holder>().isEmpty = true;
                    continue;
                }
                Ball ball = Instantiate(ballPrefab,holderTransforms[i]);
                var currentHolderCreateTo = holderTransforms[i].GetComponent<Holder>();
                currentHolderCreateTo.CheckBall(ball);
                currentHolderCreateTo.isEmpty = false;
                ball.SetupBall(gameData.GetBallDetails(gameData.startBallOrder[i]));
            }
        }
    }
}