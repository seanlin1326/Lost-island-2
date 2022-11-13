using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Ball : MonoBehaviour
    {
      [SerializeField]private SpriteRenderer spriteRenderer;

        public BallDetails ballDetails;
        public bool isMatch;

        public void SetupBall(BallDetails ball)
        {
            ballDetails = ball;

            if (isMatch)
            {
                SetRight();    
            }
            else
            {
                SetWrong();
            }
        }
        
        public void SetRight()
        {
            spriteRenderer.sprite = ballDetails.rightSprite;
        }
        public void SetWrong()
        {
            spriteRenderer.sprite = ballDetails.wrongSprite;
        }
    }
}
