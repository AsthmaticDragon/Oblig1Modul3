using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Modul3
{
    public class FamilyApp
    {
        public string WelcomeMessage { get; set; }
        public List<Person> People { get; set; }
        public string CommandPrompt { get; set; }

        public FamilyApp(params Person[] people)
        {
            People = new List<Person>(people);
            WelcomeMessage = "Velkommen: ";
            foreach (var person in People)
            {
                WelcomeMessage += $"{person.FirstName}, ";
            }
            CommandPrompt =
                "hjelp => viser en hjelpetekst som forklarer alle kommandoene\r\n" +
                "liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. \r\nvis " +
                "<id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem) vis 3 \r\n";
        }

        public string HandleCommand(string command)
        {
            var splitCommand = command.Split(" ");
            if (command == "liste")
            {
                var response = "";
                foreach (var person in People)
                {
                    response += person.GetDescription();
                    response += "\n";
                }

                return response;
            }

            if (splitCommand[0].Contains("vis"))
            {
                var id = Convert.ToInt32(splitCommand[1]);
                Person thePerson = null;
                foreach (var person in People)
                {
                    if (person.Id!=id)continue;
                    thePerson = person;
                }

                if (thePerson == null) return CommandPrompt;
                var tekst = thePerson.GetDescription();
                var kids = FindChildren(thePerson);
                if (kids.Length == 0) return tekst;
                tekst += "\n  Barn:\n";
                return FindChildren(thePerson)
                    .Aggregate(tekst,
                        (current,
                            child) => current + $"    {child.FirstName} (Id={child.Id}) Født: {child.BirthYear}\n");
            }

            if (command == "hjelp") return CommandPrompt;

            return CommandPrompt;
        }

        public Person[] FindChildren(Person p)
        {
            var children = new List<Person>();
            foreach (var person in People)
            {
                if (p.Id == person.Father?.Id || p.Id == person.Mother?.Id)
                {
                    children.Add(person);
                }
            }

            return children.ToArray();
        }
    }
}
