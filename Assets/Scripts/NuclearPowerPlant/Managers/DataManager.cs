//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections;
using System.Collections.Generic;
using ThibautPetit;
using Unity.Collections;
using UnityEngine;


namespace PetrusGames.NuclearPlant.Managers.Data
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance = new DataManager();

        #region SERIALIZED FIELDS
        [Space(30)]
        [Header("lists of objects where you need to listen to there actions")]
        [Space(30)]
        [SerializeField] private List<GameObject> receiverIDCheckObjects;
        [Space(30)]
        [SerializeField] private HeatInfo heathInfo;
        [Space(30)]
        [SerializeField] private List<GameObject> gameObjectsFire;
        [Space(30)]
        [SerializeField] private List<GameObject> gameObjectsWater;
        // add all events needed here in lists !!!!!
        [Space(20)]
        [Header("Data received from json here ")]
        [Header("READ ONLY!!!")]
        [Space(50)]
        [SerializeField] private float score;
        [SerializeField] private float health;
        [Header("EnergyInfo")]
        [Space(30)]
        [SerializeField] private float energyGainPerGoodElement;
        [SerializeField] private float energyLossPerWrongElement;
        [SerializeField] private float energyMaxThreshold;
        [SerializeField] private float energyMinThreshold;
        [SerializeField] private float energyLossPerSecond;
        [SerializeField] private float maxEnergy;
        [SerializeField] private float goodRangeTick = 1f;
        [SerializeField] private float surchargeTick = 1f;
        [Header("HeatInfo")]
        [Space(30)]
        [SerializeField] private float maxHeat;
        [SerializeField] private float heatThreshhold;
        [SerializeField] private float heatGainPerSecond;
        [SerializeField] private float heatGainPerEnergySurcharge;
        [SerializeField] private float heatLossPerCoolDownTick;
        [SerializeField] private float heatGainPerWrongElement;
        [SerializeField] private float overHeatTick = 1f;
        [SerializeField] private float coolDownTick = 1f;
        [Header("Fire Extinguisher")]
        [Space(30)]
        [SerializeField] private float extinguisherSpeed;
        [SerializeField] private float chargesCoolDown;
        [Header("Conveyor Belt")]
        [Space(30)]
        [SerializeField] private float converyorBeltSpeed;
        [Header("Coolant")]
        [Space(30)]
        [SerializeField] private float coolantSpeed;
        [Header("Element Spawner")]
        [Space(30)]
        [SerializeField] private float elementSpawnTimer;
        [Header("Fire Spawn Timer")]
        [Space(30)]
        [SerializeField] private Vector2 fireSpawnerTimer;
        [Header("Claw")]
        [Space(30)]
        [SerializeField] private float clawsPeed;
        [Header("Damages")]
        [Space(30)]
        [SerializeField] private float damagePerElementExplosion;
        [SerializeField] private float damagePerElementFall;
        [SerializeField] private float damagePerOverheatTick;
        [SerializeField] private float damagePerWrongElement;
        [SerializeField] private float damagePerOverchargeTick;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        public float Health{get { return health; }set { health = value; }}
        public float EnergyGainPerGoodElement { get => energyGainPerGoodElement; set => energyGainPerGoodElement = value; }
        public float EnergyLossPerWrongElement { get => energyLossPerWrongElement; set => energyLossPerWrongElement = value; }
        public float EnergyMaxThreshold { get => energyMaxThreshold; set => energyMaxThreshold = value; }
        public float EnergyMinThreshold { get => energyMinThreshold; set => energyMinThreshold = value; }
        public float EnergyLossPerSecond { get => energyLossPerSecond; set => energyLossPerSecond = value; }
        public float MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
        public float GoodRangeTick { get => goodRangeTick; set => goodRangeTick = value; }
        public float SurchargeTick { get => surchargeTick; set => surchargeTick = value; }
        public float ExtinguisherSpeed { get => extinguisherSpeed; set => extinguisherSpeed = value; }
        public float ChargesCoolDown { get => chargesCoolDown; set => chargesCoolDown = value; }
        public float ConveryorBeltSpeed { get => converyorBeltSpeed; set => converyorBeltSpeed = value; }
        public float CoolantSpeed { get => coolantSpeed; set => coolantSpeed = value; }
        public float HeatThreshhold { get => heatThreshhold; set => heatThreshhold = value; }
        public float HeatGainPerSecond { get => heatGainPerSecond; set => heatGainPerSecond = value; }
        public float HeatGainPerEnergySurcharge { get => heatGainPerEnergySurcharge; set => heatGainPerEnergySurcharge = value; }
        public float HeatLossPerCoolDownTick { get => heatLossPerCoolDownTick; set => heatLossPerCoolDownTick = value; }
        public float HeatGainPerWrongElement { get => heatGainPerWrongElement; set => heatGainPerWrongElement = value; }
        public float OverHeatTick { get => overHeatTick; set => overHeatTick = value; }
        public float CoolDownTick { get => coolDownTick; set => coolDownTick = value; }
        public float MaxHeat { get => maxHeat; set => maxHeat = value; }
        public float ElementSpawnTimer { get => elementSpawnTimer; set => elementSpawnTimer = value; }
        public Vector2 FireSpawnerTimer { get => fireSpawnerTimer; set => fireSpawnerTimer = value; }
        public float ClawSpeed { get => clawsPeed; set => clawsPeed = value; }
        public float DamagePerElementExplosion { get => damagePerElementExplosion; set => damagePerElementExplosion = value; }
        public float DamagePerElementFall { get => damagePerElementFall; set => damagePerElementFall = value; }
        public float DamagePerOverheatTick { get => damagePerOverheatTick; set => damagePerOverheatTick = value; }
        public float DamagePerWrongElement { get => damagePerWrongElement; set => damagePerWrongElement = value; }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        #endregion
    }
}
