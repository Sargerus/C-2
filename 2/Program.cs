//Use Ctrl+F for navigation
// 1) - Simple Demostration of classes
// 2) - Simple Exception logic
// 3) - Override methods
// 4) - Pattern block
//=====+++++=====+++++=====+++++=====+++++=====+++++=====+++++=====+++++=====+++++=====+++++=====+++++
using System;

enum Pet { Dog, Bear, Eagle }                                //Pets for Hunters
enum ElementalSchool { Fire=0, Water, Wind}                  //School for Shamans
abstract class Fighter                                       //Abstract Fighter
{
    //Constructor
    public Fighter(string name = "FaceLess", double str = 15, double agi = 15, double intil = 15, double arm = 0, int atck = 8, int spd = 100){
        Name = name;
        Strength = str;
        Agility = agi;
        Intillegence = intil;
        Armor = arm;
        Attack = atck;
        Speed = spd;
        Console.WriteLine("Simple warrior, nothing special");
    }

    
    //Main characteristics
    protected string Name { get; set; }
    protected double Strength { get; set; }
    protected double Agility { get; set; }
    protected double Intillegence { get; set; }
    protected double Armor { get; set; }
    protected int Attack {get; set;}
    protected int Speed {get; set;}
   //---------------------------------------------------------


    //Virtual writing to file 
    public virtual bool WriteToFile(){return true;}
        
}                                   
partial class Hunter : Fighter, Sneaking
{
    public string ToFile; 
   public Hunter(string name = "FaceLess Hunter", double str = 20, double agi = 40, double intil = 5, double arm = 8, int atck = 25, int spd = 150, int pet = 0) 
                                  : base( name,  str,  agi,  intil,  arm, atck, spd)
    {
        switch (pet)
        {
            case 0: pet = 0; break;
            case 1: pet = 1; break;
            case 2: pet = 2; break;
        }
        ToFile = string.Format("Имя: {0}\n Сила: {1}\n Ловкость: {2}\n Интеллект: {3}\n Броня: {4}\n Атака: {5}\n Скорость: {6}\n Питомец: {7}",name,str,agi,intil,arm,atck,spd,pet);
        NightVision = false;
        Speed = Speed + 50;
        SkillLevel = 5;
        Console.WriteLine("I'm always ready!");
    }
    Pet pet;
    public byte SkillLevel {get;set;} 
    private bool NightVision {get;set;}
    
    
}

sealed class Shaman : Fighter                                //Nicely Shaman
{
    
    //variable for writing to file method 
    string ToFile;

    //Constructor
    public Shaman(string name = "FaceLess Shaman", double str = 8, double agi = 10, double intil = 40, double arm = 4, int atck = 12, int spd = 130, int scl = 0)
        : base(name, str, agi, intil, arm, atck, spd)
    {
        switch (scl)
        {
            case 0: ElScl = ElementalSchool.Fire; break;
            case 1: ElScl = ElementalSchool.Water; break;
            case 2: ElScl = ElementalSchool.Wind; break;
        }
        
        ToFile = string.Format("Имя: {0}\n Сила: {1}\n Ловкость: {2}\n Интеллект: {3}\n Броня: {4}\n Атака: {5}\n Скорость: {6}\n Школа: {7}", name, str, agi, intil, arm, atck, spd, scl);
        Console.WriteLine("New master come to this world...");
    }
    
    ElementalSchool ElScl;
    
    //some skills for fun
    public void BringTheLight()
    {
        Console.WriteLine("I can erase shadow deep within in you!");
    }
    public void Curse()
    {
        Console.WriteLine("You are cursed, Earthborn!");
    }
     //------------------------------

    //*******************overrides***********************
    public override bool Equals(object obj)
    {
        if (obj is Shaman)
           if (Name == ((Shaman)obj).Name) return true;
        return false;
    }

    public override int GetHashCode()
    {
        return (int)(Strength*Agility+Intillegence);
    }

    public override string ToString()
    {
        Console.WriteLine();
        string buf = string.Format(
 @"Main charachteristic:                     Additional:
Strength: {0}                             Attack: {1}
Agility: {2}                              Armor: {3}
Intillegence: {4}                         Speed: {5}",
 Strength, Attack, Agility, Armor, Intillegence, Speed);
        return buf;
    }

    public override bool WriteToFile()
    {
        System.IO.File.WriteAllText(@"e:\4 семестр\c#\2\Shaman.txt", ToFile);
        return true;
    }
    //*************************************************************************
    
    //Tuple of Magic
    public Tuple<string, int, char, string, int, char> MagicArray()
    {
        return Tuple.Create<string, int, char, string, int, char>("Spirit Blast", 1, 's', "Fireball", 2, 'f');
    }

}

//singleton pattern
class EpicBoss                                               //EpicBoss... oouuuugth
{

    //main instance variable
    private static EpicBoss instance;
    
    //private constructor
    private EpicBoss(string name) { _Level = 1; _Name = name; }
    private short _Level;
    private string _Name;

    
    //main method
    public static EpicBoss getInstance(string name)
    {
        if (instance == null)
        {
            instance = new EpicBoss(name);
            return instance;
        }
        return null;
    }


    //------------------for Memento pattern---------------------
    //load state
    public void LoadLevel(Creator cr)
    {
        _Level = cr.GetLevel();
        Console.WriteLine("Loaded");
    }
    
    //savestate
    public void SaveLevel(Creator cr){
        cr.Memento(_Level);
        Console.WriteLine("Saved");
    }

