using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class RestartController : Shared.Controller<RestartController>
    {
        public void ResetLevel ()
        {
            PlayerView playerView = FindObjectOfType<PlayerView>(true);
            playerView.transform.position = Vector3.zero;
            playerView.transform.rotation = Quaternion.identity;
            Rigidbody2D playerRb = playerView.GetRigidbody();
            playerRb.velocity = Vector2.zero;
            playerRb.angularVelocity = 0;
            playerView.gameObject.SetActive(true);

            Globals.FindObjectsOfTypeAll<EnemyView>().ForEach(e =>
            {
                if (e.gameObject.activeSelf)
                {
                    e.Model.pool.Despawn(e.gameObject);
                }
            });
            Globals.FindObjectsOfTypeAll<HealthView>().ForEach(h => HealthController.Instance.ResetHealth(h));
            Globals.FindObjectsOfTypeAll<DestroyObjectView>().ForEach(d => d.Model.canDestroy = true);
            
            GameController.Instance.StartGame(true);
        }
    }
}