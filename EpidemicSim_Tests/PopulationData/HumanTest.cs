using PSC2013.ES.Library.PopulationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PSC2013.ES.Tests.PopulationData
{
    public class HumanTest
    {
        private const int AGE_FEMALE = 45;
        private const int AGE_MALE = 20;

        private const int HOMECELL = 1337;

        private Random r;
        private Human h1, h2;

        private void SetUp()
        {
            r = new Random((int)DateTime.Now.Ticks);
            h1 = Human.CreateHuman(Gender.Female, AGE_FEMALE, HOMECELL);
            h2 = Human.CreateHuman(Gender.Male, AGE_MALE, HOMECELL);
        }

        [Fact]
        public void GetGenderTest()
        {
            SetUp();

            Assert.Equal(Gender.Female, h1.GetGender());
            Assert.Equal(Gender.Male, h2.GetGender());
        }

        [Fact]
        public void GetAgeTest()
        {
            SetUp();

            Assert.Equal(Age.Adult, h1.GetAge());
            Assert.Equal(Age.Child, h2.GetAge());

            int age = r.Next(110);
            var human = Human.CreateHuman(Gender.Female, age, r.Next());
            Age expected = Age.Baby;

            if (age <= 6)
                expected = Age.Baby;
            else if (age <= 25)
                expected = Age.Child;
            else if (age <= 60)
                expected = Age.Adult;
            else
                expected = Age.Senior;

            Assert.Equal(expected, human.GetAge()); 
        }

        [Fact]
        public void AgeBordersTest()
        {
            SetUp();

            Assert.Throws<ArgumentOutOfRangeException>(
                new Assert.ThrowsDelegateWithReturn(() => Human.CreateHuman(Gender.Female, 0, HOMECELL)));

            Assert.Throws<ArgumentOutOfRangeException>(
                new Assert.ThrowsDelegateWithReturn(() => Human.CreateHuman(Gender.Female, 111, HOMECELL)));
        }

        [Fact]
        public void IsInfectedTest()
        {
            SetUp();
            //TODO: |f| write proper test when Human can get Infected properly
        }

        [Fact]
        public void IsSpreadingTest()
        {
            SetUp();
            //TODO: |f| write proper test when Human can get Infected properly
        }

        [Fact]
        public void IsDiseasedTest()
        {
            SetUp();
            //TODO: |f| write proper test when Human can get Infected properly
        }


        [Fact]
        public void NaturalAgeingTest()
        {
            SetUp();

            var human = Human.CreateHuman(Gender.Male, 1, r.Next());

            Assert.Equal(Age.Baby, human.GetAge());

            for (int i = 0; i < 5; i++)
                human.DoAgeTick();

            Assert.Equal(Age.Baby, human.GetAge());         // age should be 6 now

            human.DoAgeTick();

            Assert.Equal(Age.Child, human.GetAge());        // age should be 7 now => GetAge() should return Age.Child

            for (int i = 0; i < 18; i++)
                human.DoAgeTick();

            Assert.Equal(Age.Child, human.GetAge());        // age should be 25 now

            human.DoAgeTick();

            Assert.Equal(Age.Adult, human.GetAge());        // age should be 26 now => GetAge() should return Age.Adult

            for (int i = 0; i < 34; i++)
                human.DoAgeTick();

            Assert.Equal(Age.Adult, human.GetAge());        // age should be 60 now

            human.DoAgeTick();

            Assert.Equal(Age.Senior, human.GetAge());       // age should be 61 now => GetAge() should return Age.Senior

            for (int i = 0; i < 49; i++)
                human.DoAgeTick();

            Assert.Equal(Age.Senior, human.GetAge());       // age should be 110 now 
            Assert.Equal(false, human.IsDead());            // => human is still alive

            human.DoAgeTick();

            Assert.Equal(Age.Senior, human.GetAge());       // age should be 111 now
            Assert.Equal(true, human.IsDead());             // => human dies from overageing, but GetAge() still is valid
        }

        [Fact]
        public void KillHumanTest()
        {
            SetUp();

            Assert.Equal(false, h1.IsDead());
            Assert.Equal(false, h2.IsDead());

            h1.KillHuman();
            h2.KillHuman();

            Assert.Equal(true, h1.IsDead());
            Assert.Equal(true, h2.IsDead());

            var human = Human.CreateHuman(Gender.Female, r.Next(110), r.Next());

            Assert.Equal(false, human.IsDead());

            human.KillHuman();

            Assert.Equal(true, human.IsDead());
        }
    }
}