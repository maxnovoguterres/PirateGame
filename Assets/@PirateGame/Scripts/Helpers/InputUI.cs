using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Helpers
{
    public class InputUI : MonoBehaviour
    {
        public static bool BlockedByUI;
        private EventTrigger eventTrigger;

        private void Start ()
        {
            eventTrigger = GetComponent<EventTrigger>() ?? gameObject.AddComponent<EventTrigger>();
            if (eventTrigger != null)
            {
                EventTrigger.Entry enterUIEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
                // Pointer Enter
                enterUIEntry.callback.AddListener((eventData) => { EnterUI(); });
                eventTrigger.triggers.Add(enterUIEntry);

                //Pointer Exit
                EventTrigger.Entry exitUIEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
                exitUIEntry.callback.AddListener((eventData) => { ExitUI(); });
                eventTrigger.triggers.Add(exitUIEntry);
            }
        }

        public void EnterUI ()
        {
            Debug.Log($"Is Over UI");
            //BlockedByUI = true;
        }
        public void ExitUI ()
        {
            Debug.Log($"Is Not Over UI");
            //BlockedByUI = false;
        }

        public bool IsMouseOverUI ()
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResultsList = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);

            for (int i = 0; i < raycastResultsList.Count; i++)
            {
                //if (raycastResultsList[i].gameObject.GetComponent<MouseUIClickThrough>() != null)
                //{
                //    raycastResultsList.RemoveAt(i);
                //    i--;
                //}
                //else if (raycastResultsList[i].gameObject.GetComponentInParent<RPGenCanvas>() == null)
                //{
                //    raycastResultsList.RemoveAt(i);
                //    i--;
                //}
                //else if (raycastResultsList[i].gameObject.GetComponent<RPGenCanvas>() != null)
                //{
                //    raycastResultsList.RemoveAt(i);
                //    i--;
                //}
            }

            return raycastResultsList.Count > 0;
        }
    }
}