using BepInEx.Configuration;
using BastionMod.Modules;
using BastionMod.Modules.Characters;
using BastionMod.Survivors.Bastion.SkillStates;
using RoR2;
using RoR2.Skills;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BastionMod.Survivors.Bastion
{
    public class BastionSurvivor : SurvivorBase<BastionSurvivor>
    {
        public enum BodyAnimatorLayer
        {
            Assault = 1,
            Artillery = 2,
            Bombard = 3,
            Pitch = 7,
            Yaw = 8,
        }

        public override string assetBundleName => "bastionbundle";

        public override string bodyName => "BastionRobot";

        public override string masterName => "BastionMonsterMaster";

        public override string modelPrefabName => "mdlBastion";
        public override string displayPrefabName => "displayBastion";

        public const string Bastion_PREFIX = BastionPlugin.DEVELOPER_PREFIX + "_BASTION_";

        public override string survivorTokenPrefix => Bastion_PREFIX;
        
        public override BodyInfo bodyInfo => new BodyInfo
        {
            bodyName = bodyName,
            bodyNameToken = Bastion_PREFIX + "NAME",
            subtitleNameToken = Bastion_PREFIX + "SUBTITLE",

            characterPortrait = assetBundle.LoadAsset<Texture>("texBastionIcon"),
            bodyColor = Color.white,
            sortPosition = 100,

            crosshair = Asset.LoadCrosshair("Standard"),
            podPrefab = LegacyResourcesAPI.Load<GameObject>("Prefabs/NetworkedObjects/SurvivorPod"),

            maxHealth = 200f,
            healthRegen = 1.5f,
            armor = 5f,

            jumpCount = 1,
            moveSpeed = 8,

            attackSpeed = 1,
        };

        public override CustomRendererInfo[] customRendererInfos => new CustomRendererInfo[]
        {
                new CustomRendererInfo
                {
                    childName = "body",
                    material = assetBundle.LoadMaterial("matBastion"),
                },
                new CustomRendererInfo
                {
                    childName = "healRing",
                    material = assetBundle.LoadMaterial("matBastionHeal"),
                }
        };

        public override UnlockableDef characterUnlockableDef => BastionUnlockables.characterUnlockableDef;
        
        public override ItemDisplaysBase itemDisplays => new BastionItemDisplays();

        //set in base classes
        public override AssetBundle assetBundle { get; protected set; }

        public override GameObject bodyPrefab { get; protected set; }
        public override CharacterBody prefabCharacterBody { get; protected set; }
        public override GameObject characterModelObject { get; protected set; }
        public override CharacterModel prefabCharacterModel { get; protected set; }
        public override GameObject displayPrefab { get; protected set; }

        public override void Initialize()
        {
            //uncomment if you have multiple characters
            //ConfigEntry<bool> characterEnabled = Config.CharacterEnableConfig("Survivors", "Bastion");

            //if (!characterEnabled.Value)
            //    return;

            base.Initialize();
        }

        public override void InitializeCharacter()
        {
            //need the character unlockable before you initialize the survivordef
            BastionUnlockables.Init();

            base.InitializeCharacter();

            BastionConfig.Init();
            BastionStates.Init();
            BastionTokens.Init();

            BastionAssets.Init(assetBundle);
            BastionBuffs.Init(assetBundle);

            InitializeEntityStateMachines();
            InitializeSkills();
            InitializeSkins();
            InitializeCharacterMaster();

            AddHooks();
        }

        public override void InitializeEntityStateMachines() 
        {
            Prefabs.ClearEntityStateMachines(bodyPrefab);

            Prefabs.AddMainEntityStateMachine(bodyPrefab, "Body", typeof(EntityStates.GenericCharacterMain), typeof(EntityStates.SpawnTeleporterState));

            Prefabs.AddEntityStateMachine(bodyPrefab, "Bastion");
        }

        #region skills
        public override void InitializeSkills()
        {
            Skills.ClearGenericSkills(bodyPrefab);

            AddPrimarySkills();
            AddSecondarySkills();
            AddUtiitySkills();
            AddSpecialSkills();
        }

        private void AddPrimarySkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Primary);

            SteppedSkillDef primarySkillDef = Skills.CreateSkillDef<SteppedSkillDef>(new SkillDefInfo
            {
                skillName = "BastionReconPrimary",
                skillNameToken = Bastion_PREFIX + "PRIMARY_RECON_NAME",
                skillDescriptionToken = Bastion_PREFIX + "PRIMARY_RECON_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("Primary"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(Primary)),
                activationStateMachineName = "Bastion",
                interruptPriority = EntityStates.InterruptPriority.Skill,

                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = false,
                requiredStock = 0,
                stockToConsume = 0

            });

            SteppedSkillDef assaultPrimaryDef = Skills.CreateSkillDef<SteppedSkillDef>(new SkillDefInfo
            {
                skillName = "BastionReconPrimary",
                skillNameToken = Bastion_PREFIX + "PRIMARY_ASSAULT_NAME",
                skillDescriptionToken = Bastion_PREFIX + "PRIMARY_ASSAULT_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("Assault Primary"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(AssaultPrimary)),
                activationStateMachineName = "Bastion",
                interruptPriority = EntityStates.InterruptPriority.Skill,

                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = false,
            });
            
            SteppedSkillDef artilleryPrimaryDef = Skills.CreateSkillDef<SteppedSkillDef>(new SkillDefInfo
            {
                skillName = "BastionReconPrimary",
                skillNameToken = Bastion_PREFIX + "PRIMARY_ASSAULT_NAME",
                skillDescriptionToken = Bastion_PREFIX + "PRIMARY_ASSAULT_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("ArtilleryFire"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(ArtilleryPrimary)),
                activationStateMachineName = "Bastion",
                interruptPriority = EntityStates.InterruptPriority.Skill,

                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = false,
            });

            BastionStaticValues.assaultPrimary = assaultPrimaryDef;
            BastionStaticValues.artilleryPrimary = artilleryPrimaryDef;

            Skills.AddPrimarySkills(bodyPrefab, primarySkillDef);
        }

        private void AddSecondarySkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Secondary);

            SkillDef secondarySkillDef1 = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "BastionKick",
                skillNameToken = Bastion_PREFIX + "SECONDARY_HEAL_NAME",
                skillDescriptionToken = Bastion_PREFIX + "SECONDARY_HEAL_DESCRIPTION",
                keywordTokens = new string[] { "" },
                skillIcon = assetBundle.LoadAsset<Sprite>("heal"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.HealSelf)),
                activationStateMachineName = "Bastion",
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,

                baseRechargeInterval = 0f,
                baseMaxStock = 1,

                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = false,
                beginSkillCooldownOnSkillEnd = false,

                isCombatSkill = false,
                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = false,
            });

            Skills.AddSecondarySkills(bodyPrefab, secondarySkillDef1);
        }

        private void AddUtiitySkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Utility);

            SkillDef reconToAssaultDef = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "BastionAssaultMode",
                skillNameToken = Bastion_PREFIX + "UTILITY_ASSAULT_NAME",
                skillDescriptionToken = Bastion_PREFIX + "UTILITY_ASSAULT_DESCRIPTION",
                keywordTokens = new string[] { "KEYWORD_AGILE" },
                skillIcon = assetBundle.LoadAsset<Sprite>("utility"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.ReconToAssault)),
                activationStateMachineName = "Bastion",
                interruptPriority = EntityStates.InterruptPriority.Pain,

                baseRechargeInterval = 10f,
                baseMaxStock = 1,

                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = false,
                beginSkillCooldownOnSkillEnd = false,

                isCombatSkill = true,
                canceledFromSprinting = true,
                cancelSprintingOnActivation = true,
                forceSprintDuringState = false,
            });

            SkillDef assaultToReconDef = Skills.CreateSkillDef<SkillDef>(new SkillDefInfo
            (
                "BastionReconPrimary",
                Bastion_PREFIX + "UTILITY_ASSAULTTORECON_NAME",
                Bastion_PREFIX + "UTILITY_ASSAULTTORECON_DESCRIPTION",
                assetBundle.LoadAsset<Sprite>("assault utitlity"),
                new EntityStates.SerializableEntityStateType(typeof(AssaultToRecon)),
                "Bastion",
                true
            ));
            
            SkillDef artilleryToAssaultDef = Skills.CreateSkillDef<SkillDef>(new SkillDefInfo
            (
                "BastionReconPrimary",
                Bastion_PREFIX + "UTILITY_ASSAULTTORECON_NAME",
                Bastion_PREFIX + "UTILITY_ASSAULTTORECON_DESCRIPTION",
                assetBundle.LoadAsset<Sprite>("aa"),
                new EntityStates.SerializableEntityStateType(typeof(ArtilleryToAssault)),
                "Bastion",
                true
            ));

            BastionStaticValues.assaultToRecon = assaultToReconDef;

            BastionStaticValues.artilleryToAssault = artilleryToAssaultDef;

            Skills.AddUtilitySkills(bodyPrefab, reconToAssaultDef);
        }

        private void AddSpecialSkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Special);

            SkillDef specialSkillDef1 = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "BastionHeavy",
                skillNameToken = Bastion_PREFIX + "SPECIAL_ARTILLERY_NAME",
                skillDescriptionToken = Bastion_PREFIX + "SPECIAL_ARTILLERY_DESCRIPTION",
                keywordTokens = new string[] { "KEYWORD_STUNNING" },
                skillIcon = assetBundle.LoadAsset<Sprite>("Special"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(ReconToArtillery)),
                activationStateMachineName = "Bastion",
                interruptPriority = EntityStates.InterruptPriority.Pain,

                baseRechargeInterval = 20f,
                baseMaxStock = 1,

                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = false,
                beginSkillCooldownOnSkillEnd = false,

                isCombatSkill = true,
                canceledFromSprinting = true,
                cancelSprintingOnActivation = true,
                forceSprintDuringState = false,
            });

            SkillDef artilleryToReconDef = Skills.CreateSkillDef<SkillDef>(new SkillDefInfo
            (
                "BastionReconPrimary",
                Bastion_PREFIX + "UTILITY_ASSAULTTORECON_NAME",
                Bastion_PREFIX + "UTILITY_ASSAULTTORECON_DESCRIPTION",
                assetBundle.LoadAsset<Sprite>("ArtilleryUnset"),
                new EntityStates.SerializableEntityStateType(typeof(ArtilleryToRecon)),
                "Bastion",
                true
            ));
            
            SkillDef assaultToArtilleryDef = Skills.CreateSkillDef<SkillDef>(new SkillDefInfo
            (
                "BastionReconPrimary",
                Bastion_PREFIX + "UTILITY_ASSAULTTORECON_NAME",
                Bastion_PREFIX + "UTILITY_ASSAULTTORECON_DESCRIPTION",
                assetBundle.LoadAsset<Sprite>("Assault to Artillery"),
                new EntityStates.SerializableEntityStateType(typeof(AssaultToArtillery)),
                "Bastion",
                true
            ));

            BastionStaticValues.artilleryToRecon = artilleryToReconDef;
            BastionStaticValues.assaultToArtillery = assaultToArtilleryDef;

            Skills.AddSpecialSkills(bodyPrefab, specialSkillDef1);
        }
        #endregion skills
        
        #region skins
        public override void InitializeSkins()
        {
            ModelSkinController skinController = prefabCharacterModel.gameObject.AddComponent<ModelSkinController>();
            ChildLocator childLocator = prefabCharacterModel.GetComponent<ChildLocator>();

            CharacterModel.RendererInfo[] defaultRendererinfos = prefabCharacterModel.baseRendererInfos;

            List<SkinDef> skins = new List<SkinDef>();

            #region DefaultSkin
            //this creates a SkinDef with all default fields
            SkinDef defaultSkin = Skins.CreateSkinDef("DEFAULT_SKIN",
                assetBundle.LoadAsset<Sprite>("texMainSkin"),
                defaultRendererinfos,
                prefabCharacterModel.gameObject);

            //these are your Mesh Replacements. The order here is based on your CustomRendererInfos from earlier
                //pass in meshes as they are named in your assetbundle
            //currently not needed as with only 1 skin they will simply take the default meshes
                //uncomment this when you have another skin
            //defaultSkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos,
            //    "meshBastionSword",
            //    "meshBastionGun",
            //    "meshBastion");

            //add new skindef to our list of skindefs. this is what we'll be passing to the SkinController
            skins.Add(defaultSkin);
            #endregion

            //uncomment this when you have a mastery skin
            #region MasterySkin
            
            ////creating a new skindef as we did before
            //SkinDef masterySkin = Modules.Skins.CreateSkinDef(Bastion_PREFIX + "MASTERY_SKIN_NAME",
            //    assetBundle.LoadAsset<Sprite>("texMasteryAchievement"),
            //    defaultRendererinfos,
            //    prefabCharacterModel.gameObject,
            //    BastionUnlockables.masterySkinUnlockableDef);

            ////adding the mesh replacements as above. 
            ////if you don't want to replace the mesh (for example, you only want to replace the material), pass in null so the order is preserved
            //masterySkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos,
            //    "meshBastionSwordAlt",
            //    null,//no gun mesh replacement. use same gun mesh
            //    "meshBastionAlt");

            ////masterySkin has a new set of RendererInfos (based on default rendererinfos)
            ////you can simply access the RendererInfos' materials and set them to the new materials for your skin.
            //masterySkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("matBastionAlt");
            //masterySkin.rendererInfos[1].defaultMaterial = assetBundle.LoadMaterial("matBastionAlt");
            //masterySkin.rendererInfos[2].defaultMaterial = assetBundle.LoadMaterial("matBastionAlt");

            ////here's a barebones example of using gameobjectactivations that could probably be streamlined or rewritten entirely, truthfully, but it works
            //masterySkin.gameObjectActivations = new SkinDef.GameObjectActivation[]
            //{
            //    new SkinDef.GameObjectActivation
            //    {
            //        gameObject = childLocator.FindChildGameObject("GunModel"),
            //        shouldActivate = false,
            //    }
            //};
            ////simply find an object on your child locator you want to activate/deactivate and set if you want to activate/deacitvate it with this skin

            //skins.Add(masterySkin);
            
            #endregion

            skinController.skins = skins.ToArray();
        }
        #endregion skins

        public override void InitializeCharacterMaster()
        {
            BastionAI.Init(bodyPrefab, masterName);
        }

        private void AddHooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, R2API.RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender.HasBuff(BastionBuffs.turretArmorBuff))
            {
                args.armorAdd += 150f;
            }
        }
    }
}