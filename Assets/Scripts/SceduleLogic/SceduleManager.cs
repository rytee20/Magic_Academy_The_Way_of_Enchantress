using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceduleManager : MonoBehaviour
{
    public static SceduleManager Instance { get; private set; }

    private Player player;

    public event Action OnScheduleComplete;
    private int completedCycles = 0;

    private SubjectFactory strategyFactory;
    private ILearningStrategy spellcasting;
    private ILearningStrategy alchemy;
    private ILearningStrategy divination;

    private bool isSlotsHide;
    private bool isSpellcastingDecorated = false;
    private bool isAlchemyDecorated = false;
    private bool isDivinationDecorated = false;

    public TMP_Text points;

    private bool isScheduleStarted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartScedule()
    {
        InitializeComponents();
        isScheduleStarted = true;
    }

    private void Update()
    {
        if(!isScheduleStarted)
            return;
        points.text = "Энергия: 100/" + player.GetEnergyPoints().ToString() + "\n" + player.GetAllStudyPoints() + "\n" + player.GetAllRelationsPoints() + "\nХод: " + completedCycles.ToString();
        CheckEnergy();
        CheckStudyPoints();
    }

    public void CompleteSchedule()
    {

        completedCycles++;
        Debug.Log(completedCycles);
        OnScheduleComplete?.Invoke();
    }

    public int GetCompletedCycles()
    {
        return completedCycles;
    }

    private void InitializeComponents()
    {
        //SetPlayer(new Player());

        strategyFactory = new SubjectFactory();

        spellcasting = strategyFactory.CreateSubject(SubjectType.Spellcasting);
        alchemy = strategyFactory.CreateSubject(SubjectType.Alchemy);
        divination = strategyFactory.CreateSubject(SubjectType.Divination);

        isSlotsHide = false;
    }

    public ILearningStrategy GetStrategy(int activityIndex)
    {
        switch (activityIndex)
        {
            case 0:
                return spellcasting;
            case 1:
                return alchemy;
            case 2:
                return divination;
            default:
                throw new ArgumentException("Unknown subject type");
        }
    }

    private void CheckEnergy()
    {
        if (player.GetEnergyPoints() < 30 && isSlotsHide!=true)
        {
            Scedule scedule = FindObjectOfType<Scedule>();
            scedule.HideSlots();
            isSlotsHide = true;
        }
        else if (player.GetEnergyPoints() >=30 && isSlotsHide == true)
        {
            Scedule scedule = FindObjectOfType<Scedule>();
            scedule.ReturnSlots();
            isSlotsHide=false;
        }
    }

    private void CheckStudyPoints()
    {
        if (!isSpellcastingDecorated && player.GetStudyPoints(0) > 100)
        {
            spellcasting = new EnhancedLearningStrategy(spellcasting);
            isSpellcastingDecorated = true;
        }
        if (!isAlchemyDecorated && player.GetStudyPoints(1) > 100)
        {
            alchemy = new EnhancedLearningStrategy(alchemy);
            isAlchemyDecorated = true;
        }
        if (!isDivinationDecorated && player.GetStudyPoints(2) > 100)
        {
            divination = new EnhancedLearningStrategy(divination);
            isDivinationDecorated = true;
        }
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void SetPlayer(Player p)
    {
        player = p;
    }
}
