using PSC2013.ES.Library.PopulationData;
using System;
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
            h1 = Human.Create(EGender.Female, AGE_FEMALE, HOMECELL);
            h2 = Human.Create(EGender.Male, AGE_MALE, HOMECELL);
        }

        [Fact]
        public void GetGenderTest()
        {
            SetUp();

            Assert.Equal(EGender.Female, h1.GetGender());
            Assert.Equal(EGender.Male, h2.GetGender());
        }

        [Fact]
        public void GetAgeTest()
        {
            SetUp();

            Assert.Equal(EAge.Adult, h1.GetAge());
            Assert.Equal(EAge.Child, h2.GetAge());

            int age = r.Next(110);
            var human = Human.Create(EGender.Female, age, r.Next());
            EAge expected = EAge.Baby;

            if (age <= 6)
                expected = EAge.Baby;
            else if (age <= 25)
                expected = EAge.Child;
            else if (age <= 60)
                expected = EAge.Adult;
            else
                expected = EAge.Senior;

            Assert.Equal(expected, human.GetAge()); 
        }

        [Fact]
        public void AgeBordersTest()
        {
            SetUp();

            Assert.Throws<ArgumentOutOfRangeException>(
                new Assert.ThrowsDelegateWithReturn(() => Human.Create(EGender.Female, 0, HOMECELL)));

            Assert.Throws<ArgumentOutOfRangeException>(
                new Assert.ThrowsDelegateWithReturn(() => Human.Create(EGender.Female, 128, HOMECELL)));
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

            var human = Human.Create(EGender.Male, 1, r.Next());

            Assert.Equal(EAge.Baby, human.GetAge());

            for (int i = 0; i < 5; i++)
                human.DoAgeTick();

            Assert.Equal(EAge.Baby, human.GetAge());         // age should be 6 now

            human.DoAgeTick();

            Assert.Equal(EAge.Child, human.GetAge());        // age should be 7 now => GetAge() should return Age.Child

            for (int i = 0; i < 18; i++)
                human.DoAgeTick();

            Assert.Equal(EAge.Child, human.GetAge());        // age should be 25 now

            human.DoAgeTick();

            Assert.Equal(EAge.Adult, human.GetAge());        // age should be 26 now => GetAge() should return Age.Adult

            for (int i = 0; i < 34; i++)
                human.DoAgeTick();

            Assert.Equal(EAge.Adult, human.GetAge());        // age should be 60 now

            human.DoAgeTick();

            Assert.Equal(EAge.Senior, human.GetAge());       // age should be 61 now => GetAge() should return Age.Senior

            for (int i = 0; i < 49; i++)
                human.DoAgeTick();

            Assert.Equal(EAge.Senior, human.GetAge());       // age should be 110 now

            human.DoAgeTick();

            Assert.Equal(EAge.Senior, human.GetAge());       // age should be 111 now
        }

        [Fact]
        public void KillHumanTest()
        {
            SetUp();

            Assert.False(h1.IsDead());
            Assert.False(h2.IsDead());

            h1.KillHuman();
            h2.KillHuman();

            Assert.True(h1.IsDead());
            Assert.True(h2.IsDead());

            var human = Human.Create(EGender.Female, r.Next(1, 110), r.Next());

            Assert.False(human.IsDead());

            human.KillHuman();

            Assert.True(human.IsDead());
        }
    }
}