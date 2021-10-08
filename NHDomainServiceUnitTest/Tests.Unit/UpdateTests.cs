using System;
using System.Collections.Generic;
using Domain;
using NUnit.Framework;

namespace Tests.Unit
{
    [TestFixture]
    public class UpdateTests : TestUsingInMemoryDatabase
    {
        [Test]
        public void MergeExampleTest()
        {
            object id = 0;
            using (var tx = Session.BeginTransaction())
            {
                var employee = new Employee
                {
                    Firstname = "John",
                    Lastname = "Smith"
                };
                employee.AddBenefit(new SeasonTicketLoan
                {
                    Amount = 1000,
                    MonthlyInstalment = 100,
                    StartDate = new DateTime(2015, 2, 3),
                    EndDate = new DateTime(2016, 1, 3)
                });
                id = Session.Save(employee);

                tx.Commit();
            }

            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                var emp = new Employee
                {
                    Id = (int) id,
                    Firstname = "Hillary"
                };
                emp.AddBenefit(new Leave
                {
                    AvailableEntitlement = 25,
                    RemainingEntitlement = 23,
                    Type = LeaveType.Paid
                });
                var emp2 = Session.Merge(emp);

                emp2.EmailAddress = "Hillary.Smith@organisation.com";
                tx.Commit();
            }

            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                var employee = Session.Get<Employee>(id);
                Assert.That(employee.Lastname, Is.Null);
                Assert.That(employee.Benefits.Count, Is.EqualTo(1));
                tx.Commit();
            }
        }

        [Test]
        public void UpdateExampleTest()
        {
            object id = 0;
            using (var tx = Session.BeginTransaction())
            {
                var employee = new Employee
                {
                    Firstname = "John",
                    Lastname = "Smith"
                };
                employee.AddBenefit(new SeasonTicketLoan
                {
                    Amount = 1000,
                    MonthlyInstalment = 100,
                    StartDate = new DateTime(2015, 2, 3),
                    EndDate = new DateTime(2016, 1, 3)
                });
                id = Session.Save(employee);

                tx.Commit();
            }

            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                var emp = new Employee
                {
                    Id = (int)id,
                    Firstname = "Hillary"
                };
                emp.AddBenefit(new Leave
                {
                    AvailableEntitlement = 25,
                    RemainingEntitlement = 23,
                    Type = LeaveType.Paid
                });
                Session.Update(emp);

                emp.EmailAddress = "Hillary.Smith@organisation.com";
                tx.Commit();
            }

            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                var employee = Session.Get<Employee>(id);
                Assert.That(employee.Lastname, Is.Null);
                Assert.That(employee.Benefits.Count, Is.EqualTo(2));
                Assert.That(employee.EmailAddress, Is.EqualTo("Hillary.Smith@organisation.com"));
                tx.Commit();
            }
        }

        [Test]
        public void PartialUpdatesUsingMergeResultInInconsistentState()
        {
            object id = 0;
            using (var tx = Session.BeginTransaction())
            {
                id = Session.Save(new Employee
                {
                    Firstname = "John",
                    Lastname = "Smith"
                });

                tx.Commit();
            }

            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                var emp = new Employee
                {
                    Id = (int)id,
                    Firstname = "Hillary"
                };
                var emp2 = Session.Merge(emp);

                emp2.EmailAddress = "Hillary.Smith@organisation.com";
                tx.Commit();
            }

            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                var employee = Session.Get<Employee>(id);
                Assert.That(employee.Lastname, Is.Null);
                tx.Commit();
            }
        }

        [Test]
        public void TransitivePersistenceWorksWithProxyEntities()
        {
            object id = 0;
            using (var tx = Session.BeginTransaction())
            {
                id = Session.Save(new Employee
                {
                    Firstname = "John",
                    Lastname = "Smith"
                });

                tx.Commit();
            }

            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                var employee = Session.Load<Employee>(id);
                employee.Firstname = "Hillary";
                tx.Commit();
            }

            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                var employee = Session.Get<Employee>(id);
                Assert.That(employee.Firstname, Is.EqualTo("Hillary"));
                tx.Commit();
            }
        }
    }
}