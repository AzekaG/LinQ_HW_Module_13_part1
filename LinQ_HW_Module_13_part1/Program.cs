using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


/*
Задание 1:
Реализуйте пользовательский тип Фирма. В нём должна быть
информация о названии фирмы, дате основания, профиле
бизнеса (маркетинг, IT, и т. д.), ФИО директора, количество
сотрудников, адрес.
Для массива фирм реализуйте следующие запросы:
 Получить информацию обо всех фирмах
 Получить фирмы, у которых в названии есть слово Food
 Получить фирмы, которые работают в области маркетинга
 Получить фирмы, которые работают в области маркетинга
или IT
 Получить фирмы с количеством сотрудников, большем 100
 Получить фирмы с количеством сотрудников в диапазоне от
100 до 300
 Получить фирмы, которые находятся в Лондоне
 Получить фирмы, у которых фамилия директора White
 Получить фирмы, которые основаны больше двух лет назад
 Получить фирмы со дня основания, которых прошло 123 дня
ДОМАШНЕЕ ЗАДАНИЕ
2
 Получить фирмы, у которых фамилия директора Black и
название фирмы содержит слово White*/


/*Задание 2:
Реализуйте запросы из первого задания с использованием синтаксиса методов расширений.*/

/*Добавьте к первому заданию класс, содержащий информацию о сотрудниках. Нужно хранить такие данные:
 ФИО сотрудника
 Должность
 Контактный телефон
 Email
 Заработная плата
Добавьте информацию о сотрудниках внутрь фирмы.
Для массива сотрудников фирмы реализуйте следующие запросы:
 Получить всех сотрудников конкретной фирмы
 Получить всех сотрудников конкретной фирмы, у которых заработные платы больше заданной
 Получить сотрудников всех фирм, у которых должность менеджер
 Получить сотрудников, у которых телефон начинается с 23
 Получить сотрудников, у которых Email начинается с di
 Получить сотрудников, у которых имя Lionel*/

namespace LinQ_HW_Module_13_part1
{
    class Employer
    {
       
        private static readonly string[] names = {"Roland Bennett" ,"Diominick Parker","Uthman Foster","Bryant Jackson","Valente Barnes",
"Gunnar Moore","Dominick Griffin","Kendrick Perry","Juan Butler","Yash Reed","Collin Watson","Xerxes Scott","Bruno Mitchell","Trey Thompson",
"Ulric White","Ramon Campbell","Chance Brown","Thatcher Rodriguez","Lionel Smith","Torin Stewart","Moses Rodriguez","Nicolas Roberts",
"Wyatt Patterson","Briggs Cox","Boston Nelson","Aaron Hernandez","DiAxel Collins","Leo Barnes","Malik Thompson","Xiomar Alexander","Abraham Baker","Archer Roberts","Flynn Ramirez",
"Zaine Rivera","Winston Gray","Maximus Diaz","DiLionel Gray","Vincenzo Evans","Quintin Ross","Dexter Bennett","Pedro Richardson","Bronson Adams","Patrick Barnes",
"Ivan Ward","Graham Cooper","Donovan Torres","Lionel Alexander","Zeppelin Sanchez","Ibrahim Brown" };

        private static readonly string[] jobsTitle = { "Tax Examiner", "Sailor", "translator", "artist", "Cashier", "Fireman", "Mechanic", "Marketer", "Manager" };




