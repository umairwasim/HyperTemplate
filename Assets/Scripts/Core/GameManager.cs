﻿using System;
using System.Collections;
using NaughtyAttributes;
using Rhodos.Mechanics.Bases;
using UnityEngine;

namespace Rhodos.Core
{
    /// <summary>
    /// General game manager. Handles game flow and also serves as service locator. 
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public bool canPlay;
        [Tooltip("Unique mechanic disables level manager")]
        [OnValueChanged("GameTypeCheck")]
        public GameType gameType;
        [field: SerializeField] public Managers Managers { get; private set; }
        public static GameManager I { get; private set; }

        private void Awake()
        {
            if (I == null)
            {
                I = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Handles mechanic change and/or level success status.
        /// </summary>
        public Coroutine OnSuccess()
        {
            return StartCoroutine(InnerOnSuccess());
            
            IEnumerator InnerOnSuccess()
            {
                yield return StartCoroutine(Managers.MechanicManager.ActiveMechanic.OnEnd());

                if (Managers.MechanicManager.DidLevelEnd)
                {
                    Managers.SaveLoadManager.IncreaseLevel();
                    StartCoroutine(UIManager.ChangeUI(UIManager.MainScreens.Success));
                    AnalyticsManager.ShowInterstitial();
                }
                else
                {
                    Managers.MechanicManager.IncreaseMechanicCounter();
                    yield return StartCoroutine(Managers.MechanicManager.ActiveMechanic.OnStart());
                }
            }
        }

        public Coroutine OnFail()
        {
            return StartCoroutine(InnerOnFail());

            IEnumerator InnerOnFail()
            {
                yield return StartCoroutine(Managers.MechanicManager.ActiveMechanic.OnEnd());
                StartCoroutine(UIManager.ChangeUI(UIManager.MainScreens.Fail));
            }
        }

        private void GameTypeCheck()
        {
            if (gameType == GameType.UniqueMechanics)
            {
                Managers.LevelManager.gameObject.SetActive(false);
                Managers.MechanicManager.isGameTypeUniqueMechanics = true;
            }
            else
            {
                Managers.LevelManager.gameObject.SetActive(true);
                Managers.MechanicManager.isGameTypeUniqueMechanics = false;

            }
        }

        public enum GameType
        {
            UniqueLevels,
            UniqueMechanics
        }
    }

    [Serializable]
    public class Managers
    {
        [field: SerializeField] public CameraManager CameraManager { get; private set; }
        [field: SerializeField] public UIManager UIManager { get; private set; }
        [field: SerializeField] public LevelManager LevelManager { get; private set; }
        [field: SerializeField] public MechanicManager MechanicManager { get; private set; }
        [field: SerializeField] public SaveLoadManager SaveLoadManager { get; private set; }
    }
}