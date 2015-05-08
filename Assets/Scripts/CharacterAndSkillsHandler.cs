﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAndSkillsHandler : MonoBehaviour
{
    public Text NameText;
    public Text InfoText;
    public Text AttributesText;

    public List<Image> Characters = new List<Image>();
    public List<Image> ActiveSkills = new List<Image>();
    public List<Image> PassiveSkills = new List<Image>();

    private CharacterSelection _characterSelection = new CharacterSelection();
    private SkillSelection _skillSelection = new SkillSelection();

    public void Start()
    {
        _characterSelection.LoadImages();
        ResetCharacterSelection();
    }

    private void ResetCharacterSelection()
    {
        NameText.text = InfoText.text = AttributesText.text = String.Empty;
        for (var i = 0; i < Characters.Count; i++)
        {
            Characters[i].sprite = _characterSelection.NormalSprites[i];
        }

        foreach (var activeSkill in ActiveSkills)
        {
            activeSkill.enabled = false;
        }

        _skillSelection.CurrentNumberOfSelectedSkills = 0;

        _skillSelection.SkillOneIsClicked = _skillSelection.SkillTwoIsClicked =
            _skillSelection.SkillThreeIsClicked = _skillSelection.SkillFourIsClicked = false;
    }

    private void ResetSkillSelection()
    {
        NameText.text = InfoText.text = AttributesText.text = String.Empty;

        _skillSelection.CurrentNumberOfSelectedSkills = 0;
    }

    private void EnableActiveImages()
    {
        foreach (var activeSkill in ActiveSkills)
        {
            activeSkill.enabled = true;
        }
    }

    #region Character Mouse Clicks

    public void HandleWaterMouseClick()
    {
        ResetCharacterSelection();

        if (_characterSelection.ToggleWaterCharacter())
        {
            Characters[_characterSelection.WaterbendingId].sprite =
                _characterSelection.NormalSprites[_characterSelection.WaterbendingId];
        }
        else
        {
            Characters[_characterSelection.WaterbendingId].sprite =
                _characterSelection.ClickedSprites[_characterSelection.WaterbendingId];
            InfoText.text = "Water description goes here";
            DisplaySkillImages();
        }
    }

    public void HandleEarthMouseClick()
    {
        ResetCharacterSelection();

        if (_characterSelection.ToggleEarthCharacter())
        {
            Characters[_characterSelection.EarthbendingId].sprite =
                _characterSelection.NormalSprites[_characterSelection.EarthbendingId];
        }
        else
        {
            Characters[_characterSelection.EarthbendingId].sprite =
                _characterSelection.ClickedSprites[_characterSelection.EarthbendingId];
            InfoText.text = "Earth description goes here";
            DisplaySkillImages();
        }
    }

    public void HandleFireMouseClick()
    {
        ResetCharacterSelection();

        if (_characterSelection.ToggleFireCharacter())
        {
            Characters[_characterSelection.FirebendingId].sprite =
                _characterSelection.NormalSprites[_characterSelection.FirebendingId];
        }
        else
        {
            Characters[_characterSelection.FirebendingId].sprite =
                _characterSelection.ClickedSprites[_characterSelection.FirebendingId];
            InfoText.text = "Fire description goes here";
            DisplaySkillImages();
        }
    }

    public void HandleAirMouseClick()
    {
        ResetCharacterSelection();

        if (_characterSelection.ToggleAirCharacter())
        {
            Characters[_characterSelection.AirbendingId].sprite =
                _characterSelection.NormalSprites[_characterSelection.AirbendingId];
        }
        else
        {
            Characters[_characterSelection.AirbendingId].sprite =
                _characterSelection.ClickedSprites[_characterSelection.AirbendingId];
            InfoText.text = "Air description goes here";
            DisplaySkillImages();
        }
    }

    #endregion

    private void DisplaySkillImages()
    {
        EnableActiveImages();

        switch (_characterSelection.CurrentCharacter)
        {
            case CharacterSelection.Characters.Waterbending:
                _skillSelection.PrepareWaterSkills();
                _skillSelection.DisplayWaterSkillImages(ActiveSkills);
                break;
            case CharacterSelection.Characters.Earthbending:
                _skillSelection.PrepareEarthSkills();
                _skillSelection.DisplayEarthSkillImages(ActiveSkills);
                break;
            case CharacterSelection.Characters.Firebending:
                _skillSelection.PrepareFireSkills();
                _skillSelection.DisplayFireSkillImages(ActiveSkills);
                break;
            case CharacterSelection.Characters.Airbending:
                _skillSelection.PrepareAirSkills();
                _skillSelection.DisplayAirSkillImages(ActiveSkills);
                break;
        }
    }

    public void HandleConfirmClick()
    {
        //TODO
    }

    #region Active Skill Mouse Clicks

    public void HandleActiveSkillOneClick()
    {
        if (!_skillSelection.SkillOneIsClicked && _skillSelection.SelectActiveSkill(SkillSelection.Skills.One))
        {
            _skillSelection.SkillOneIsClicked = true;
            DisplaySkillInformation(SkillSelection.Skills.One);
        }
        else
        {
            _skillSelection.SkillOneIsClicked = false;
            _skillSelection.CurrentNumberOfSelectedSkills--;

            ResetSkillSelection();

            const int skillNumber = (int)SkillSelection.Skills.One;
            _skillSelection.DeselectActiveSkill(SkillSelection.Skills.One, ActiveSkills[skillNumber]);
        }
    }

    public void HandleActiveSkillTwoClick()
    {
        if (!_skillSelection.SkillTwoIsClicked && _skillSelection.SelectActiveSkill(SkillSelection.Skills.Two))
        {
            _skillSelection.SkillTwoIsClicked = true;
            DisplaySkillInformation(SkillSelection.Skills.Two);
        }
        else
        {
            _skillSelection.SkillTwoIsClicked = false;
            _skillSelection.CurrentNumberOfSelectedSkills--;

            ResetSkillSelection();

            const int skillNumber = (int)SkillSelection.Skills.Two;
            _skillSelection.DeselectActiveSkill(SkillSelection.Skills.Two, ActiveSkills[skillNumber]);
        }
    }

    public void HandleActiveSkillThreeClick()
    {
        if (!_skillSelection.SkillThreeIsClicked && _skillSelection.SelectActiveSkill(SkillSelection.Skills.Three))
        {
            _skillSelection.SkillThreeIsClicked = true;
            DisplaySkillInformation(SkillSelection.Skills.Three);
        }
        else
        {
            _skillSelection.SkillThreeIsClicked = false;
            _skillSelection.CurrentNumberOfSelectedSkills--;

            ResetSkillSelection();

            const int skillNumber = (int)SkillSelection.Skills.Three;
            _skillSelection.DeselectActiveSkill(SkillSelection.Skills.Three, ActiveSkills[skillNumber]);
        }
    }

    public void HandleActiveSkillFourClick()
    {
        if (!_skillSelection.SkillFourIsClicked && _skillSelection.SelectActiveSkill(SkillSelection.Skills.Four))
        {
            _skillSelection.SkillFourIsClicked = true;
            DisplaySkillInformation(SkillSelection.Skills.Four);
        }
        else
        {
            _skillSelection.SkillFourIsClicked = false;
            _skillSelection.CurrentNumberOfSelectedSkills--;

            ResetSkillSelection();

            const int skillNumber = (int)SkillSelection.Skills.Four;
            _skillSelection.DeselectActiveSkill(SkillSelection.Skills.Four, ActiveSkills[skillNumber]);
        }
    }

    #endregion

    private void DisplaySkillInformation(SkillSelection.Skills skill)
    {
        switch (_characterSelection.CurrentCharacter)
        {
            case CharacterSelection.Characters.Waterbending:
                _skillSelection.PrepareWaterSkills();
                break;
            case CharacterSelection.Characters.Earthbending:
                _skillSelection.PrepareEarthSkills();
                break;
            case CharacterSelection.Characters.Firebending:
                _skillSelection.PrepareFireSkills();
                break;
            case CharacterSelection.Characters.Airbending:
                _skillSelection.PrepareAirSkills();
                break;
        }

        var skillNumber = (int)skill;

        _skillSelection.SelectActiveSkill(skill, ActiveSkills[skillNumber]);

        NameText.text = _skillSelection.ActiveSkills[skillNumber].Name;
        InfoText.text = _skillSelection.ActiveSkills[skillNumber].Info;

        var attributeText = "Damage: " + _skillSelection.ActiveSkills[skillNumber].DamageHealingPower
                            + "\nChi Cost: " + _skillSelection.ActiveSkills[skillNumber].ChiCost
                            + "\nCooldown: " + _skillSelection.ActiveSkills[skillNumber].Cooldown
                            + "\nRange: " + _skillSelection.ActiveSkills[skillNumber].Range;

        AttributesText.text = attributeText;
    }
}
