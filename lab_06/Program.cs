using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace lab_06;
public class User
{
    public string Name { get; set; }
    public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
    public int Age { get; set; }
    public int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
    public DateTime? CreatedAt { get; set; }
    public DateTime? RemovedAt { get; set; }
    public User(string name, string role, int age, int[] marks, DateTime? createdat, DateTime? removedat)
    {
        Name = name;
        Role = role;
        Age = age;
        Marks = marks;
        CreatedAt = createdat;
        RemovedAt = removedat;
    }
    public User()
    {

    }
}
class Program
{
    static public void Main(String[] args)
    {
        User user1 = new User("Leonard", "ADMIN", 30, null, DateTime.Parse("2015-01-01"), null);
        User user2 = new User("Giselle", "MODERATOR", 27, null, DateTime.Parse("2016-01-01"), null);
        User user3 = new User("Jonathan", "MODERATOR", 32, null, DateTime.Parse("2016-03-01"), null);
        User user4 = new User("Peyton", "TEACHER", 36, null, DateTime.Parse("2017-01-01"), null);
        User user5 = new User("Lily", "TEACHER", 30, null, DateTime.Parse("2017-11-01"), null);
        User user6 = new User("Priscilla", "TEACHER", 39, null, DateTime.Parse("2018-03-01"), null);
        User user7 = new User("Ruby", "STUDENT", 20, new int[] { 3, 4, 3, 2, 3 }, DateTime.Parse("2017-01-01"), null);
        User user8 = new User("Phoenix", "STUDENT", 21, new int[] { 5, 4, 5, 5, 4, 3, 3 }, DateTime.Parse("2018-01-01"), null);
        User user9 = new User("Pierce", "STUDENT", 23, new int[] { 3, 3, 2, 2, 2, 2 }, DateTime.Parse("2020-01-01"), DateTime.Parse("2021-01-01"));
        User user10 = new User("Lydia", "STUDENT", 20, new int[] { 3, 4, 3, 2, 3 }, DateTime.Parse("2017-01-01"), null);
        User user11 = new User("Kenneth", "STUDENT", 20, new int[] { 5, 5, 4, 5, 5, 5, 4 }, DateTime.Parse("2017-02-01"), null);
        User user12 = new User("Grace", "STUDENT", 21, new int[] { 3, 4, 3, 2, 3 }, DateTime.Parse("2017-02-01"), null);
        User user13 = new User("Ryann", "STUDENT", 23, new int[] { 3, 5, 4, 5, 2, 3 }, DateTime.Parse("2017-03-01"), null);
        User user14 = new User("Kaitlyn", "STUDENT", 26, new int[] { 4, 4, 5, 4, 4, 4, 5 }, DateTime.Parse("2017-01-01"), null);
        User user15 = new User("Zayne", "STUDENT", 22, new int[] { 2, 3, 2, 3, 4, 3, 3 }, DateTime.Parse("2018-11-01"), null);
        User user16 = new User("America", "STUDENT", 21, new int[] { 2, 2, 2, 3, 2, 2 }, DateTime.Parse("2017-01-01"), DateTime.Parse("2018-04-01"));
        User user17 = new User("Ali", "STUDENT", 20, new int[] { 3, 3, 3, 4, 4, 3, 5, 5 }, DateTime.Parse("2018-01-04"), null);
        User user18 = new User("Hayden", "STUDENT", 26, new int[] { 5, 5, 5, 5, 5, 5, 5, 4 }, DateTime.Parse("2019-03-12"), null);
        User user19 = new User("Myles", "STUDENT", 22, new int[] { 5, 4, 5, 4, 3, 3, 3, 5 }, DateTime.Parse("2019-06-21"), null);
        User user20 = new User("Bailey", "STUDENT", 28, new int[] { 2, 3, 3, 4, 4, 5, 4, 5 }, DateTime.Parse("2019-02-20"), null);
        User[] users = new User[] { user1, user2, user3, user4, user5, user6, user7, user8, user9, user10, user11, user12, user13, user14, user15, user16, user17, user18, user19, user20 };

        var query1 = (from user in users select user).Count();
        Console.WriteLine("1. Ilość rekordów w tablicy: " + query1);
        Console.WriteLine();

        var query2 = from user in users select user;
        Console.WriteLine("2. Lista nazw użytkowników: ");
        foreach (var user in query2)
        {
            Console.WriteLine(user.Name);
        }
        Console.WriteLine();

        var query3 = from user in users orderby user.Name select user; ;
        Console.WriteLine("3. Posortowane po nazwach: ");
        foreach (var user in query3)
        {
            Console.WriteLine(user.Name);
        }
        Console.WriteLine();

        var query4 = (from user in users select user.Role).Distinct();
        Console.WriteLine("4. Lista dostępnych ról: ");
        foreach (var user in query4)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();

        var query5 = from user in users orderby user.Role select user;
        Console.WriteLine("5. Pogrupowane po rolach: ");
        foreach (var user in query5)
        {
            Console.WriteLine(user.Name + ", " + user.Role);
        }
        Console.WriteLine();

        var query6 = (from user in users where user.Marks is not null && user.Marks.Count() > 0 select user).Count();
        Console.WriteLine("6. Ilość rekordów, dla których podano oceny: " + query6);
        Console.WriteLine();

        var query7 = from user in users where user.Role == "STUDENT" select user;
        Console.WriteLine("7. Suma, ilość i średnia ocen studentów: ");
        foreach (var user in query7)
        {
            Console.WriteLine(user.Name + " - Suma: " + user.Marks.Sum() + ", Ilość: " + user.Marks.Count() + ", Średnia: " + user.Marks.Average());
        }
        Console.WriteLine();

        var query8 = from user in users where user.Role == "STUDENT" select user;
        int max = 0;
        foreach (var user in query8)
        {
            if (max < user.Marks.Max())
            {
                max = user.Marks.Max();
            }
        }
        Console.WriteLine("8. Najwyższa ocena: " + max);
        Console.WriteLine();
        var query9 = from user in users where user.Role == "STUDENT" select user;
        int min = 5;
        foreach (var user in query9)
        {
            if (min > user.Marks.Min())
            {
                min = user.Marks.Min();
            }
        }
        Console.WriteLine("9. Najniższa ocena: " + min);
        Console.WriteLine();

        var query10 = (from user in users where user.Role == "STUDENT" orderby user.Marks.Average() descending select user).Take(1);
        foreach (var user in query10)
        {
            Console.WriteLine("10. Najlepszy student: " + user.Name) ;
        }        
        Console.WriteLine();

        var query11 = (from user in users
                       where user.Role == "STUDENT" 
                       && user.Marks.Length == (from userr in users where userr.Role == "STUDENT" orderby userr.Marks.Length select userr.Marks.Length).Min()
                       select user);
        Console.WriteLine("11. Studenci z najmniejszą liczbą ocen: ");
        foreach (var user in query11)
        {
            Console.WriteLine(user.Name);
        }
        Console.WriteLine();
        var query12 = (from user in users
                       where user.Role == "STUDENT"
                       && user.Marks.Length == (from userr in users where userr.Role == "STUDENT" orderby userr.Marks.Length select userr.Marks.Length).Max()
                       select user);
        Console.WriteLine("12. Studenci z największą liczbą ocen: ");
        foreach (var user in query12)
        {
            Console.WriteLine(user.Name);
        }
        Console.WriteLine();

        Console.WriteLine("13. Lista obiektów zawierających tylko nazwę i średnią ocenę: ");
        var query13 = from user in users where user.Marks is not null select new { Name = user.Name, Average = user.Marks.Average() };
        foreach (var user in query13)
        {
            Console.WriteLine(user.Name + " - " + user.Average);
        }
        Console.WriteLine();

        var query14 = from user in users where user.Role == "STUDENT" orderby user.Marks.Average() descending select user;
        Console.WriteLine("14. Studenci posortowani od najlepszego: ");
        foreach (var user in query14)
        {
            Console.WriteLine(user.Name + " - " + user.Marks.Average());
        }
        Console.WriteLine();

        var query15 = (from user in users where user.Role == "STUDENT" select user.Marks.Average()).Average();
        Console.WriteLine("15. Średnia ocena wszystkich studentów: " + query15);
        Console.WriteLine();

        var query16 = from user in users group user by (user.CreatedAt.Value.Year, user.CreatedAt.Value.Month) into gr orderby gr.Key select gr;
        Console.WriteLine("16. Studenci pogrupowani po miesiącach daty utworzenia: ");
        foreach (var group in query16)
        {
            Console.Write(group.Key.Year + "-" + group.Key.Month.ToString("00"));
            foreach (var user in group)
            {
                Console.Write(" " + user.Name + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        var query17 = from user in users where user.RemovedAt is null select user;
        Console.WriteLine("17. Użytkownicy, którzy nie zostali usunięci: ");
        foreach (var user in query17)
        {
            Console.WriteLine(user.Name);
        }
        Console.WriteLine();

        var query18 = (from user in users orderby user.CreatedAt descending select user).Take(1);
        foreach (var user in query18)
        {
            Console.WriteLine("18. Najnowszy student: " + user.Name);
        }
        Console.WriteLine();

        /////////////////////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("Zad 3.");
        Console.WriteLine();

        ///////////////////////////////////////JSON//////////////////////////////////////////////////////
        
        Console.WriteLine("Serializacja listy użytkowników Json");
        string serializelist = JsonSerializer.Serialize(users);
        Console.WriteLine(serializelist);
        Console.WriteLine();

        Console.WriteLine("Serializacja użytkownika Json");
        string serializeuser1 = JsonSerializer.Serialize(user1);
        Console.WriteLine(serializeuser1);
        Console.WriteLine();

        Console.WriteLine("Deserializacja listy użytkowników Json");
        User[] deserializelist = JsonSerializer.Deserialize<User[]>(serializelist);
        foreach (User user in deserializelist)
        {
            Console.WriteLine("Name: " + user.Name +
            ", Role: " + user.Role +
            ", Age: " + user.Age +
            ", Marks: " + user.Marks +
            ", CreatedAt: " + user.CreatedAt +
            ", RemovedAt: " + user.RemovedAt);
        }
        Console.WriteLine();

        Console.WriteLine("Deserializacja użytkownika Json");
        User deserializeuser1 = JsonSerializer.Deserialize<User>(serializeuser1);
        Console.WriteLine("Name: " + deserializeuser1.Name +
            ", Role: " + deserializeuser1.Role +
            ", Age: " + deserializeuser1.Age +
            ", Marks: " + deserializeuser1.Marks +
            ", CreatedAt: " + deserializeuser1.CreatedAt +
            ", RemovedAt: " + deserializeuser1.RemovedAt);
        Console.WriteLine();

        ///////////////////////////////////////XML//////////////////////////////////////////////////////

        Console.WriteLine("Serializacja listy użytkowników xml");
        XmlSerializer xmlserializelist = new XmlSerializer(typeof(User[]));
        using (MemoryStream stream = new MemoryStream())
        {
            xmlserializelist.Serialize(stream, users);
            stream.Flush();
            string xmllist = Encoding.UTF8.GetString(stream.ToArray());
            Console.WriteLine(xmllist);
            Console.WriteLine();
            Console.WriteLine("Deserializacja listy użytkowników xml");
            byte[] bytes = Encoding.UTF8.GetBytes(xmllist);
            XmlSerializer xmldeserializelist = new XmlSerializer(typeof(User[]));
            using (MemoryStream stream1 = new MemoryStream(bytes))
            {
                User[] xmldeserializedlist = (User[]) xmldeserializelist.Deserialize(stream1);
                foreach (var user in users)
                {
                    Console.WriteLine("Name: " + user.Name +
                        ", Role: " + user.Role +
                        ", Age: " + user.Age +
                        ", Marks: " + user.Marks +
                        ", CreatedAt: " + user.CreatedAt +
                        ", RemovedAt: " + user.RemovedAt);
                }
            }
        }
        Console.WriteLine();

        Console.WriteLine("Serializacja użytkownika xml");
        XmlSerializer xmlserializeuser = new XmlSerializer(typeof(User));
        using (MemoryStream stream = new MemoryStream())
        {
            xmlserializeuser.Serialize(stream, user1);
            stream.Flush();
            string xmluser = Encoding.UTF8.GetString(stream.ToArray());
            Console.WriteLine(xmluser);
            Console.WriteLine();
            Console.WriteLine("Deserializacja użytkownika xml");
            byte[] bytes = Encoding.UTF8.GetBytes(xmluser);
            XmlSerializer xmldeserializeuser = new XmlSerializer(typeof(User));
            using (MemoryStream stream1 = new MemoryStream(bytes))
            {
                User xmldeserializeduser = (User) xmldeserializeuser.Deserialize(stream1);
                Console.WriteLine("Name: " + xmldeserializeduser.Name +
                    ", Role: " + xmldeserializeduser.Role +
                    ", Age: " + xmldeserializeduser.Age +
                    ", Marks: " + xmldeserializeduser.Marks +
                    ", CreatedAt: " + xmldeserializeduser.CreatedAt +
                    ", RemovedAt: " + xmldeserializeduser.RemovedAt);
            }
        }
        Console.WriteLine();
    }
}
