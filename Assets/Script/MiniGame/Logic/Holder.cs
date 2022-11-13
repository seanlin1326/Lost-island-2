using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Holder : Interactive
    {
        public BallName matchBall;
        private Ball currentBall;
        public HashSet<Holder> linkHolders = new HashSet<Holder>();
        public bool isEmpty;

        public void CheckBall(Ball ball)
        {
            currentBall = ball;
            if(ball.ballDetails.ballName == matchBall)
            {
                currentBall.isMatch = true;
                currentBall.SetRight();
            }
            else
            {
                currentBall.isMatch = false;
                currentBall.SetWrong();
            }
        }
        public override void EmptyClicked()
        {
            foreach (var holder in linkHolders)
            {
                if (holder.isEmpty)
                {
                    //���ʲy
                    currentBall.transform.position = holder.transform.position;
                    currentBall.transform.SetParent(holder.transform);

                    //�洫�y
                    holder.CheckBall(currentBall);
                    this.currentBall = null;

                    //���ܪ��A
                    this.isEmpty = true;
                    holder.isEmpty = false;

                    EventHandler.CallCheckGameStateEvent();
                }
            }
        }
    }
}