        public string Name { set; get; }
        public string JobTitle { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int Salary { set; get; }
        Employer() { }
        public Employer(Random random)
        {
            Name = names[random.Next(0, names.Length)];
            JobTitle = jobsTitle[random.Next(0, jobsTitle.Length)];
            PhoneRand(random);
            MailRand(random);
            Salary = random.Next(600, 1800) / 100 * 100;

        }


        void PhoneRand(Random random)
        {
            int[] arr = { 244, 23, 38063, 3800 };
            Phone = "+" + (arr[random.Next(arr.Length)] + random.Next(999999, 99999999)).ToString();
        }
        void MailRand(Random random)
        {
            string[] arr = { "gmail.com", "i.ua", "ZohoNow.Com", "mailbox.com", "fastmail.com", "Outlook.com", "Yahoo.com" };
            Email = (Name + random.Next(int.Parse(Phone) % 10000 / 2).ToString() + "@" + arr[random.Next(arr.Length - 1)]).Replace(' ', '_');

        }
        public void ShowInfoEmployer()
        {
            Console.WriteLine("Name : " + Name);
            Console.WriteLine("Job Title : " + JobTitle);
            Console.WriteLine("Phone : " + Phone);
            Console.WriteLine("Email : " + Email);
            Console.WriteLine("Salary : " + Salary);
            Console.WriteLine();
        }

    }


    class Firm
    {
        public Random random = new Random();
        public List<Employer> employerList;
        public string NameFirm { get; set; }
        public DateTime FoundingDate { get; set; }
        public string Profile { get; set; }
        public string DirectorName { get; set; }
        public int EmployersAmount { get; set; }
        public string Adress { get; set; }
        public Firm() { }
        public Firm(string nameFirm, DateTime dateFounding, string profile, string directorName, int employersAmount, string adress)
        {
            this.NameFirm = nameFirm;
            this.FoundingDate = dateFounding;
            this.Profile = profile;
            this.DirectorName = directorName;
            this.EmployersAmount = employersAmount;
            this.Adress = adress;
            iniEmployerListRandom();
        }
        private void iniEmployerListRandom()
        {
            employerList = new List<Employer>();
            for (int i = 0; i < EmployersAmount; i++)
            {
                
                employerList.Add(new Employer(random));

            }
        }
        public void OutputInfo()
        {
            Console.WriteLine("Name : " + NameFirm);
            Console.WriteLine("Founding Date : " + FoundingDate.ToShortDateString());
            Console.WriteLine("Profile : " + Profile);
            Console.WriteLine("Director : " + DirectorName);
            Console.WriteLine("Amount of employers : " + EmployersAmount);
            Console.WriteLine("Adress : " + Adress);
            Console.WriteLine();

        }
    }

    class Holding
    {
        public List<Firm> FirmList;
        public Holding() { FirmList = new List<Firm>(); }
        public void AddFirm(Firm firm) => FirmList.Add(firm);
        public void OutputFirn()
        {
            foreach (Firm firm in FirmList)
            {
                firm.OutputInfo();
            }
        }

    }


    class ClientInterface
    {
        Holding holding;
        public ClientInterface() { holding = new Holding(); }
        public ClientInterface(Holding holding) { this.holding = holding; }

