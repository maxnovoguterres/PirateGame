using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class MovementController : Shared.Controller<MovementController>
    {
        public void Move (MovementView View)
        {
            Rigidbody2D rb = View.GetRigidbody();

            if (View.Model.isPlayer)
            {
                float verticalMovement = InputController.Instance.GetVerticalMovement();
                if (verticalMovement < 0)
                {
                    verticalMovement = 0;
                }
                if (verticalMovement == 0)
                {
                    return;
                }
                rb.AddForce(View.transform.up * View.Model.moveSpeed * verticalMovement, ForceMode2D.Force);
            }
            else
            {
                if (View.Model.isChasing)
                {
                    EnemyView enemyView = View.GetEnemyView();
                    if (enemyView.Model.enemyType == EnemyType.Shooter)
                    {
                        if (Vector2.Distance(View.transform.position, View.Model.target.position) <= View.Model.maxRange)
                        {
                            if (!enemyView.Model.isShooting)
                            {
                                enemyView.StartShooting();
                            }
                            return;
                        }
                        if (enemyView.Model.isShooting)
                        {
                            enemyView.StopShooting();
                        }
                    }
                    rb.AddForce(View.transform.up * View.Model.moveSpeed, ForceMode2D.Force);
                }
                else
                {
                    return;
                }
            }
            rb.velocity = new Vector2(Mathf.Min(View.Model.maxVelocity, rb.velocity.x), Mathf.Min(View.Model.maxVelocity, rb.velocity.y));
        }

        public void Rotate (MovementView View)
        {
            if (View.Model.isPlayer)
            {
                float horizontalMovement = InputController.Instance.GetHorizontalMovement();
                if (horizontalMovement == 0)
                {
                    return;
                }
                float rotationVelocity = View.Model.rotationSpeed * -horizontalMovement * Time.deltaTime + View.transform.localEulerAngles.z;
                View.transform.localEulerAngles = Vector3.forward * rotationVelocity;
            }
            else
            {
                if (View.Model.isChasing)
                {
                    Vector2 direction = View.Model.target.position - View.transform.position;
                    float angleToSubtract = 90;

                    CheckForObstacles(View, ref direction, ref angleToSubtract);

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - angleToSubtract;
                    Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    View.transform.rotation = Quaternion.RotateTowards(View.transform.rotation, targetRotation, View.Model.rotationSpeed * Time.deltaTime);
                }
            }
        }

        private void CheckForObstacles(MovementView View, ref Vector2 direction, ref float angleToSubtract)
        {
            RaycastHit2D hit = Physics2D.Raycast(View.transform.position, direction, View.Model.detectionRange, View.Model.obstacleLayer);
            if (hit.collider != null)
            {
                direction = hit.point - (Vector2)View.transform.position;
                angleToSubtract = 0;
            }
        }
    }
}