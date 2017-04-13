using System;


   partial class Hunter : Fighter, Sneaking
    {

       public override int GetHashCode()
       {
           return (int)(Strength+Agility+Intillegence);
       }
       public bool IsNightVision(Hunter h)
       {
           return NightVision == true;
       }

       public void BeginHunt()
       {
           Console.WriteLine("Hunting is go on!");
       }
       public void DistanceAttack()
       {
           Console.WriteLine("The arrow fly!");
       }

       public void SneakChance()
       {
           Console.WriteLine("You sneak chanse is: {0}%", Agility*0.5);
       }
       public string ShowChar()
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

       public override bool WriteToFile(){
           System.IO.File.WriteAllText(@"e:\4 семестр\c#\2\Hunter.txt", ToFile);
           return true;
       }

       delegate void MyDelegate();
       public void UsingDelegate()
       {
           MyDelegate ToString = () => Console.WriteLine("Hunter Class from lambda function");
           ToString();
       }
       
       //проверка является ли объект охотником
       public static bool IsHunter(Object obj)
       {
           if (obj is Hunter) return true;
           return false;
       }

       public static Hunter operator +(Hunter hun1, Hunter hun2)
       {
           Hunter buf = new Hunter();
           buf.Agility = hun1.Agility + hun2.Agility; 
           buf.Strength = hun1.Strength + hun2.Strength; 
           buf.Intillegence = hun1.Intillegence + hun2.Intillegence;
           buf.Speed = hun1.Speed + hun2.Speed;
           buf.Attack = hun1.Attack + hun2.Attack;
           buf.Armor = hun1.Attack + hun2.Attack;
           return buf;
   }

       public static Hunter operator -(Hunter hun1, Hunter hun2)
       {
           Hunter buf = new Hunter();
           buf.Agility = hun1.Agility - hun2.Agility;
           buf.Strength = hun1.Strength - hun2.Strength;
           buf.Intillegence = hun1.Intillegence - hun2.Intillegence;
           buf.Speed = hun1.Speed - hun2.Speed;
           buf.Attack = hun1.Attack - hun2.Attack;
           buf.Armor = hun1.Attack - hun2.Attack;
           return buf;
       }

       public static Hunter operator *(Hunter hun1, Hunter hun2)
       {
           Hunter buf = new Hunter();
           buf.Agility = hun1.Agility * hun2.Agility;
           buf.Strength = hun1.Strength * hun2.Strength;
           buf.Intillegence = hun1.Intillegence * hun2.Intillegence;
           buf.Speed = hun1.Speed * hun2.Speed;
           buf.Attack = hun1.Attack * hun2.Attack;
           buf.Armor = hun1.Attack * hun2.Attack;
           return buf;
       }

       public static Hunter operator /(Hunter hun1, Hunter hun2)
       {
           Hunter buf = new Hunter();
           buf.Agility = hun1.Agility / hun2.Agility;
           buf.Strength = hun1.Strength / hun2.Strength;
           buf.Intillegence = hun1.Intillegence / hun2.Intillegence;
           buf.Speed = hun1.Speed / hun2.Speed;
           buf.Attack = hun1.Attack / hun2.Attack;
           buf.Armor = hun1.Attack / hun2.Attack;
           return buf;
       }
       public static bool operator >(Hunter hun1, Hunter hun2)
       {
           if (hun1.GetHashCode() > hun2.GetHashCode()) return true;
           return false;
       }

       public static bool operator <(Hunter hun1, Hunter hun2)
       {
           if (hun1.GetHashCode() < hun2.GetHashCode()) return true;
           return false;
       }

       public static bool operator ==(Hunter hun1, Hunter hun2)
       {
           if (hun1.GetHashCode() == hun2.GetHashCode()) return true;
           return false;
       }

       public static bool operator !=(Hunter hun1, Hunter hun2)
       {
           if (hun1.GetHashCode() != hun2.GetHashCode()) return true;
           return false;
       }
    }

