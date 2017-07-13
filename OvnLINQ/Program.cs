using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvnLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Personer och företag
            var persons = new List<Person>
            {
                new Person {Name = "Bo", Age = 35, WorkPlaceID = 1 },
                new Person {Name = "Petter", Age = 25, WorkPlaceID = 2 },
                new Person {Name = "Diar", Age = 28, WorkPlaceID = 2 },
                new Person {Name = "Fanny", Age = 23, WorkPlaceID = 3 },
                new Person {Name = "Li", Age = 44, WorkPlaceID = 3 }
            };

            var companies = new List<Workplace>
            {
                new Workplace {CompanyName = "Academy", WorkPlaceID = 1},
                new Workplace {CompanyName = "Ica", WorkPlaceID = 2},
                new Workplace {CompanyName = "Coop", WorkPlaceID = 3},

            };

            #endregion

            #region Personer över 30
            var personsOver30 = persons
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Age);

            foreach (var item in personsOver30)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Antal personer under 30
            var numberOfPeopleUndere30 = persons
                .Count(p => p.Age < 30);

            Console.WriteLine(numberOfPeopleUndere30);

            #endregion

            #region Snittålder på alla personer
            var averageAge = persons
                .Average(p => p.Age);
            Console.WriteLine(averageAge);

            #endregion

            #region Hitta person med ett visst namn
            var findPersonWithCertainName = persons
                .FirstOrDefault(p => p.Name == "Diar");
            Console.WriteLine(findPersonWithCertainName);


            #endregion

            #region Namn och arbetsplats
            var nameAndWorkPlaceName = companies
                .Join(persons, c => c.WorkPlaceID, p => p.WorkPlaceID, (c, p) => $"{p.Name}, {c.CompanyName}");

            foreach (var item in nameAndWorkPlaceName)
            {
                Console.WriteLine(item);
            }


            #endregion

            #region Hur många arbetar på varje arbetsplats?
            var howManyAreWorkingAtEachWorkPlace = companies
                .GroupJoin(persons, c => c.WorkPlaceID, p => p.WorkPlaceID, (c, p) => new
                {
                    workPlaceName = c.CompanyName,
                    count = p.Count()

                });

            foreach (var item in howManyAreWorkingAtEachWorkPlace)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Gruppera baserat på företag
            var allEmployees = companies
                .GroupJoin(persons, c => c.WorkPlaceID, p => p.WorkPlaceID, (c, p) => new
                {
                    WorkplaceName = c.CompanyName,
                    Names = p,

                });

            foreach (var item in allEmployees)
            {
                Console.WriteLine(item.WorkplaceName);
                foreach (var name in item.Names)
                {
                    Console.WriteLine(name.Name);
                }
                Console.WriteLine();
            }
            



            #endregion


        }
    }
}