    //decrease boss level
    public void DecreaseLevel(short i)
    {
        _Level = (short)(_Level - i);
        Console.WriteLine("Decreased");
    }

    //show boss level
    public void ShowLevel()
    {
        Console.WriteLine("Level of boss in now: {0}", _Level);
    }
    //---------------------------------------------------------------
}


class Creator                                                //Memento pattern
{
    //main variable
    private short BossLevel;

    //get boss level for save
    public void Memento(short lvl)
    {
        BossLevel = lvl;
    }

    //return saved state
    public short GetLevel()
    {
        return BossLevel;
    }
}

    class Program
    {
        
        static void Main(string[] args)
        {
            Shaman sh1 = new Shaman();
            Shaman sh2 = new Shaman();
            Hunter h1 = new Hunter();
            Hunter h2 = new Hunter();



            //1)******************************************************************************************************
            Console.WriteLine("\n\n*************Demostration Shaman Class************");
            Console.Write("\nEquals: Is Shaman1 = Shaman 2? "); Console.WriteLine(sh1.Equals(sh2));
            Console.WriteLine("------------------------------------------------------");
            Console.Write("GetHashCode: Hash code of Shaman1 "); Console.WriteLine(sh1.GetHashCode());
            Console.WriteLine("------------------------------------------------------");
            Console.Write("\nToString: "); Console.WriteLine(sh1.ToString());
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("\nShamans Tuple: MagicArray: ");
            Tuple<string, int, char, string, int, char> ma = sh1.MagicArray();
            Console.WriteLine("First basic skill: {0}\nNumber of skill: {1}\nHotkey: {2}\n\n"+
                               "Second basic skill: {3}\nNumber of skill: {4}\nHotkey: {5}",ma.Item1,ma.Item2,ma.Item3,ma.Item4,ma.Item5,ma.Item6);
            Console.WriteLine("******************************************************");
            //1)******************************************************************************************************1)


            //2)------------------------------------------------------------------------------------------------------
            Console.WriteLine("\n\n*************Exception logic************");
            try
            {
                Console.WriteLine("Give me Hunter, please");
                if (Hunter.IsHunter(sh1)==false) throw new Exception("You are lier");
            }
            catch (Exception exc)
            {
                Console.WriteLine("You catch an exception!!!");
                Console.WriteLine("....");
                Console.WriteLine("Mesage: {0}",exc.Message);
                Console.WriteLine("Method: {0}",exc.TargetSite);
                Console.WriteLine("Source: {0}",exc.TargetSite.DeclaringType);
                Console.WriteLine("Class defining member: {0}", exc.TargetSite.MemberType);
               
            }
            finally  {
                Console.WriteLine("*************You are out of exception logic******************");
            }
            //------------------------------------------------------------------------------------------------------2)


            //3)******************************************************************************************************
            Console.WriteLine("\n\n**********Override logic*********");
            Console.WriteLine("Standalone char of h1: "); Console.WriteLine(h1.ShowChar());
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Standalone char of h2: "); Console.WriteLine(h2.ShowChar());
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Now plus...");
            
            
            Hunter plus = h1 + h2;
            Hunter minus = h1 - h2;
            Hunter multi = h1 * h2;
            Hunter division = h1 / h2;
            Console.WriteLine("-----------------------PLUS-------------------------------");
            Console.WriteLine("New Hunter:");
            Console.WriteLine(plus.ShowChar());

            Console.WriteLine("-----------------------MINUS-------------------------------");
            Console.WriteLine("New Hunter:");
            Console.WriteLine(minus.ShowChar());

            Console.WriteLine("-----------------------MULTIPLICATION-------------------------------");
            Console.WriteLine("New Hunter:");
            Console.WriteLine(multi.ShowChar());

            Console.WriteLine("-----------------------DIVISION-------------------------------");
            Console.WriteLine("New Hunter:");
            Console.WriteLine(division.ShowChar());

            Console.WriteLine("-----------------------COMPARE-------------------------------");
            Console.Write("Is plus > h2?  "); Console.WriteLine(plus > h2);
            Console.Write("Is h2 < multi?  "); Console.WriteLine(h2 < multi);
            Console.Write("Is h2 = h1?  "); Console.WriteLine(h2 == h1);
            Console.Write("Is h2 != division?  "); Console.WriteLine(h2 != division);
            Console.WriteLine("*************You are out of override logic******************");
            //******************************************************************************************************3)


            //4)------------------------------------------------------------------------------------------------------
            Console.WriteLine("\n\n Now lets talk about patterns...");
            Console.WriteLine("Singleton pattern combined with Memento is becoming... Creating of Epic Boss");
            
            //Singleton
            EpicBoss epicboss = EpicBoss.getInstance("Baltozor");
            EpicBoss epicboss2 = EpicBoss.getInstance("Mangorn");
            
            if (epicboss2 == null) Console.WriteLine("This is my realisation of Singleton (and it's works:D)\n");

            //Memento
            Creator God = new Creator();
            epicboss.ShowLevel(); Console.WriteLine("Lets save it!!!");
            epicboss.SaveLevel(God);
            epicboss.DecreaseLevel(1);
            epicboss.ShowLevel();
            epicboss.LoadLevel(God);
            epicboss.ShowLevel();
            //------------------------------------------------------------------------------------------------------4)

            Object[] array = { sh1, sh2, h1, h2 };
            foreach (Object o in array)
                if (o is Fighter)
                    ((Fighter)o).ToString();
        }



        
    }

