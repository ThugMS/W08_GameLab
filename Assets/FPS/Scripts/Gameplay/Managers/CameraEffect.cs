using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Unity.FPS.Game;

namespace Unity.FPS.Gameplay
{
    public class CameraEffect : MonoBehaviour
    {
        public static CameraEffect instance;
        
        #region PublicVariables
        Camera cameraObj;
        #endregion

        #region PrivateVariables
        [SerializeField] private float m_effectTime = 0.05f;
        [SerializeField] private float m_effectPower = 1f;
        #endregion

        #region PublicMethod
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            cameraObj = GetComponent<Camera>();
        }

        public void ShotEffect()
        {
            StartCoroutine(IE_ShotEffect());
        }
        #endregion

        #region PrivateMethod
        public IEnumerator IE_ShotEffect()
        {
            cameraObj.fieldOfView = cameraObj.fieldOfView + m_effectPower;
            yield return new WaitForSeconds(m_effectTime);
            cameraObj.fieldOfView = cameraObj.fieldOfView - m_effectPower;
        }
        #endregion
    }
}
