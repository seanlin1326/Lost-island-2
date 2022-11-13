using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    [CreateAssetMenu(fileName = "GameH2A_SO",menuName ="MiniGameData/GameH2A_SO")]
    public class GameH2A_SO : ScriptableObject
    {
       [SceneName] public string gameName;
        [Header("�y���W�r�M�������Ϥ�")]
        public List<BallDetails> ballDataList = new List<BallDetails>();
        [Header("�C���޿�ƾ�")]
        public List<Connections> lineConnections = new List<Connections>();
        public List<BallName> startBallOrder = new List<BallName>();
        public BallDetails GetBallDetails(BallName ballName)
        {
            return ballDataList.Find(b => b.ballName == ballName);
        }
    }
    [System.Serializable]
    public class BallDetails
    {
        public BallName ballName;
        public Sprite wrongSprite;
        public Sprite rightSprite;
    }
    [System.Serializable]
    public class Connections
    {
        public int from;
        public int to;
    }
}