using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class CVComparisonAndListener : MonoBehaviour, IPointerClickHandler
{
    // Define the correct CV values as per your input
    private string requiredSkills = "Kielitaito: Suomi, Englanti";
    private string requiredExperience = "Työkokemus: Rakennusalantyöt, erilaiset keikkatyöt ja nuorena kesätyöt.";
    private string requiredEducation = "Koulutus: Ammattikorkeakoulu";
    private string requiredCard = "Työkortit: Työturvallisuuskortti, ajokortti";

    // Reference to the TextMeshPro component (the clicked text object)
    private TMP_Text textObject;

    // This method is called when the script starts
    void Start()
    {
        textObject = GetComponent<TMP_Text>();

        if (textObject == null)
        {
            Debug.LogError("CVComparisonAndListener needs to be attached to a TMP_Text component.");
            return;
        }

        InitializeValues();
    }

    private void InitializeValues()
    {
        if (textObject != null)
        {
            if (textObject.name == "SkillsText")
            {
                textObject.text = requiredSkills;
            }
            else if (textObject.name == "ExperienceText")
            {
                textObject.text = requiredExperience;
            }
            else if (textObject.name == "EducationText")
            {
                textObject.text = requiredEducation;
            }
            else if (textObject.name == "CardText")
            {
                textObject.text = requiredCard;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (textObject.color == Color.green || textObject.color == Color.red)
        {
            textObject.color = Color.white;  // Reset to normal
            Debug.Log(textObject.name + " color reset to normal.");
        }
        else
        {
            if (textObject.name == "SkillsText" && textObject.text == requiredSkills)
            {
                CheckCV(textObject, requiredSkills);
            }
            else if (textObject.name == "ExperienceText" && textObject.text == requiredExperience)
            {
                CheckCV(textObject, requiredExperience);
            }
            else if (textObject.name == "EducationText" && textObject.text == requiredEducation)
            {
                CheckCV(textObject, requiredEducation);
            }
            else if (textObject.name == "CardText" && textObject.text == requiredCard)
            {
                CheckCV(textObject, requiredCard);
            }
            else
            {
                CheckCV(textObject, "Incorrect");
            }
        }
    }

    private void CheckCV(TMP_Text textObject, string requiredValue)
    {
        if (textObject.text == requiredValue)
        {
            textObject.color = Color.green;
            Debug.Log(textObject.name + " is correct!");
        }
        else
        {
            textObject.color = Color.red;
            Debug.Log(textObject.name + " is incorrect!");
        }
    }
}
