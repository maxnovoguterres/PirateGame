using Assets.Scripts.View;
using Assets.Scripts.Controller.Shared;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class CameraController : Controller<CameraController>
    {
        [HideInInspector] public int currentWidth;
        [HideInInspector] public int currentHeight;

        [Range(0f, 1f)] public float smoothSpeed = 0.5f;
        public Vector3 minPos = new Vector3(0, 0, -10f);
        public Vector3 maxPos = new Vector3(0, 0, -10f);
        public Vector3 offset = new Vector3(0, 0, -10f);

        protected override void Awake()
        {
            if (Instance != null)
            {
                Instance.minPos = minPos;
                Instance.maxPos = maxPos;
                Instance.offset = offset;
                UpdateWidthAndHeight();
            }
            base.Awake();
        }

        void Start()
        {
            UpdateWidthAndHeight();
        }

        public void UpdateWidthAndHeight()
        {
            currentWidth = Camera.main.pixelWidth;
            currentHeight = Camera.main.pixelHeight;
        }

        public bool HasWidthAndHeightChanged()
        {
            return currentWidth != Camera.main.pixelWidth || currentHeight != Camera.main.pixelHeight;
        }

        public float GetCameraMinX()
        {
            float x = minPos.x;
            x -= Camera.main.orthographicSize * Camera.main.aspect;
            return x;
        }

        public float GetCameraMaxX()
        {
            float x = maxPos.x;
            x += Camera.main.orthographicSize * Camera.main.aspect;
            return x;
        }

        public float GetCameraMinY ()
        {
            float y = minPos.y;
            y -= Camera.main.orthographicSize;
            return y;
        }

        public float GetCameraMaxY ()
        {
            float y = maxPos.y;
            y += Camera.main.orthographicSize;
            return y;
        }

        // garante que a camera permaneça nos limites determinados
        public void CheckBounds (CameraView View)
        {
            View.transform.position = new Vector3(Mathf.Clamp(View.transform.position.x, minPos.x, maxPos.x),
                Mathf.Clamp(View.transform.position.y, minPos.y, maxPos.y),
                Mathf.Clamp(View.transform.position.z, minPos.z, maxPos.z));
        }

        public Vector3 SmoothPosition (Model.Camera Model, Vector3 position)
        {
            Vector3 smothedPosition = Vector3.Lerp(position, Model.target.position + offset, smoothSpeed);
            return smothedPosition;
        }
    }
}