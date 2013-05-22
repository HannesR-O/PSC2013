﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.Statistics.Pictures
{
    public class HumanSnapshotWrapper
    {
        /// <summary>
        /// Useless and inefficient so far, don't comment pls
        /// </summary>
        /// <param name="humans"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static List<HumanSnapshot> GetGroupCount(HumanSnapshot[] humans, EStatField field)
        {
            List<EStatField> fields = new List<EStatField>();

            foreach (EStatField e in Enum.GetValues(typeof(EStatField)))
            {
                if ((e & field) == field)
                    fields.Add(e);
            }

            List<HumanSnapshot> deceasedHumans = new List<HumanSnapshot>();

            bool useCause = !(fields.Contains(EStatField.Infected) ^ fields.Contains(EStatField.Diseased));

            foreach (HumanSnapshot human in humans)
            {
                EAge age = WrapAge(human.Age);
                EGender gender = (EGender)human.Gender;

                bool fits = true;
                if (useCause)                    
                    fits = fields.Contains(EStatField.Infected) ? !human.Cause : human.Cause;

                if (fits)
                {
                    if (gender == EGender.Male)
                    {
                        if (fields.Contains(EStatField.MaleBaby))
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.MaleChild))
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.MaleAdult))
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.MaleSenior))
                            deceasedHumans.Add(human);
                    }
                    else
                    {
                        if (fields.Contains(EStatField.FemaleBaby))
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.FemaleChild))
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.FemaleAdult))
                            deceasedHumans.Add(human);
                        else if (fields.Contains(EStatField.FemaleSenior))
                            deceasedHumans.Add(human);
                    }
                }
            }
            return deceasedHumans;
        }

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
