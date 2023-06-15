using Homework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public class UnitTest1
    {
        private List<Person> people;
        private PersonRepository personRepository;

        [SetUp]
        public void Setup()
        {
            people = new List<Person>()
            {
                new Person("John", "Doe", new DateTime(1990, 1, 1), "AB1234567890"),
                new Person("Jane", "Smith", new DateTime(1985, 5, 10), "CD2345678901"),
                new Person("Bob", "Johnson", new DateTime(1995, 7, 15), "EF3456789012"),
                new Person("John", "Smith", new DateTime(1992, 3, 20), "GH4567890123"),
                new Person("John", "Doe", new DateTime(1988, 9, 5), "IJ5678901234")
            };

            personRepository = new PersonRepository(people);
        }

        [Test]
        public void GetByFirstName_ExistingPersonWithUniqueFirstName_ReturnsPerson()
        {
            // Arrange

            // Act
            var result = personRepository.GetByFirstName("Jane");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("Jane", result[0].FirstName);

        }

        [Test]
        public void GetByFirstName_NonExistingPerson_ReturnsEmptyList()
        {
            // Arrange

            // Act
            var result = personRepository.GetByFirstName("Alice");

            // Assert
            Assert.IsEmpty(result);
        }
        [Test]
        public void GetByFirstName_MultiplePeopleWithSameFirstName_ReturnsAllPeople()
        {
            // Arrange

            // Act
            var result = personRepository.GetByFirstName("John");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.True(result.All(person => person.FirstName == "John"));

        }

        [Test]
        public void GetByLastName_ExistingPersonWithUniqueLastName_ReturnsPerson()
        {
            // Arrange

            // Act
            var result = personRepository.GetByLastName("Doe");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("Doe", result[0].LastName);
        }
        [Test]
        public void GetByLastName_MultiplePeopleWithSameLastName_ReturnsAllPeople()
        {
            // Arrange

            // Act
            var result = personRepository.GetByLastName("Doe");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.True(result.All(person => person.LastName == "Doe"));
        }

        [Test]
        public void GetByLastName_NonExistingPerson_ReturnsEmptyList()
        {
            // Arrange

            // Act
            var result = personRepository.GetByLastName("Brown");

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetById_ExistingPerson_ReturnsPerson()
        {
            // Arrange

            // Act
            var result = personRepository.GetById("CD2345678901");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("CD2345678901", result.ID);
        }

        [Test]
        public void GetById_NonExistingPerson_ReturnsNull()
        {
            // Arrange

            // Act
            var result = personRepository.GetById("XYZ1234567890");

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void Add_NewPerson_PersonAddedToList()
        {
            // Arrange
            var newPerson = new Person("Alice", "Brown", new DateTime(2000, 3, 20), "KL6789012345");

            // Act
            var result = personRepository.Add(newPerson); // result - bool type 

            // Assert
            Assert.True(result); // check if result = true - means that the person didn't exist in people repo and it will be added
            Assert.Contains(newPerson, people); // check if the person was added to people list
        }

        [Test]
        public void Add_ExistingPerson_ReturnsFalse_PersonNotAddedToList()
        {
            // Arrange
            var existingPerson = new Person("John", "Doe", new DateTime(1990, 1, 1), "AB1234567890");

            // Act
            var result = personRepository.Add(existingPerson);

            // Assert
            Assert.False(result); // // check if result = false - means that the person does exist in people repo and it will NOT be added
        }




    }
}
