﻿using System.Collections.Generic;
using Engine;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelection
{
    #region Data

    public class MaxNumberOfSelectedSkills
    {
        public int ActiveSkill { get; set; }
        public int PassiveSkill { get; set; }

        public MaxNumberOfSelectedSkills()
        {
            ActiveSkill = 4;
            PassiveSkill = 2;
        }
        public MaxNumberOfSelectedSkills(int activeSkill, int passiveSkill)
        {
            ActiveSkill = activeSkill;
            PassiveSkill = passiveSkill;
        }
    }

    public enum Skills
    {
        One,
        Two,
        Three,
        Four
    }

    #region Lists

    public List<ActiveSkill> ActiveSkills { get; set; }

    public List<Sprite> NormalImages { get; set; }
    public List<Sprite> ClickedImages { get; set; }


    #endregion

    public MaxNumberOfSelectedSkills MaxSelectedSkills { get; set; }
    public int CurrentNumberOfSelectedSkills { get; set; }

    public bool SkillOneIsClicked = false;
    public bool SkillTwoIsClicked = false;
    public bool SkillThreeIsClicked = false;
    public bool SkillFourIsClicked = false;

    #endregion

    #region Constructor

    public SkillSelection()
    {
        ActiveSkills = new List<ActiveSkill>();

        NormalImages = new List<Sprite>();
        ClickedImages = new List<Sprite>();

        MaxSelectedSkills = new MaxNumberOfSelectedSkills();
        CurrentNumberOfSelectedSkills = 0;
    }

    #endregion

    #region Load Methods

    private void LoadWaterSkills()
    {
        ActiveSkills.Add(new ActiveSkill("Ice Ramp", "Waterbenders can manipulate ice as a means of short transportation",
           0, 0.4, 0, false, false, false, false, 0.1, 0, 0, 0, 0, 0));
        ActiveSkills.Add(new ActiveSkill("Ice floor",
            "a waterbender can cover a large area of the ground with ice, trapping their enemies' feet in ice", 10, 20,
            7, false, false, false, false, 2, 0, 2.5, 0, 0, 1));
        ActiveSkills.Add(new ActiveSkill("Water bullets",
            "The waterbullet is a move where a waterbender bends a large amount and shoots in a forcefull blow", 1.5, 0,
            0.3, false, false, true, false, 1.9, 0, 9, 0, 12, 5));
        ActiveSkills.Add(new ActiveSkill("Water Shield",
            "Capable waterbenders are able to sustain a large amount of attacks by creating a bubble around themselves and their fellow travelers",
            0, 10, 0, false, false, false, false, 10, 0, 0, 0, 0, 0));
    }
    private void LoadEarthSkills()
    {
        ActiveSkills.Add(new ActiveSkill("Rock Shoes", "Rock shoes makes the earthbender more stable and therefore stronger", 0, 25, 0, false, false, false, false, 6, 0, 0, 0, 0, 0));
        ActiveSkills.Add(new ActiveSkill("Earthquake",
            "Creates localized earthquakes or fissures to throw opponents off-balance", 7, 20, 1, false, false, true,
            false, 1.9, 0, 15, 0, 30, 1));
        ActiveSkills.Add(new ActiveSkill("Earthblock",
            "Earthbenders can bring up blocks of earth and launch them at their enemies", 5, 0, 0.7, false, false, true,
            false, 2, 0, 10, 0, 9, 1));
        ActiveSkills.Add(new ActiveSkill("Earth Bomb",
            "By sending a rock toward the ground, earthbenders can cause massive damage as well as throw their opponents off their feet",
            30, 20, 3, false, false, false, false, 18, 0, 10, 0, 6, 1));
    }
    private void LoadFireSkills()
    {
        ActiveSkills.Add(new ActiveSkill("Firestream",
              "Basic firebending ability, firebenders can shoot continues streams of fire from there fingertips, fists, palms or legs",
              0.1, 0, 0.5, false, false, false, false, 0.025, 0, 4, 0, 15, 1));
        ActiveSkills.Add(new ActiveSkill("Blazing ring",
            "Spinning kicks or sweeping arm movements create rings and arcs to slice larger, more widely spaced, or evasive targets",
            16, 20, 8, false, false, false, false, 4, 0, 0, 0, 0, 0));
        ActiveSkills.Add(new ActiveSkill("Shield Of Fire",
            "This creates a protective fire shield around the front of, or the whole body of, a firebender that can deflect attacks and explosions",
            0, 15, 0, false, false, false, false, 10, 0, 0, 0, 0, 0));
        ActiveSkills.Add(new ActiveSkill("Jet Propulsion",
            "Skilled firebending masters are able to conjure huge amounts of flame to propel themselves at high speeds on the ground or through the air",
            0, 4, 0, false, false, false, false, 0, 0, 0, 0, 0, 0));
    }
    private void LoadAirSkills()
    {
        ActiveSkills.Add(new ActiveSkill("Airblast",
                   "A more offensive manouver involving a direct pulse of strong wind from the hand, feet or mouth", 3.5, 0, 1,
                   false, false, true, false, 1.8, 0, 5, 0, 20, 1));
        ActiveSkills.Add(new ActiveSkill("Air vortex",
            "A spinning funnel of air of varying size, the air vortex can be used to trap or disorient opponents", 2, 20,
            2, false, false, false, false, 5, 0, 15, 0, 0, 1));
        ActiveSkills.Add(new ActiveSkill("Enhanced Speed",
            "When used by a skilled airbender, this technique can enable the airbender using it to travel at a speed almost too swift for the naked eye to be able to see properly. A master airbender can use this technique to briefly run across water",
            0, 10, 0, false, false, false, false, 4, 0, 4.5, 0, 0, 0));
        ActiveSkills.Add(new ActiveSkill("Strong Wind", "Advanced air bending ability", 18, 22, 1, false, false, false,
            false, 20, 0, 8, 0, 20, 1));
    }

    private void LoadWaterImages()
    {
        var textures = new List<Sprite>
        {
            Resources.Load<Sprite>("LobbyMaterials/Icons/Water/SpellIceRamp"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Water/SpellIcefloor"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Water/SpellWaterbullets"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Water/SpellWaterShield")
        };

        NormalImages.AddRange(textures);

        textures = new List<Sprite>
        {
            Resources.Load<Sprite>("LobbyMaterials/Icons/Water/SpellIceRamp_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Water/SpellIcefloor_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Water/SpellWaterbullets_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Water/SpellWaterShield_Clicked")
        };

        ClickedImages.AddRange(textures);
    }

    private void LoadEarthImages()
    {
        var textures = new List<Sprite>
        {
            Resources.Load<Sprite>("LobbyMaterials/Icons/Earth/SpellRockShoes"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Earth/SpellEarthblock"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Earth/SpellEarthquake"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Earth/SpellEarthbomb")
        };

        NormalImages.AddRange(textures);

        textures = new List<Sprite>
        {
            Resources.Load<Sprite>("LobbyMaterials/Icons/Earth/SpellRockShoes_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Earth/SpellEarthblock_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Earth/SpellEarthquake_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Earth/SpellEarthbomb_Clicked")
        };

        ClickedImages.AddRange(textures);
    }

    private void LoadFireImages()
    {
        var textures = new List<Sprite>
        {
            Resources.Load<Sprite>("LobbyMaterials/Icons/Fire/SpellFirestream"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Fire/SpellBlazingring"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Fire/SpellShieldoffire"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Fire/SpellJetpropulsion")
        };

        NormalImages.AddRange(textures);

        textures = new List<Sprite>
        {
            Resources.Load<Sprite>("LobbyMaterials/Icons/Fire/SpellFirestream_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Fire/SpellBlazingring_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Fire/SpellShieldoffire_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Fire/SpellJetpropulsion_Clicked")
        };

        ClickedImages.AddRange(textures);
    }

    private void LoadAirImages()
    {
        var textures = new List<Sprite>
        {
            Resources.Load<Sprite>("LobbyMaterials/Icons/Air/SpellAirblast"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Air/SpellAirvortex"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Air/SpellEnhancedspeed"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Air/SpellStrongwind")
        };

        NormalImages.AddRange(textures);

        textures = new List<Sprite>
        {
            Resources.Load<Sprite>("LobbyMaterials/Icons/Air/SpellAirblast_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Air/SpellAirvortex_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Air/SpellEnhancedspeed_Clicked"),
            Resources.Load<Sprite>("LobbyMaterials/Icons/Air/SpellStrongwind_Clicked")
        };

        ClickedImages.AddRange(textures);
    }

    #endregion

    #region Display Methods

    public void DisplayWaterSkillImages(List<Image> activeSkills)
    {
        for (var i = 0; i < activeSkills.Count; i++)
        {
            activeSkills[i].sprite = NormalImages[i];
        }
    }

    public void DisplayEarthSkillImages(List<Image> activeSkills)
    {
        for (var i = 0; i < activeSkills.Count; i++)
        {
            activeSkills[i].sprite = NormalImages[i];
        }
    }

    public void DisplayFireSkillImages(List<Image> activeSkills)
    {
        for (var i = 0; i < activeSkills.Count; i++)
        {
            activeSkills[i].sprite = NormalImages[i];
        }
    }

    public void DisplayAirSkillImages(List<Image> activeSkills)
    {
        for (var i = 0; i < activeSkills.Count; i++)
        {
            activeSkills[i].sprite = NormalImages[i];
        }
    }

    #endregion

    public bool SelectActiveSkill(Skills skill)
    {
        if (CurrentNumberOfSelectedSkills >= MaxSelectedSkills.ActiveSkill)
        {
            return false;
        }

        CurrentNumberOfSelectedSkills++;
        return true;
    }

    public void SelectActiveSkill(Skills skill, Image activeSkill)
    {
        var skillNumber = (int)skill;
        activeSkill.sprite = ClickedImages[skillNumber];
    }

    public void DeselectActiveSkill(Skills skill, Image activeSkill)
    {
        var skillNumber = (int)skill;
        activeSkill.sprite = NormalImages[skillNumber];
    }

    public void PrepareWaterSkills()
    {
        ActiveSkills.Clear();
        NormalImages.Clear();
        ClickedImages.Clear();

        LoadWaterSkills();
        LoadWaterImages();
    }
    public void PrepareEarthSkills()
    {
        ActiveSkills.Clear();
        NormalImages.Clear();
        ClickedImages.Clear();

        LoadEarthSkills();
        LoadEarthImages();
    }
    public void PrepareFireSkills()
    {
        ActiveSkills.Clear();
        NormalImages.Clear();
        ClickedImages.Clear();

        LoadFireSkills();
        LoadFireImages();
    }
    public void PrepareAirSkills()
    {
        ActiveSkills.Clear();
        NormalImages.Clear();
        ClickedImages.Clear();

        LoadAirSkills();
        LoadAirImages();
    }
}
