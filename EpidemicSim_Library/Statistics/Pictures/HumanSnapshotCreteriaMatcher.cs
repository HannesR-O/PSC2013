using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.Statistics.Pictures
{
    public static class HumanSnapshotCreteriaMatcher
    {
        /// <summary>
        /// Returns a List of Humans matching the given fields
        /// </summary>
        /// <param name="humans">The Original Array of Humans</param>
        /// <param name="field">The field to be matched</param>
        /// <returns>A (propably) smaller List of Humans</returns>
        public static List<HumanSnapshot> GetMatchingHumans(HumanSnapshot[] humans, EStatField field)
        {
            List<EStatField> fields = new List<EStatField>();

            foreach (EStatField e in Enum.GetValues(typeof(EStatField)))
            {
                if ((e & field) == e)
                    fields.Add(e);
            }

            List<HumanSnapshot> deceasedHumans = new List<HumanSnapshot>();

            bool useCause = (fields.Contains(EStatField.Infected) != fields.Contains(EStatField.Diseased));

            foreach (HumanSnapshot human in humans)
            {
                EAge age = WrapAge(human.Age);
                EGender gender = (EGender)human.Gender;

                bool fits = true;
                if (useCause)                    
                    fits = fields.Contains(EStatField.Infected) ? !human.Cause : human.Cause;

                if (fits)
                {
                    if (fields.Contains(EStatField.Infected) && !human.Cause)
                        deceasedHumans.Add(human);
                    else if (fields.Contains(EStatField.Diseased) && human.Cause)
                        deceasedHumans.Add(human);
                    //else      // this is a much more elegant and shorter way, BUT I'm not sure, whether it works or not...
                    //{
                    //    for (int i = 0; i < 8; ++i)
                    //    {
                    //        if (fields.Contains((EStatField)(int)Math.Pow(2, i)) & age == (EAge)((i % 4)* 32))
                    //            deceasedHumans.Add(human);
                    //    }
                    //}
                    else if (gender == EGender.Male)
                    {
                        if (fields.Contains(EStatField.MaleBaby) & age == EAge.Baby)
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.MaleChild) & age == EAge.Child)
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.MaleAdult) & age == EAge.Adult)
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.MaleSenior) & age == EAge.Senior)
                            deceasedHumans.Add(human);
                    }
                    else
                    {
                        if (fields.Contains(EStatField.FemaleBaby) & age == EAge.Baby)
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.FemaleChild) & age == EAge.Child)
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.FemaleAdult) & age == EAge.Adult)
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.FemaleSenior) & age == EAge.Senior)
                            deceasedHumans.Add(human);
                    }
                }
            }
            return deceasedHumans;
        }

        /// <summary>
        /// Returns an EAge to a given int
        /// </summary>
        /// <param name="age">The Age as int</param>
        /// <returns>An EAge</returns>
        private static EAge WrapAge(byte age)
        {
            if (age < 6)
                return EAge.Baby;
            else if (age < 25)
                return EAge.Child;
            else if (age < 60)
                return EAge.Adult;
            else
                return EAge.Senior;
        }
    }
}
