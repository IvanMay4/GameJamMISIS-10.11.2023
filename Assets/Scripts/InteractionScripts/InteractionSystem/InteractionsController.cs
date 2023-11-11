using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace VHS
{
    public class InteractionsController : MonoBehaviour
    {
        [Header("Data")]
        public InteractionInput interactionInput;

        public InteractionData interactionData;

        [Space]
        [Header("Ray Settings")]

        public float rayDistance;

        public float raySphereRadius;

        public LayerMask interactableLayer;

        public GameObject uiObject;

        private Camera m_cam;

        private bool m_interacting;

        private float m_holdTime = 0f;

        private void Awake()
        {
            m_cam = FindObjectOfType<Camera>();
        }

        private void Start()
        {
            uiObject.SetActive(false);
        }

        private void Update()
        {
            CheckForInteractable();
            CheckForInteractableInput();
        }
        void ShowScreen()
        {
            uiObject.SetActive(true);
        }

        void CheckForInteractable()
        {
            Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
            RaycastHit _hitInfo;

            bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo, rayDistance, interactableLayer);

            if (_hitSomething) 
            {
                InteractableBase _interctable = _hitInfo.transform.GetComponent<InteractableBase>();
                
                if (_interctable != null)
                {
                    if (interactionData.IsEmpty())
                    {
                        interactionData.Interactable = _interctable;
                    }
                    else
                    {
                        if (!interactionData.IsSameInteractable(_interctable))
                        {
                            interactionData.Interactable = _interctable;
                            ShowScreen();
                            
                        }
                    }
                }
            }
            else
            {
                uiObject.SetActive(false);
                interactionData.ResetData();
            }

            Debug.DrawRay(_ray.origin, _ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
        }

        void CheckForInteractableInput()
        {
            if (interactionData.IsEmpty())
            {
                return;
            }
            if (interactionInput.IntercatedClicked)
            {
                m_interacting = true;
                m_holdTime = 0f;
            }

            if (interactionInput.IntercatedRelease)
            {
                m_interacting = false;
                m_holdTime = 0f;
            }

            if (m_interacting)
            {
                if (interactionData.Interactable.IsInteractable)
                {
                    return;
                }

                if (interactionData.Interactable.HoldInteract)
                {
                    m_holdTime += Time.deltaTime;

                    if(m_holdTime >= interactionData.Interactable.HoldDuration)
                    {
                        interactionData.Interact();
                        m_interacting=false;
                    }
                }
                else
                {
                    interactionData.Interact();
                    m_interacting = false;
                }
            }
        }
    }
}
