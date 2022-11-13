using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Sean
{
    public class H2AReset : Interactive
    {
        [SerializeField]private Transform gearSprite;

        public override void EmptyClicked()
        {
            //­«¸m¹CÀ¸
            GameController.Instance.ResetGame();
            gearSprite.DOPunchRotation(Vector3.forward * 180, 1, 1, 0);
        }
    }
}