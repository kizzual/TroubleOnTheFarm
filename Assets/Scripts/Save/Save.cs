using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private static int Gold;
    public static int Gold_Get()
    {
        return Gold;
    }
    private static int Feed_bust_count;
    public static int Feed_bust_count_Get()
    {
        return Feed_bust_count;
    }
    private static int Time_bust_count;
    public static int Time_bust_count_Get()
    {
        return Time_bust_count;
    }
    private static bool MusicOn;
    public static bool MusicOn_Get()
    {
        return MusicOn;
    }
    private static bool AnimalsSoundOn;
    public static bool AnimalsSoundOn_Get()
    {
        return AnimalsSoundOn;
    }
    private static int Day;
    public static int Day_Get()
    {
        return Day;
    }
    private static int Graphic;
    public static int Graphic_Get()
    {
        return Graphic;
    }


    // animals
    private static int Goose_count;
    public static int Goose_count_Get()
    {
        return Goose_count;
    }
    private static int Goat_count;
    public static int Goat_count_Get()
    {
        return Goat_count;
    }
    private static int Ostrich_count;
    public static int Ostrich_count_Get()
    {
        return Ostrich_count;
    }
    private static int Pig_count;
    public static int Pig_count_Get()
    {
        return Pig_count;
    }
    private static int Cow_count;
    public static int Cow_count_Get()
    {
        return Cow_count;
    }
    private static int Horse_count;
    public static int Horse_count_Get()
    {
        return Horse_count;
    }
    private static int Sheep_count;
    public static int Sheep_count_Get()
    {
        return Sheep_count;
    }
    private static int Chicken_count;
    public static int Chicken_count_Get()
    {
        return Chicken_count;
    }

    //paddock
    private static bool Goose_paddock;
    public static bool Goose_paddock_Get()
    {
        return Goose_paddock;
    }
    private static bool Goat_paddock;
    public static bool Goat_paddock_Get()
    {
        return Goat_paddock;
    }
    private static bool Ostrich_paddock;
    public static bool Ostrich_paddock_Get()
    {
        return Ostrich_paddock;
    }
    private static bool Pig_paddock;
    public static bool Pig_paddock_Get()
    {
        return Pig_paddock;
    }
    private static bool Cow_paddock;
    public static bool Cow_paddock_Get()
    {
        return Cow_paddock;
    }
    private static bool Horse_paddock;
    public static bool Horse_paddock_Get()
    {
        return Horse_paddock;
    }
    private static bool Sheep_paddock;
    public static bool Sheep_paddock_Get()
    {
        return Sheep_paddock;
    }
    private static bool Chicken_paddock;
    public static bool Chicken_paddock_Get()
    {
        return Chicken_paddock;
    }


    // resources
    private static int Goose_res;
    public static int Goose_res_Get()
    {
        return Goose_res;
    }
    private static int Goat_res;
    public static int Goat_res_Get()
    {
        return Goat_res;
    }
    private static int Ostrich_res;
    public static int Ostrich_res_Get()
    {
        return Ostrich_res;
    }
    private static int Pig_res;
    public static int Pig_res_Get()
    {
        return Pig_res;
    }
    private static int Cow_res;
    public static int Cow_res_Get()
    {
        return Cow_res;
    }
    private static int Horse_res;
    public static int Horse_res_Get()
    {
        return Horse_res;
    }
    private static int Sheep_res;
    public static int Sheep_res_Get()
    {
        return Sheep_res;
    }
    private static int Chicken_res;
    public static int Chicken_res_Get()
    {
        return Chicken_res;
    }


    private void Awake()
    {
      
        CheckSave();
    }
    public static void CheckSave()
    {
    

        if (PlayerPrefs.HasKey("Gold"))
        {
            Gold = PlayerPrefs.GetInt("Gold");
        }
        else
        {
            Gold = 75;
        }
        if (PlayerPrefs.HasKey("Feed_bust_count"))
        {
            Feed_bust_count = PlayerPrefs.GetInt("Feed_bust_count");
        }
        else
        {
            Feed_bust_count = 0;
        }
        if (PlayerPrefs.HasKey("Time_bust_count"))
        {
            Time_bust_count = PlayerPrefs.GetInt("Time_bust_count");
        }
        else
        {
            Time_bust_count = 0;
        }
        if (PlayerPrefs.HasKey("MusicOn"))
        {
            if (PlayerPrefs.GetInt("MusicOn") == 1)
            {
                MusicOn = true;
            }
            else
            {
                MusicOn = false;
            }
        }
        else
        {
            MusicOn = true;
        }
        if (PlayerPrefs.HasKey("SoundOn"))
        {
            if (PlayerPrefs.GetInt("SoundOn") == 1)
            {
                AnimalsSoundOn = true;
            }
            else
            {
                AnimalsSoundOn = false;
            }
        }
        else
        {
            AnimalsSoundOn = true;
        }
        if (PlayerPrefs.HasKey("Day"))
        {
            Day = PlayerPrefs.GetInt("Day");
        }
        else
        {
            Day = 0;
        }
        if(PlayerPrefs.HasKey("Graphic"))
        {
            if(PlayerPrefs.GetInt("Graphic") == 0)
            {
                Graphic = 0;
            }
            else if(PlayerPrefs.GetInt("Graphic") == 1)
            {
                Graphic = 1;
            }
            else if(PlayerPrefs.GetInt("Graphic") == 2)
            {
                Graphic = 2;
            }
        }
        else
        {
            Graphic = 1;
        }
        //animals

        if (PlayerPrefs.HasKey("Goose_count"))
        {
            Goose_count = PlayerPrefs.GetInt("Goose_count");
        }
        else
        {
            Goose_count = 0;
        }
        if (PlayerPrefs.HasKey("Goat_count"))
        {
            Goat_count = PlayerPrefs.GetInt("Goat_count");
        }
        else
        {
            Goat_count = 0;
        }
        if (PlayerPrefs.HasKey("Ostrich_count"))
        {
            Ostrich_count = PlayerPrefs.GetInt("Ostrich_count");
        }
        else
        {
            Ostrich_count = 0;
        }
        if (PlayerPrefs.HasKey("Pig_count"))
        {
            Pig_count = PlayerPrefs.GetInt("Pig_count");
        }
        else
        {
            Pig_count = 0;
        }
        if (PlayerPrefs.HasKey("Cow_count"))
        {
            Cow_count = PlayerPrefs.GetInt("Cow_count");
        }
        else
        {
            Cow_count = 0;
        }
        if (PlayerPrefs.HasKey("Horse_count"))
        {
            Horse_count = PlayerPrefs.GetInt("Horse_count");
        }
        else
        {
            Horse_count = 0;
        }
        if (PlayerPrefs.HasKey("Sheep_count"))
        {
            Sheep_count = PlayerPrefs.GetInt("Sheep_count");
        }
        else
        {
            Sheep_count = 0;
        }
        if (PlayerPrefs.HasKey("Chicken_count"))
        {
            Chicken_count = PlayerPrefs.GetInt("Chicken_count");
        }
        else
        {
            Chicken_count = 0;
        }

        //paddock

        if (PlayerPrefs.GetInt("Goose_paddock") == 1)
        {
            Goose_paddock = true;
            Goose_paddockSave(true);
        }
        else
        {
            Goose_paddock = false;
            Goose_paddockSave(false);

        }
        if (PlayerPrefs.GetInt("Goat_paddock") == 1)
        {
            Goat_paddock = true;
            Goat_paddockSave(true);
        }
        else
        {
            Goat_paddock = false;
            Goat_paddockSave(false);
        }
        if (PlayerPrefs.GetInt("Ostrich_paddock") == 1)
        {
            Ostrich_paddock = true;
            Ostrich_paddockSave(true);
        }
        else
        {
            Ostrich_paddock = false;
            Ostrich_paddockSave(false);
        }
        if (PlayerPrefs.GetInt("Pig_paddock") == 1)
        {
            Pig_paddock = true;
            Pig_paddockSave(true);
        }
        else
        {
            Pig_paddock = false;
            Pig_paddockSave(false);
        }
        if (PlayerPrefs.GetInt("Cow_paddock") == 1)
        {
            Cow_paddock = true;
            Cow_paddockSave(true);
        }
        else
        {
            Cow_paddock = false;
            Cow_paddockSave(false);
        }
        if (PlayerPrefs.GetInt("Horse_paddock") == 1)
        {
            Horse_paddock = true;
            Horse_paddockSave(true);
        }
        else
        {
            Horse_paddock = false;
            Horse_paddockSave(false);
        }
        if (PlayerPrefs.GetInt("Sheep_paddock") == 1)
        {
            Sheep_paddock = true;
            Sheep_paddockSave(true);
        }
        else
        {
            Sheep_paddock = false;
            Sheep_paddockSave(false);
        }
        if (PlayerPrefs.GetInt("Chicken_paddock") == 1)
        {
            Chicken_paddock = true; 
            Chicken_paddockSave(true);
        }
        else
        {
            Chicken_paddock = false;
            Chicken_paddockSave(false);
        }

        // resources

        if (PlayerPrefs.HasKey("Goose_res"))
        {
            Goose_res = PlayerPrefs.GetInt("Goose_res");
        }
        else
        {
            Goose_res = 0;
        }
        if (PlayerPrefs.HasKey("Goat_res"))
        {
            Goat_res = PlayerPrefs.GetInt("Goat_res");
        }
        else
        {
            Goat_res = 0;
        }
        if (PlayerPrefs.HasKey("Ostrich_res"))
        {
            Ostrich_res = PlayerPrefs.GetInt("Ostrich_res");
        }
        else
        {
            Ostrich_res = 0;
        }
        if (PlayerPrefs.HasKey("Pig_res"))
        {
            Pig_res = PlayerPrefs.GetInt("Pig_res");
        }
        else
        {
            Pig_res = 0;
        }
        if (PlayerPrefs.HasKey("Cow_res"))
        {
            Cow_res = PlayerPrefs.GetInt("Cow_res");
        }
        else
        {
            Cow_res = 0;
        }
        if (PlayerPrefs.HasKey("Horse_res"))
        {
            Horse_res = PlayerPrefs.GetInt("Horse_res");
        }
        else
        {
            Horse_res = 0;
        }
        if (PlayerPrefs.HasKey("Sheep_res"))
        {
            Sheep_res = PlayerPrefs.GetInt("Sheep_res");
        }
        else
        {
            Sheep_res = 0;
        }
        if (PlayerPrefs.HasKey("Chicken_res"))
        {
            Chicken_res = PlayerPrefs.GetInt("Chicken_res");
        }
        else
        {
            Chicken_res = 0;
        }
    }
    public static void SaveStats()
    {
        PlayerPrefs.SetInt("Gold", Gold);
        PlayerPrefs.SetInt("Feed_bust_count", Feed_bust_count);
        PlayerPrefs.SetInt("Time_bust_count", Time_bust_count);
        PlayerPrefs.SetInt("Day", Day);
        //animals
        PlayerPrefs.SetInt("Goose_count", Goose_count);
        PlayerPrefs.SetInt("Goat_count", Goat_count);
        PlayerPrefs.SetInt("Ostrich_count", Ostrich_count);
        PlayerPrefs.SetInt("Pig_count", Pig_count);
        PlayerPrefs.SetInt("Cow_count", Cow_count);
        PlayerPrefs.SetInt("Horse_count", Horse_count);
        PlayerPrefs.SetInt("Sheep_count", Sheep_count);
        PlayerPrefs.SetInt("Chicken_count", Chicken_count);
        //resources
        PlayerPrefs.SetInt("Goose_res", Goose_res);
        PlayerPrefs.SetInt("Goat_res", Goat_res);
        PlayerPrefs.SetInt("Ostrich_res", Ostrich_res);
        PlayerPrefs.SetInt("Pig_res", Pig_res);
        PlayerPrefs.SetInt("Cow_res", Cow_res);
        PlayerPrefs.SetInt("Horse_res", Horse_res);
        PlayerPrefs.SetInt("Sheep_res", Sheep_res);
        PlayerPrefs.SetInt("Chicken_res", Chicken_res);
    }
    public static void Save_Gold(int value)
    {
        Gold = value;
    }
    public static void Save_Feed_bust(int value)
    {
        Feed_bust_count = value;
    }
    public static void Save_Time_bust(int value)
    {
        Time_bust_count = value;
    }
    public static void Save_Day(int value)
    {
        Day = value;
    }
    public static void MusicSave(bool sound)
    {
        if (sound)
        {
            PlayerPrefs.SetInt("MusicOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MusicOn", 0);

        }
    }
    public static void SoundSave(bool sound)
    {
        if (sound)
        {
            PlayerPrefs.SetInt("SoundOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SoundOn", 0);

        }
    }

    public static void GraphicSave(int value)
    {
        Graphic = value;
        PlayerPrefs.SetInt("Graphic", value);
    }

    //animals
    public static void Save_Goose_count(int value)
    {
        Goose_count = value;
    }
    public static void Save_Goat_count(int value)
    {
        Goat_count = value;
    }
    public static void Save_Ostrich_count(int value)
    {
        Ostrich_count = value;
    }
    public static void Save_Pig_count(int value)
    {
        Pig_count = value;
    }
    public static void Save_Cow_count(int value)
    {
        Cow_count = value;
    }
    public static void Save_Horse_count(int value)
    {
        Horse_count = value;
    }
    public static void Save_Sheep_count(int value)
    {
        Sheep_count = value;
    }
    public static void Save_Chicken_count(int value)
    {
        Chicken_count = value;
    }

    //paddock 

    public static void Goose_paddockSave(bool IsActive)
    {
        if (IsActive)
        {
            PlayerPrefs.SetInt("Goose_paddock", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Goose_paddock", 0);

        }
    }
    public static void Goat_paddockSave(bool IsActive)
    {
        if (IsActive)
        {
            PlayerPrefs.SetInt("Goat_paddock", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Goat_paddock", 0);

        }
    }
    public static void Ostrich_paddockSave(bool IsActive)
    {
        if (IsActive)
        {
            PlayerPrefs.SetInt("Ostrich_paddock", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Ostrich_paddock", 0);

        }
    }
    public static void Pig_paddockSave(bool IsActive)
    {
        if (IsActive)
        {
            PlayerPrefs.SetInt("Pig_paddock", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Pig_paddock", 0);

        }
    }
    public static void Cow_paddockSave(bool IsActive)
    {
        if (IsActive)
        {
            PlayerPrefs.SetInt("Cow_paddock", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Cow_paddock", 0);

        }
    }
    public static void Horse_paddockSave(bool IsActive)
    {
        if (IsActive)
        {
            PlayerPrefs.SetInt("Horse_paddock", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Horse_paddock", 0);

        }
    }
    public static void Sheep_paddockSave(bool IsActive)
    {
        if (IsActive)
        {
            PlayerPrefs.SetInt("Sheep_paddock", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Sheep_paddock", 0);

        }
    }
    public static void Chicken_paddockSave(bool IsActive)
    {
        if (IsActive)
        {
            PlayerPrefs.SetInt("Chicken_paddock", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Chicken_paddock", 0);

        }
    }


    // resources

    public static void Save_Goose_res(int value)
    {
        Goose_res = value;
    }
    public static void Save_Goat_res(int value)
    {
        Goat_res = value;
    }
    public static void Save_Ostrich_rest(int value)
    {
        Ostrich_res = value;
    }
    public static void Save_Pig_res(int value)
    {
        Pig_res = value;
    }
    public static void Save_Cow_res(int value)
    {
        Cow_res = value;
    }
    public static void Save_Chicken_res(int value)
    {
        Chicken_res = value;
    }
    public static void Save_Sheep_res(int value)
    {
        Sheep_res = value;
    }
    public static void Save_Horse_res(int value)
    {
        Horse_res = value;
    }
}
