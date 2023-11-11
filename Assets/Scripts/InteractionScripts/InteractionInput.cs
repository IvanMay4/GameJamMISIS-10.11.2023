using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{

    [CreateAssetMenu(fileName = "InteractionInputData", menuName = "InteractionSystem/InputData")]
    public class InteractionInput : ScriptableObject
    {
        private bool m_intercatedClicked;

        private bool m_intercatedRelease;

        public bool IntercatedClicked
        {
            get => m_intercatedClicked;
            set => m_intercatedClicked = value;
        }

        public bool IntercatedRelease
        {
            get => m_intercatedRelease;
            set => m_intercatedRelease = value;
        }

        public void ResetInput()
        {
            m_intercatedClicked = false;
            m_intercatedRelease = false;
        }
    }
}
