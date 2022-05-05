using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game_controller : MonoBehaviour
{
    [SerializeField] private Container container;
    [SerializeField] private float radius_walk_zone;  //скриптабл

    [SerializeField] private int Goose_count;
    [SerializeField] private int Goat_count;
    [SerializeField] private int Ostrich_count;
    [SerializeField] private int Pig_count;
    [SerializeField] private int Cow_count;
    [SerializeField] private int Horse_count;
    [SerializeField] private int Sheep_count;
    [SerializeField] private int Chicken_count;

    [SerializeField] private int feed_Bust_count;
    [SerializeField] private int time_Bust_count;
    public static int gold;  //вынести в сейвы
    private int Day;

     public int Day_length; //   брать из скриптаблобж
    public int startLength;
    public int stepPerAnimal;





    public bool DayIsActive = false;  //поменять на приват

    public float timer;
    private float deadCount;

    public enum State
    {
        InMenu,
        Ingame,
        Finish,
        Result

    }
    public State state;



    private int Goose_died;
    private int Goat_died;
    private int Ostrich_died;
    private int Pig_died;
    private int Cow_died;
    private int Horse_died;
    private int Sheep_died;
    private int Chicken_died;

    void Awake()
    {
        CheckSave();
        state = State.InMenu;
        container.InGame_ui.gameObject.SetActive(false);
        container.Finish_ui.gameObject.SetActive(false);
        container.Result_ui.gameObject.SetActive(false);
        container.Manager_ui.gameObject.SetActive(true);
        container.Ingame_panel.gameObject.SetActive(false);
        container.Manager_panel.gameObject.SetActive(true);
        SpawnAnimals();
        DayLenghCalculating(startLength, stepPerAnimal);
   //     EndDay();
    }
    public void REsetSaves()
    {
        PlayerPrefs.SetInt("Goose_paddock", 0);
        PlayerPrefs.SetInt("Goat_paddock", 0);
        PlayerPrefs.SetInt("Ostrich_paddock", 0);
        PlayerPrefs.SetInt("Pig_paddock", 0);
        PlayerPrefs.SetInt("Cow_paddock", 0);
        PlayerPrefs.SetInt("Horse_paddock", 0);
        PlayerPrefs.SetInt("Sheep_paddock", 0);
        PlayerPrefs.SetInt("Chicken_paddock", 0);
        PlayerPrefs.DeleteAll();

    }
    private void Start()
    {
        DisplayGold();
        DisplayBusters_count();
        DisplayBusters_price();
        DisplayAnimalsCountInManagerPanel();
        DisplayActive_inactive_paddock();
        container.Goose_paddock.EnableColision(false);
        container.Goat_paddock.EnableColision(false);
        container.Ostrich_paddock.EnableColision(false);
        container.Pig_paddock.EnableColision(false);
        container.Cow_paddock.EnableColision(false);
        container.Horse_paddock.EnableColision(false);
        container.Sheep_paddock.EnableColision(false);
        container.Chicken_paddock.EnableColision(false);
    }
    private void Update()
    {
        DayActive();
    }

    private void DisplayAnimalsCountInManagerPanel()
    {
        container.Manager_panel.AnimalsCount(Goose_count, Goat_count, Ostrich_count, Pig_count, Cow_count, Horse_count, Sheep_count, Chicken_count);
    }

    private void CheckSave()
    {
        Goose_count = Save.Goose_count_Get();
        Goat_count = Save.Goat_count_Get();
        Ostrich_count = Save.Ostrich_count_Get();
        Pig_count = Save.Pig_count_Get();
        Cow_count = Save.Cow_count_Get();
        Horse_count = Save.Horse_count_Get();
        Sheep_count = Save.Sheep_count_Get();
        Chicken_count = Save.Chicken_count_Get();

        feed_Bust_count = Save.Feed_bust_count_Get();
        time_Bust_count = Save.Time_bust_count_Get();
        Day = Save.Day_Get();
        gold = Save.Gold_Get();
    }

    private void SaveAll()
    {
        Save.Save_Goose_count(Goose_count);
        Save.Save_Goat_count(Goat_count);
        Save.Save_Ostrich_count(Ostrich_count);
        Save.Save_Pig_count(Pig_count);
        Save.Save_Cow_count(Cow_count);
        Save.Save_Horse_count(Horse_count);
        Save.Save_Sheep_count(Sheep_count);
        Save.Save_Chicken_count(Chicken_count);

        Save.Save_Feed_bust(feed_Bust_count);
        Save.Save_Time_bust(time_Bust_count);
        Save.Save_Day(Day);
        Save.Save_Gold(gold);
        Save.SaveStats();
    }

    private void SpawnAnimals()
    {
        if (Goose_count > 0)
        {
            container.Goose_paddock.isActive = true;
            container.Goose_paddock.SpawnAnimals(container.Goose_prefab, Goose_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 2, 1, container.RandomPoints);
        }
        if (Goat_count > 0)
        {
            container.Goat_paddock.isActive = true;
            container.Goat_paddock.SpawnAnimals(container.Goat_prefab, Goat_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 3, Goose_count + 1, container.RandomPoints);
        }
        if (Ostrich_count > 0)
        {
            container.Ostrich_paddock.isActive = true;
            container.Ostrich_paddock.SpawnAnimals(container.Ostrich_prefab, Ostrich_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 5, Goat_count + 1, container.RandomPoints);
        }
        if (Pig_count > 0)
        {
            container.Pig_paddock.isActive = true;
            container.Pig_paddock.SpawnAnimals(container.pig_prefab, Pig_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 4, Ostrich_count + 1, container.RandomPoints);
        }
        if (Cow_count > 0)
        {
            container.Cow_paddock.isActive = true;
            container.Cow_paddock.SpawnAnimals(container.Cow_prefab, Cow_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 6, Pig_count + 1, container.RandomPoints);
        }
        if (Horse_count > 0)
        {
            container.Horse_paddock.isActive = true;
            container.Horse_paddock.SpawnAnimals(container.horse_prefab, Horse_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 7, Cow_count + 1, container.RandomPoints);
        }
        if (Sheep_count > 0)
        {
            container.Sheep_paddock.isActive = true;
            container.Sheep_paddock.SpawnAnimals(container.Sheep_prefab, Sheep_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 3, Horse_count + 1, container.RandomPoints);
        }
        if (Chicken_count > 0)
        {
            container.Chicken_paddock.isActive = true;
            container.Chicken_paddock.SpawnAnimals(container.Chicken_prefab, Chicken_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 1, Sheep_count + 1, container.RandomPoints);
        }
    }

    private void ResetDieAnimals()
    {
        deadCount = 0;
        Goose_died = 0;
        Goat_died = 0;
        Ostrich_died = 0;
        Pig_died = 0;
        Cow_died = 0;
        Horse_died = 0;
        Sheep_died = 0;
        Chicken_died = 0;
    }

    private void DayActive()
    {
        if (DayIsActive)
        {
            timer += Time.deltaTime;
            container.InGame_ui.Display_Day_timer(Day_length - timer, Day_length);

            if (timer > Day_length)
            {
                DayIsActive = false;
                timer = 0;
                StartCoroutine(EarlyDayEnded());
         //       SwitchState();
                //вызов финиш панели
            }
        }
    }
    IEnumerator EarlyDayEnded()
    {
        Sun._instance.EarlyDayEnd();

        yield return new WaitForSeconds(2.7f);
        SwitchState();
        
    }
    public void CheckClosedPaddocks()
    {
        if (container.Goose_paddock.IsClosed &&
            container.Goat_paddock.IsClosed &&
            container.Ostrich_paddock.IsClosed &&
            container.Pig_paddock.IsClosed &&
            container.Cow_paddock.IsClosed &&
            container.Horse_paddock.IsClosed &&
            container.Sheep_paddock.IsClosed &&
            container.Chicken_paddock.IsClosed)
        {

            DayIsActive = false;
            timer = 0;
            Sun._instance.EarlyDayEnd();
            StartCoroutine(EarlyDayEnded());

         //   SwitchState();
        }
    }
    void StartgDay()
    {
        OpenGate();
        
        container.Goose_paddock.MoveAnimalsToWalkingZone(container.RandomPoints);
        container.Goat_paddock.MoveAnimalsToWalkingZone(container.RandomPoints);
        container.Ostrich_paddock.MoveAnimalsToWalkingZone(container.RandomPoints);
        container.Pig_paddock.MoveAnimalsToWalkingZone(container.RandomPoints);
        container.Cow_paddock.MoveAnimalsToWalkingZone(container.RandomPoints);
        container.Horse_paddock.MoveAnimalsToWalkingZone(container.RandomPoints);
        container.Sheep_paddock.MoveAnimalsToWalkingZone(container.RandomPoints);
        container.Chicken_paddock.MoveAnimalsToWalkingZone(container.RandomPoints);
        container.Goose_paddock.SwtichGatesLayer(true);
        container.Goat_paddock.SwtichGatesLayer(true);
        container.Ostrich_paddock.SwtichGatesLayer(true);
        container.Pig_paddock.SwtichGatesLayer(true);
        container.Cow_paddock.SwtichGatesLayer(true);
        container.Horse_paddock.SwtichGatesLayer(true);
        container.Sheep_paddock.SwtichGatesLayer(true);
        container.Chicken_paddock.SwtichGatesLayer(true);
    }
    private void EndDay()
    {
        container.Goose_paddock.EndDay();
        container.Goat_paddock.EndDay();
        container.Ostrich_paddock.EndDay();
        container.Pig_paddock.EndDay();
        container.Cow_paddock.EndDay();
        container.Horse_paddock.EndDay();
        container.Sheep_paddock.EndDay();
        container.Chicken_paddock.EndDay();
    }
    private void OpenGate()
    {
        container.Goose_paddock.OpenGate();
        container.Goat_paddock.OpenGate();
        container.Ostrich_paddock.OpenGate();
        container.Pig_paddock.OpenGate();
        container.Cow_paddock.OpenGate();
        container.Horse_paddock.OpenGate();
        container.Sheep_paddock.OpenGate();
        container.Chicken_paddock.OpenGate();
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(container.zone_to_walk.position, radius_walk_zone);
    }*/

    #region SwitchState
    public void SwitchState()
    {
        if(state == State.InMenu)
        {
            //    Sun.DayLengh = Day_length;
            DayLenghCalculating(startLength, stepPerAnimal);

            container.startDayAnim.StartDayAnimation();
            //начинаем игру
            StartgDay();
            StartCoroutine(HideManagerUI());
            

            //движением камеры и задержку пока не выйдут животные
            state = State.Ingame;
            container.Manager_ui.startDayButton.enabled = false;
        }
        else if(state == State.Ingame)
        {
            //        Sun._instance.DayEnded();
            Music._instance.Wolf();
            Display_Scoring();
            DisplayScoreDay();
            container.InGame_ui.gameObject.SetActive(false);
            container.Finish_ui.gameObject.SetActive(true);
            if(deadCount > 0)
            {
                container.Finish_ui.LoseDay(Goose_died, Goat_died, Ostrich_died, Pig_died, Cow_died, Horse_died, Sheep_died, Chicken_died);
            }
            else
            {
                container.Finish_ui.WinDay();
            }
            container.inputMouse.InGame = false;
            container.Goose_paddock.EnableColision(false);
            container.Goat_paddock.EnableColision(false);
            container.Ostrich_paddock.EnableColision(false);
            container.Pig_paddock.EnableColision(false);
            container.Cow_paddock.EnableColision(false);
            container.Horse_paddock.EnableColision(false);
            container.Sheep_paddock.EnableColision(false);
            container.Chicken_paddock.EnableColision(false);
            state = State.Finish;
            container.Manager_ui.startDayButton.enabled = true;

        }
        else if (state == State.Finish)
        {
       //     Sun._instance.StartNight();
            container.Finish_ui.gameObject.SetActive(false);
            container.Result_ui.gameObject.SetActive(true);
            Display_Gold_Earned();
            DisplayGold();
            DisplayAnimalsCountInManagerPanel();
            DisplayActive_inactive_paddock();

            feed_Bust_count = container.Inventory_ui.feed_buster_count;
            time_Bust_count = container.Inventory_ui.time_buster_count;
            DisplayBusters_count();
            SaveAll();
            state = State.Result;
        }
        else if (state == State.Result)
        {
            Music._instance.NightIsOn();

            container.Result_ui.gameObject.SetActive(false);
            container.Manager_ui.gameObject.SetActive(true);

            container.Ingame_panel.gameObject.SetActive(false);
            container.Manager_panel.gameObject.SetActive(true);
            EndDay();
            //вывод экрана меню (смещение камеру UI)
            state = State.InMenu;
        }
    }
    #endregion

    #region Buy Paddock / Animals
    public void BuyAnimal(ShopInGame.Type type)
    {

        if (type == ShopInGame.Type.Chicken)
        {
            if (gold >= container.animal_price.Chicken && Chicken_count < container.max_animals.Chicken)
            {
                Debug.Log("bye sucessful");
                container._soundController.BuySometing();

                Chicken_count++;
                gold -= container.animal_price.Chicken;
                container.Chicken_paddock.BuyAnimal(container.Chicken_prefab,Chicken_count ,container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 1,container.RandomPoints);

                DisplayGold();
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Chicken_paddock);

            }
            else if (gold < container.animal_price.Chicken && Chicken_count < container.max_animals.Chicken)
            {
                container._soundController.NotEnoughMoney();

                Debug.Log("not enough gold");
            }
            else if (Chicken_count >= container.max_animals.Chicken)
            {
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Chicken_paddock);
            }
        }
        if (type == ShopInGame.Type.Cow)
        {
            if (gold >= container.animal_price.Cow && Cow_count < container.max_animals.Cow)
            {
                container._soundController.BuySometing();

                Debug.Log("bye sucessful");
                Cow_count++;
                gold -= container.animal_price.Cow;
                container.Cow_paddock.BuyAnimal(container.Cow_prefab,Cow_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 6, container.RandomPoints);

                DisplayGold();
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Cow_paddock);

            }
            else if (gold < container.animal_price.Cow && Cow_count < container.max_animals.Cow)
            {
                container._soundController.NotEnoughMoney();

                Debug.Log("not enough gold");
            }
            else if (Cow_count >= container.max_animals.Cow)
            {
                DisplayAnimalsCountInManagerPanel();
            }
            container.Manager_panel.DisplayManagerPanel(container.Cow_paddock);
        }
        if (type == ShopInGame.Type.Goat)
        {
            if (gold >= container.animal_price.Goat && Goat_count < container.max_animals.Goat)
            {
                container._soundController.BuySometing();

                Debug.Log("bye sucessful");
                Goat_count++;
                gold -= container.animal_price.Goat;
                container.Goat_paddock.BuyAnimal(container.Goat_prefab,Goat_count,  container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 3, container.RandomPoints);

                DisplayGold();
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Goat_paddock);
            }
            else if (gold < container.animal_price.Goat && Goat_count < container.max_animals.Goat)
            {
                container._soundController.NotEnoughMoney();

                Debug.Log("not enough gold");
            }
            else if (Goat_count >= container.max_animals.Goat)
            {
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Goat_paddock);
            }
        }
        if (type == ShopInGame.Type.Goose)
        {
            if (gold >= container.animal_price.Goose && Goose_count < container.max_animals.Goose)
            {
                container._soundController.BuySometing();

                Debug.Log("bye sucessful");
                Goose_count++;
                gold -= container.animal_price.Goose;
                container.Goose_paddock.BuyAnimal(container.Goose_prefab,Goose_count,  container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 2, container.RandomPoints);

                DisplayGold();
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Goose_paddock);
            }
            else if (gold < container.animal_price.Goose && Goose_count < container.max_animals.Goose)
            {
                container._soundController.NotEnoughMoney();

                Debug.Log("not enough gold");
            }
            else if (Goose_count >= container.max_animals.Goose)
            {
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Goose_paddock);
            }
        }
        if (type == ShopInGame.Type.Horse)
        {
            if (gold >= container.animal_price.Horse && Horse_count < container.max_animals.Horse)
            {
                container._soundController.BuySometing();

                Debug.Log("bye sucessful");
                Horse_count++;
                gold -= container.animal_price.Horse;
                container.Horse_paddock.BuyAnimal(container.horse_prefab,Horse_count,  container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 7, container.RandomPoints);

                DisplayGold();
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Horse_paddock);
            }
            else if (gold < container.animal_price.Horse && Horse_count < container.max_animals.Horse)
            {
                container._soundController.NotEnoughMoney();

                Debug.Log("not enough gold");
            }
            else if (Horse_count >= container.max_animals.Horse)
            {
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Horse_paddock);
            }
        }
        if (type == ShopInGame.Type.Ostrich)
        {
            if (gold >= container.animal_price.Ostrich && Ostrich_count < container.max_animals.Ostrich)
            {
                container._soundController.BuySometing();

                Debug.Log("bye sucessful");
                Ostrich_count++;
                gold -= container.animal_price.Ostrich;
                container.Ostrich_paddock.BuyAnimal(container.Ostrich_prefab,Ostrich_count,  container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 5, container.RandomPoints);

                DisplayGold();
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Ostrich_paddock);
            }
            else if (gold < container.animal_price.Ostrich && Ostrich_count < container.max_animals.Ostrich)
            {
                container._soundController.NotEnoughMoney();

                Debug.Log("not enough gold");
            }
            else if (Ostrich_count >= container.max_animals.Ostrich)
            {
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Ostrich_paddock);
            }
        }
        if (type == ShopInGame.Type.Pig)
        {
            if (gold >= container.animal_price.Pig && Pig_count < container.max_animals.Pig)
            {
                container._soundController.BuySometing();

                Debug.Log("bye sucessful");
                Pig_count++;
                gold -= container.animal_price.Pig;
                container.Pig_paddock.BuyAnimal(container.pig_prefab,Pig_count,  container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 4, container.RandomPoints);

                DisplayGold();
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Pig_paddock);
            }
            else if (gold < container.animal_price.Pig && Pig_count < container.max_animals.Pig)
            {
                container._soundController.NotEnoughMoney();

                Debug.Log("not enough gold");
            }
            else if (Pig_count >= container.max_animals.Pig)
            {
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Pig_paddock);
            }
        }
        if (type == ShopInGame.Type.Sheep)
        {
            if (gold >= container.animal_price.Sheep && Sheep_count < container.max_animals.Sheep)
            {
                container._soundController.BuySometing();

                Debug.Log("bye sucessful");
                Sheep_count++;
                gold -= container.animal_price.Sheep;
                container.Sheep_paddock.BuyAnimal(container.Sheep_prefab,Sheep_count,  container.zone_to_walk, radius_walk_zone, container.AnimalsParrent, 3, container.RandomPoints);

                DisplayGold();
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Sheep_paddock);
            }
            else if (gold < container.animal_price.Sheep && Sheep_count < container.max_animals.Sheep)
            {
                container._soundController.NotEnoughMoney();

                Debug.Log("not enough gold");
            }
            else if (Sheep_count >= container.max_animals.Sheep)
            {
                DisplayAnimalsCountInManagerPanel();
                container.Manager_panel.DisplayManagerPanel(container.Sheep_paddock);
            }
        }
        DisplayGold();
        SaveAll();
    }
    public void BuePaddock(ShopInGame.Type type)
    {

        if (type == ShopInGame.Type.Goose)
        {
            if (gold >= container.PaddockPrice.Goose)
            {
                container._soundController.BuySometing();

                gold -= container.PaddockPrice.Goose;
                DisplayGold();
                Save.Goose_paddockSave(true);
                container.Goose_paddock.isActive = true;
                container.Manager_panel.DisplayManagerPanel(container.Goose_paddock);
            }
            else
            {
                container._soundController.NotEnoughMoney();
            }
        }
        if (type == ShopInGame.Type.Chicken)
        {
            if (gold >= container.PaddockPrice.Chicken)
            {
                container._soundController.BuySometing();

                gold -= container.PaddockPrice.Chicken;
                DisplayGold();
                Save.Chicken_paddockSave(true);
                container.Chicken_paddock.isActive = true;
                container.Manager_panel.DisplayManagerPanel(container.Chicken_paddock);
            }
            else
            {
                container._soundController.NotEnoughMoney();
            }
        }
        else if (type == ShopInGame.Type.Cow)
        {
            if (gold >= container.PaddockPrice.Cow)
            {
                container._soundController.BuySometing();

                gold -= container.PaddockPrice.Cow;
                DisplayGold();
                Save.Cow_paddockSave(true);
                container.Cow_paddock.isActive = true;
                container.Manager_panel.DisplayManagerPanel(container.Cow_paddock);
            }
            else
            {
                container._soundController.NotEnoughMoney();
            }
        }
        else if (type == ShopInGame.Type.Goat)
        {
            if (gold >= container.PaddockPrice.Goat)
            {
                container._soundController.BuySometing();

                gold -= container.PaddockPrice.Goat;
                DisplayGold();
                Save.Goat_paddockSave(true);
                container.Goat_paddock.isActive = true;
                container.Manager_panel.DisplayManagerPanel(container.Goat_paddock);
            }
            else
            {
                container._soundController.NotEnoughMoney();
            }
        }
        else if (type == ShopInGame.Type.Horse)
        {
            if (gold >= container.PaddockPrice.Horse)
            {
                container._soundController.BuySometing();

                gold -= container.PaddockPrice.Horse;
                DisplayGold();
                Save.Horse_paddockSave(true);
                container.Horse_paddock.isActive = true;
                container.Manager_panel.DisplayManagerPanel(container.Horse_paddock);
            }
            else
            {
                container._soundController.NotEnoughMoney();
            }
        }
        else if (type == ShopInGame.Type.Ostrich)
        {
            if (gold >= container.PaddockPrice.Ostrich)
            {
                container._soundController.BuySometing();

                gold -= container.PaddockPrice.Ostrich;
                DisplayGold();
                Save.Ostrich_paddockSave(true);
                container.Ostrich_paddock.isActive = true;
                container.Manager_panel.DisplayManagerPanel(container.Ostrich_paddock);
            }
            else
            {
                container._soundController.NotEnoughMoney();
            }
        }
        else if (type == ShopInGame.Type.Pig)
        {
            if (gold >= container.PaddockPrice.Pig)
            {
                container._soundController.BuySometing();

                gold -= container.PaddockPrice.Pig;
                DisplayGold();
                Save.Pig_paddockSave(true);
                container.Pig_paddock.isActive = true;
                container.Manager_panel.DisplayManagerPanel(container.Pig_paddock);
            }
            else
            {
                container._soundController.NotEnoughMoney();
            }
        }
        else if (type == ShopInGame.Type.Sheep)
        {
            if (gold >= container.PaddockPrice.Sheep)
            {
                container._soundController.BuySometing();

                gold -= container.PaddockPrice.Sheep;
                DisplayGold();
                Save.Sheep_paddockSave(true);
                container.Sheep_paddock.isActive = true;
                container.Manager_panel.DisplayManagerPanel(container.Sheep_paddock);
            }
            else
            {
                container._soundController.NotEnoughMoney();
            }
        }
        DisplayGold();
        SaveAll();
    }
    #endregion
    #region Display
  
    public void DisplayActive_inactive_paddock()
    {
        container.Manager_panel.DisplayManagerPanel(container.Goose_paddock);
        container.Manager_panel.DisplayManagerPanel(container.Goat_paddock);
        container.Manager_panel.DisplayManagerPanel(container.Ostrich_paddock);
        container.Manager_panel.DisplayManagerPanel(container.Pig_paddock);
        container.Manager_panel.DisplayManagerPanel(container.Cow_paddock);
        container.Manager_panel.DisplayManagerPanel(container.Horse_paddock);
        container.Manager_panel.DisplayManagerPanel(container.Sheep_paddock);
        container.Manager_panel.DisplayManagerPanel(container.Chicken_paddock);
    }

    private void DisplayScoreDay() // Проверяем количество каждого скота
    {
        Goose_count = container.Goose_paddock.In_Side_animals.Count;
        Goat_count = container.Goat_paddock.In_Side_animals.Count;
        Ostrich_count = container.Ostrich_paddock.In_Side_animals.Count;
        Pig_count = container.Pig_paddock.In_Side_animals.Count;
        Cow_count = container.Cow_paddock.In_Side_animals.Count;
        Horse_count = container.Horse_paddock.In_Side_animals.Count;
        Sheep_count = container.Sheep_paddock.In_Side_animals.Count;
        Chicken_count = container.Chicken_paddock.In_Side_animals.Count;
    }
    private void DisplayGold()
    {
            container.Manager_ui.Display_Gold_earned(gold);
    }
    private void Display_Gold_Earned() // вывод заработанного количества денег на экран
    {
        container.Result_ui.Gold_earned(Goose_count, Goat_count, Ostrich_count, Pig_count, Cow_count, Horse_count, Sheep_count, Chicken_count);
    }
    private void Display_Scoring() // сьедаем скот и перемещаем в загон
    {
        deadCount = 0;
        ResetDieAnimals();
        Goose_died = container.Goose_paddock.Day_result();
        Goat_died = container.Goat_paddock.Day_result();
        Ostrich_died = container.Ostrich_paddock.Day_result();
        Pig_died = container.Pig_paddock.Day_result();
        Cow_died = container.Cow_paddock.Day_result();
        Horse_died = container.Horse_paddock.Day_result();
        Sheep_died = container.Sheep_paddock.Day_result();
        Chicken_died = container.Chicken_paddock.Day_result();
        deadCount = (Goose_died + Goat_died + Ostrich_died + Pig_died + Cow_died + Horse_died + Sheep_died + Chicken_died);
    }
    private void DisplayBusters_count()
    {
        container.Inventory_ui.Display_Busters_Count(feed_Bust_count, time_Bust_count);
        container.Manager_ui.Display_Bust_counts(feed_Bust_count, time_Bust_count);

    }
    private void DisplayBusters_price()
    {
        container.Manager_ui.DisplayBusters_price(container.busters_price.Feed_bust_price, container.busters_price.Time_bust_price);
    }

    #endregion

    #region Buy Bust 
    public void BuyFeedBust()
    {
        if (gold >= container.busters_price.Feed_bust_price)
        {
            container._soundController.BuySometing();
            feed_Bust_count += 5;
            gold -= container.busters_price.Feed_bust_price;
            DisplayGold();
            DisplayBusters_count();

        }
        else
        {
            container._soundController.NotEnoughMoney();

            Debug.Log("Not enough gold to buy Feed_Buster");
        }
    }
    public void BuyTimeBust()
    {
        Debug.Log(time_Bust_count  + " =  TIME BEFORE");

        if (gold >= container.busters_price.Time_bust_price)
        {
            container._soundController.BuySometing();
            Debug.Log(time_Bust_count + " =  TIME AFTER");

            time_Bust_count++;
            gold -= container.busters_price.Time_bust_price;
            DisplayGold();
            DisplayBusters_count();
        }
        else
        {
            container._soundController.NotEnoughMoney();

            Debug.Log("Not enough gold to buy Time_Buster");
        }
    }
    #endregion  
    IEnumerator HideManagerUI()
    {
        yield return new WaitForSeconds(1f);
        Sun._instance.SunStart();
        container.Manager_ui.gameObject.SetActive(false);
        container.InGame_ui.gameObject.SetActive(true);
        container.Ingame_panel.gameObject.SetActive(true);
        container.Manager_panel.gameObject.SetActive(false);
    }
    private void DayLenghCalculating(int startLength, int StepPerAnimal)
    {
        int tmp = (Goose_count +
            Goat_count +
            Ostrich_count +
            Pig_count +
            Cow_count +
            Horse_count +
            Sheep_count +
            Chicken_count);
        if(tmp != 0)
        {
            Day_length = startLength + ((tmp - 1) * StepPerAnimal);
        }
        else
        {
            Day_length = 0;
        }
    }
}
