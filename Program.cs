#region 1.5
using System;

struct Student
{
    private string family;
    private int passes;
    private int grade;

    public Student(string family, int passes, int grade)
    {
        this.family = family;
        this.passes = passes;
        this.grade = grade;
    }

    public string Family
    {
        get { return family; }
    }

    public int Passes
    {
        get { return passes; }
    }

    public int Grade
    {
        get { return grade; }
    }
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[]
        {
            new Student("Шерстобитова", 5, 4),
            new Student("Клименко    ", 10, 2),
            new Student("Крамер      ", 13, 2),
            new Student("Рудь        ", 9, 2)
        };
        for (int i = 0; i < students.Length - 1; i++)
        {
            for (int j = 0; j < students.Length - 1 - i; j++)
            {
                if (students[j].Passes < students[j + 1].Passes)
                {
                    Student temp = students[j]; students[j] = students[j + 1]; students[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Список неуспевающих студентов в порядке убывания их пропусков:");
        Console.WriteLine();
        Console.WriteLine("Фамилия \t" + "Пропуски \t");
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i].Grade == 2)
            {
                Console.WriteLine("{0} \t" + "{1} \t ", students[i].Family, students[i].Passes);
            }
        }
    }
}
#endregion

#region 2.5
using System;

struct Competitions
{
    private string name;
    private int meters;
    private int[] score;

    public Competitions(string name, int meters, int[] score)
    {
        this.name = name;
        this.meters = meters;
        this.score = score;
    }

    public int CalculateScore()
    {
        for (int i = 0; i < score.Length - 1; i++)
        {
            if (score[i] < score[i + 1])
            {
                int temp = score[i];
                score[i] = score[i + 1];
                score[i + 1] = temp;
            }
        }

        int totalScore = 0;
        for (int i = 1; i < score.Length - 1; i++)
        {
            totalScore += score[i];
        }

        int distancePoints = 60 + (meters - 120) * 2;
        totalScore += distancePoints;

        return totalScore;
    }

    public string Name
    {
        get { return name; }
    }

    public int Meters
    {
        get { return meters; }
    }
}

class Program
{
    static void Main()
    {
        Competitions[] competitions = new Competitions[]
        {
            new Competitions("Шерстобитова", 126, new int[] {18, 17, 16, 19, 20}),
            new Competitions("Рудь        ", 132, new int[] {16, 20, 15, 17, 16}),
            new Competitions("Букин       ", 115, new int[] {15, 16, 14, 17, 18}),
            new Competitions("Крамер      ", 133, new int[] {12, 16, 17, 19, 16}),
            new Competitions("Клименко    ", 125, new int[] {13, 15, 13, 17, 20})
        };

        for (int i = 0; i < competitions.Length; i++)
        {
            for (int j = 0; j < competitions.Length - 1 - i; j++)
            {
                if (competitions[j].CalculateScore() < competitions[j + 1].CalculateScore())
                {
                    Competitions temp = competitions[j];
                    competitions[j] = competitions[j + 1];
                    competitions[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Результаты соревнований:");
        Console.WriteLine("Фамилия \t" + "Очки\t");
        for (int i = 0; i < competitions.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {competitions[i].Name}\t{competitions[i].CalculateScore()}");
        }
    }
}
#endregion

#region 3.5
struct FootballTeam
{
    private string name; 
    private int Scored;
    private int Failed; 
    private int points;
    public FootballTeam(string name)
    {
        this.name = name;
        Scored = 0; Failed = 0;
        points = 0;
    }
    public string Name 
    { 
        get { return name; } 
        set { name = value; } 
    
    }
    public void Result(int scored, int conceded)
    {
        Scored += scored;
        Failed += conceded; if (scored > conceded)
            points += 3;
        else if (scored == conceded)
            points += 1;
    }
    public int Points 
    {
        get { return points; } 
    }
    public int Difference 
    { 
        get { return Scored - Failed; } 
    }
    public static void Print(FootballTeam[] teams)
    {
        Console.WriteLine("Место \t"+ "Команда \t"+ "Очки \t");
        for (int i = 0; i < teams.Length; i++)
        {
            Console.WriteLine("{0} \t" + "{1} \t" + "{2} \t",i + 1, teams[i].Name, teams[i].Points);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        FootballTeam[] teams = new FootballTeam[]        
        {
            new FootballTeam("Сморчи "),            
            new FootballTeam("Карби Бишники"),
            new FootballTeam("Дом чертей")        
        };
        Match(ref teams[0], ref teams[1]);
        Match(ref teams[0], ref teams[2]); Match(ref teams[1], ref teams[0]);
        Match(ref teams[1], ref teams[2]);
        Sort(teams); FootballTeam.Print(teams);
    }
    static void Match(ref FootballTeam team1, ref FootballTeam team2)
    {
        Random random = new Random(); 
        int scored = random.Next(0, 5);
        int conceded = random.Next(0, 5); 
        team1.Result(scored, conceded);
        team2.Result(conceded, scored);
    }
    static void Sort(FootballTeam[] teams)
    {
        int n = teams.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (teams[j].Points < teams[j + 1].Points || (teams[j].Points == teams[j + 1].Points && teams[j].Difference < teams[j + 1].Difference))
                {
                    FootballTeam temp = teams[j];
                    teams[j] = teams[j + 1]; teams[j + 1] = temp;
                }
            }
        }
    }
}
#endregion
