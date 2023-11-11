using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace VHS
{
    public class InputHandler : MonoBehaviour
    {
        #region Data
        [BoxGroup("Input Data")]
        public InteractionInput interactionInput;
        #endregion

        #region BuiltIn Methods

        private void Start()
        {
            interactionInput.ResetInput();
        }

        private void Update()
        {
            GetInteractionInput();
        }
        #endregion

        #region Custom Methods

        void GetInteractionInput()
        {
            interactionInput.IntercatedClicked = Input.GetKeyDown(KeyCode.E);
            interactionInput.IntercatedRelease = Input.GetKeyDown(KeyCode.E);
        }
        #endregion
    }
}
