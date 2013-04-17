//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using PSC2013.ES.Library.Population;

//namespace PSC2013.ES.Tests.Population
//{
//    public class PopulationCellTest
//    {
//        private PopulationCell _pc;
//        private Random _r;

//        [Fact]
//        public void TestTotal()
//        {
//            _r = new Random();

//            var values = new int[8];
//            long total = 0;

//            for (int i = 0; i < values.Length; i++)
//            {
//                values[i] = _r.Next();
//                total += values[i];
//            }

//            _pc = new PopulationCell()
//            {
//                MaleBaby = values[0],
//                MaleChild = values[1],
//                MaleAdult = values[2],
//                MaleSenior = values[3],
//                FemaleBaby = values[4],
//                FemaleChild = values[5],
//                FemaleAdult = values[6],
//                FemaleSenior = values[7]
//            };

//            Assert.Equal(total, _pc.Total);
//        }
//    }
//}