using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Required for the Toggle (Checkbox) component
using UnityEngine.EventSystems;

public class CVComparisonAndListener : MonoBehaviour, IPointerClickHandler
{
    // Define the correct CV values as per your input
    private string requiredSkills = "Kielitaito: Suomi, Englanti";
    private string requiredExperience = "Työkokemus: Rakennusalantyöt, erilaiset keikkatyöt ja nuorena kesätyöt.";
    private string requiredEducation = "Koulutus: Ammattikorkeakoulu";
    private string requiredCard = "Työkortit: Työturvallisuuskortti, ajokortti";
    private string requiredMatkustamisValmius = "MatkustamisValmius";  // New required value for the checkbox

    // Reference to the TextMeshPro component (the clicked text object)
    private TMP_Text textObject;

    // Reference to the Toggle (Checkbox)
    [SerializeField] private Toggle matkustamisToggle;  // Link the checkbox in the Inspector

    // This method is called when the script starts
    void Start()
    {
        // Set the reference to the TextMeshPro component (the text field this script is attached to)
        textObject = GetComponent<TMP_Text>();

        if (textObject == null)
        {
            Debug.LogError("CVComparisonAndListener needs to be attached to a TMP_Text component.");
            return;
        }

        // Check if the toggle is assigned
        if (matkustamisToggle == null)
        {
            Debug.LogError("Matkustamis Toggle is not assigned. Please assign it in the Inspector.");
            return;
        }

        // Initialize the correct values when the scene starts
        InitializeValues();

        // Add a listener to the checkbox to validate when toggled
        matkustamisToggle.onValueChanged.AddListener(OnMatkustamisToggleChanged);
    }

    // This method initializes the required values based on the text object name
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

        // Initialize checkbox state
        matkustamisToggle.isOn = false;  // Default unchecked
    }

    // Handle checkbox state changes
    private void OnMatkustamisToggleChanged(bool isChecked)
    {
        if (isChecked)
        {
            Debug.Log("MatkustamisValmius is correct!");
            matkustamisToggle.graphic.color = Color.green;  // Set to green for correct
        }
        else
        {
            matkustamisToggle.graphic.color = Color.white;  // Reset to default
        }
    }

    // This method is triggered when the text is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if (textObject.color == Color.green || textObject.color == Color.red)
        {
            textObject.color = Color.white;  // Reset to normal (white)
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

    // This method compares the clicked text with the required value and highlights the color
    private void CheckCV(TMP_Text textObject, string requiredValue)
    {
        if (textObject.text == requiredValue)
        {
            textObject.color = Color.green;  // Correct
            Debug.Log(textObject.name + " is correct!");
        }
        else
        {
            textObject.color = Color.red;    // Incorrect
            Debug.Log(textObject.name + " is incorrect!");
        }
    }
}
