using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class EnemyController : Shared.Controller<EnemyController>
    {
        public void ChasePlayer(EnemyView View)
        {
            MovementView movementView = View.GetMovementView();
            if (!movementView.Model.isChasing)
            {
                movementView.Model.isChasing = Vector2.Distance(View.transform.position, movementView.Model.target.position) <= View.Model.detectionRange;
            }
        }
    }
}