        public void Menu_Main()
        {
            Console.WriteLine("Choose an action : ");
            Console.WriteLine("Task 1- LINQ ");
            Console.WriteLine("Task 2- Extension method");
            Console.WriteLine("Task 3 -INFO BY EMLOYERS");
            Console.WriteLine("0-Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Menu_1();
                    break;
                case 2:
                    Menu_2();
                    break;
                case 3:
                    Menu_3();
                    break;



            }
        }
        public int Menu()
        {
           
            Console.WriteLine("Choose an Option : ");
            Console.WriteLine("1-Take info about all Firms");
            Console.WriteLine("2-Take firms with words \"Food\" in Firm Name");
            Console.WriteLine("3-Take firms with profile Marketing ");
            Console.WriteLine("4-Take firms with profile Marketing or IT");
            Console.WriteLine("5-Take firms with Amount Employers > 100");
            Console.WriteLine("6-Take firms with   100 < Amount Employers < 300");
            Console.WriteLine("7-Take firms in London");
            Console.WriteLine("8-Take firms with Director Surname White");
            Console.WriteLine("9-Take firms with date of Founding > 2 years ago");
            Console.WriteLine("10-Take firms with date of Founding > 123 days ago");
            Console.WriteLine("11-Take firms with director name Black && name firm which contains *white*");

            Console.WriteLine("0-Exit");
            int res = int.Parse(Console.ReadLine());
            Console.Clear();
            return res;


        }

      
        public void Menu_1()
        {
            int choice = 0;
            do
            {
               
                choice = Menu();
               
                switch (choice)
                {
                    case 1:
                        {
                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            var request = from el in holding.FirmList
                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }
                           
                        }
                        break;
                    case 2:
                        {
                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          where el.NameFirm.Contains("Food")
                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }
                        }
                        break;



                    case 3:
                        {
                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          where el.Profile == "Marketing"
                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }
                        }
                        break;
                    case 4:
                        {
                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          where el.Profile.Contains("IT") || el.Profile.Contains("Marketing")

                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }
                        }
                        break;
                    case 5:
                        {
                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          where el.EmployersAmount > 100
                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }


                        }
                        break;
                    case 6:
                        {
                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          where el.EmployersAmount > 100
                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }


                        }
                        break;
                    case 7:
                        {
                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          where el.Adress.Contains("London")
                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }


                        }
                        break;
                    case 8:
                        {
                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          where el.EmployersAmount > 100
                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }


                        }
                        break;
                    case 9:
                        {


                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          where (DateTime.Now - el.FoundingDate).TotalDays > 730
                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }


                        }
                        break;
                    case 10:
                        {


                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          where (DateTime.Now - el.FoundingDate).TotalDays > 123
                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }


                        }
                        break;
                    case 11:
                        {


                            int count = 0;
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          where el.NameFirm.Contains("White") && el.DirectorName.Contains("Black")
                                          select el;
                            foreach (var el in request)
                            {
                                Console.Write(++count + " : ");
                                el.OutputInfo();
                            }


                        }
                        break;
                    case 0: { } break;

                }


            } while (choice != 0);
        }
       
        public void Menu_2()
        {
            int choice = 0;
            do
            {
                choice = Menu();
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            foreach (var el in holding.FirmList) el.OutputInfo();
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var result = holding.FirmList.Where(i => i.NameFirm.Contains("Food"));
                            foreach (var el in result)
                            {
                                el.OutputInfo();
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            foreach (var i in holding.FirmList.Where(i => i.Profile == "Marketing"))
                                i.OutputInfo();
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            foreach (var i in holding.FirmList.Where(i => (i.Profile == "Marketing" || i.Profile == "IT")))
                                i.OutputInfo();

                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            foreach (var i in holding.FirmList.Where(i => i.EmployersAmount > 100))
                                i.OutputInfo();
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            foreach (var i in holding.FirmList.Where(i => i.EmployersAmount > 100 && i.EmployersAmount < 300))
                                i.OutputInfo();
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            foreach (var i in holding.FirmList.Where(i => i.Adress.Contains("London")))
                                i.OutputInfo();

                        }
                        break;
                    case 8:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            foreach (var i in holding.FirmList.Where(i => i.DirectorName.Contains("White")))
                                i.OutputInfo();
                        }
                        break;
                    case 9:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            foreach (var i in holding.FirmList.Where(i => (DateTime.Now - i.FoundingDate).TotalDays > 730))
                                i.OutputInfo();
                        }
                        break;
                    case 10:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            foreach (var i in holding.FirmList.Where(i => (DateTime.Now - i.FoundingDate).TotalDays > 123))
                                i.OutputInfo();
                        }
                        break;
                    case 11:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            foreach (var i in holding.FirmList.Where(i => i.DirectorName.Contains("Black") && i.NameFirm.Contains("White")))
                                i.OutputInfo();
                        }
                        break;
                    
                    case 0: { } break;

                }
            } while (choice != 0);
        }

        public void Menu_3()
        {
            int choice;
            do
            {
                Console.WriteLine("Choose an action : ");
                Console.WriteLine("1-Show all Employers by firm : ");
                Console.WriteLine("2-Show Employers by firm with salary mor than : ");
                Console.WriteLine("3-show Employers managers by all firm");
                Console.WriteLine("4-Show Employers with Phone Number which starts with 23");
                Console.WriteLine("5-show Employers with Email which starts with Di");
                Console.WriteLine("6-Show Employers with name Lionel");
                Console.WriteLine("0-Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            int count = 0;
                            Console.Clear();
                            Console.WriteLine("Choose a Firm : ");
                            foreach (var el in holding.FirmList)
                                Console.WriteLine(++count + " . " + el.NameFirm);
                            int localchoice = int.Parse(Console.ReadLine());
                            var request = from el in holding.FirmList[localchoice - 1].employerList
                                          select el;
                            count = 0;
                            foreach (var el in request)
                            { Console.WriteLine(++count); el.ShowInfoEmployer(); }

                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            int count = 0;
                            Console.WriteLine("Choose a firm : ");
                            foreach (var el in holding.FirmList)
                                Console.WriteLine(++count + " . " + el.NameFirm);
                            int localchoice = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter a salary for segragate ( 1800 max salary ");
                            int temp = int.Parse(Console.ReadLine());
                            var request = from el in holding.FirmList[localchoice].employerList
                                          where el.Salary > temp
                                          select el;
                            count = 0;
                            foreach (var el in request)
                            { Console.WriteLine(++count); el.ShowInfoEmployer(); }


                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          from tempEl in el.employerList
                                          where tempEl.JobTitle == "Manager"
                                          select tempEl;
                            int count = 0;
                            foreach (var el in request)
                            { Console.WriteLine(++count); el.ShowInfoEmployer(); }



                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          from tempEl in el.employerList
                                          where tempEl.Phone.StartsWith("+23")
                                          select tempEl;
                            int count = 0;
                            foreach (var el in request)
                            { Console.WriteLine(++count); el.ShowInfoEmployer(); }

                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          from tempEl in el.employerList
                                          where tempEl.Email.StartsWith("Di")
                                          select tempEl;
                            int count = 0;
                            foreach (var el in request)
                            { Console.WriteLine(++count); el.ShowInfoEmployer(); }
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.Clear();
                            var request = from el in holding.FirmList
                                          from tempEl in el.employerList
                                          where tempEl.Name.Contains("Lionel")
                                          select tempEl;
                            int count = 0;
                            foreach (var el in request)
                            { Console.WriteLine(++count); el.ShowInfoEmployer(); }
                        }
                        break;

                }



            } while (choice != 0);
        }




        internal class Program
        {
            static void Main(string[] args)
            {


                Firm firm1 = new Firm("Prestige auto", DateTime.Parse("15.01.1995"), "Auto", "Santino Sanchez", 277, "London");
                Firm firm2 = new Firm("Champion", DateTime.Parse("19.10.1999"), "Sport", "Harlow Roberts", 80, "Odessa");
                Firm firm3 = new Firm("Hotline White", DateTime.Parse("22.12.2021"), "Finance", "Ulyses Black", 80, "Poland");
                Firm firm4 = new Firm("CHP", DateTime.Parse("19.10.2023"), "Marketing", "Seamus Smith", 350, "England");
                Firm firm5 = new Firm("Estro", DateTime.Parse("02.05.2015"), "Food", "Ulyses Black", 180, "Mexico");
                Firm firm6 = new Firm("Smile Food", DateTime.Parse("10.10.1999"), "Food", "Quillen Bailey", 880, "Kyiw");
                Firm firm7 = new Firm("SG Soft", DateTime.Parse("15.05.2020"), "IT", "Ozzy White", 451, "Madrid");
                Firm firm8 = new Firm("SGC CO", DateTime.Parse("12.05.2010"), "IT", "Ozzy Bozzorn", 333, "Kyiw");
                Holding holding = new Holding();
                holding.AddFirm(firm1);
                holding.AddFirm(firm2);
                holding.AddFirm(firm3);
                holding.AddFirm(firm4);
                holding.AddFirm(firm5);
                holding.AddFirm(firm6);
                holding.AddFirm(firm7);
                holding.AddFirm(firm8);


                ClientInterface clientInterface = new ClientInterface(holding);
                clientInterface.Menu_Main();
            }

        }
    }
}
