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

        [TestCase("Jane")]
        public void GetByFirstName_ExistingPersonWithUniqueFirstName_ReturnsPerson(string firstName)
        {
            // Act
            var result = personRepository.GetByFirstName(firstName);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(firstName, result[0].FirstName);
        }

        [TestCase("Alice")]
        public void GetByFirstName_NonExistingPerson_ReturnsEmptyList(string firstName)
        {
            // Act
            var result = personRepository.GetByFirstName(firstName);

            // Assert
            Assert.IsEmpty(result);
        }

        [TestCase("John")]
        public void GetByFirstName_MultiplePeopleWithSameFirstName_ReturnsAllPeople(string firstName)
        {
            // Act
            var result = personRepository.GetByFirstName(firstName);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.True(result.All(person => person.FirstName == firstName));
        }

        [TestCase("Doe")]
        public void GetByLastName_ExistingPersonWithUniqueLastName_ReturnsPerson(string lastName)
        {
            // Act
            var result = personRepository.GetByLastName(lastName);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(lastName, result[0].LastName);
        }

        [TestCase("Doe")]
        public void GetByLastName_MultiplePeopleWithSameLastName_ReturnsAllPeople(string lastName)
        {
            // Act
            var result = personRepository.GetByLastName(lastName);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.True(result.All(person => person.LastName == lastName));
        }

        [TestCase("Brown")]
        public void GetByLastName_NonExistingPerson_ReturnsEmptyList(string lastName)
        {
            // Act
            var result = personRepository.GetByLastName(lastName);

            // Assert
            Assert.IsEmpty(result);
        }

        [TestCase("CD2345678901")]
        public void GetById_ExistingPerson_ReturnsPerson(string id)
        {
            // Act
            var result = personRepository.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(id, result.ID);
        }

        [TestCase("XYZ1234567890")]
        public void GetById_NonExistingPerson_ReturnsNull(string id)
        {
            // Act
            var result = personRepository.GetById(id);

            // Assert
            Assert.Null(result);
        }

        [TestCase("Alice", "Brown", "2000-03-20", "KL6789012345")]
        public void Add_NewPerson_PersonAddedToList(string firstName, string lastName, string dateOfBirth, string id)
        {
            // Arrange
            var newPerson = new Person(firstName, lastName, DateTime.Parse(dateOfBirth), id);

            // Act
            var result = personRepository.Add(newPerson);

            // Assert
            Assert.True(result);
            Assert.Contains(newPerson, people);
        }

        [TestCase("John", "Doe", "1990-01-01", "AB1234567890")]
        public void Add_ExistingPerson_ReturnsFalse_PersonNotAddedToList(string firstName, string lastName, string dateOfBirth, string id)
        {
            // Arrange
            var existingPerson = new Person(firstName, lastName, DateTime.Parse(dateOfBirth), id);

            // Act
            var result = personRepository.Add(existingPerson);

            // Assert
            Assert.False(result);
        }
    }

}
