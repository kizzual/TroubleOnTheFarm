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
            Gold = 500;
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
        }
        else
        {
            Goose_paddock = false;
        }
        if (PlayerPrefs.GetInt("Goat_paddock") == 1)
        {
            Goat_paddock = true;
        }
        else
        {
            Goat_paddock = false;
        }
        if (PlayerPrefs.GetInt("Ostrich_paddock") == 1)
        {
            Ostrich_paddock = true;
        }
        else
        {
            Ostrich_paddock = false;
        }
        if (PlayerPrefs.GetInt("Pig_paddock") == 1)
        {
            Pig_paddock = true;
        }
        else
        {
            Pig_paddock = false;
        }
        if (PlayerPrefs.GetInt("Cow_paddock") == 1)
        {
            Cow_paddock = true;
        }
        else
        {
            Cow_paddock = false;
        }
        if (PlayerPrefs.GetInt("Horse_paddock") == 1)
        {
            Horse_paddock = true;
        }
        else
        {
            Horse_paddock = false;
        }
        if (PlayerPrefs.GetInt("Sheep_paddock") == 1)
        {
            Sheep_paddock = true;
        }
        else
        {
            Sheep_paddock = false;
        }
        if (PlayerPrefs.GetInt("Chicken_paddock") == 1)
        {
            Chicken_paddock = true;
        }
        else
        {
            Chicken_paddock = false;
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

}
