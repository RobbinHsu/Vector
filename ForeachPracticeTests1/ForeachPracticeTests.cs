using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;

namespace Paractice.Tests
{
    [TestClass]
    public class ForeachPracticeTests
    {
        [TestMethod]
        public void WhereAgeMoreThen30()
        {
            var people = new List<Person>
            {
                new Person {Name = "Ada", Sex = "Female", Age = 18},
                new Person {Name = "Joey", Sex = "Man", Age = 45},
                new Person {Name = "Tom", Sex = "Man", Age = 33}
            };


            IList<string> list = new List<string>();
            var actual = people.Where(person => person.Age > 30).ToList();
            var expected = people.Where(person => person.Age > 30).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }
}