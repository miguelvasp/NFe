using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using System.Globalization;
 

namespace GAReleaser
{
    public class ReleaserCache
    {
        public static void RemoveInvalidItems(this ICollection<MyClass> some)

        {

            foreach (MyClass item in some.ToList())

            {

                if (!new Validator().ValidateObject(item)) // Your class having your validation method

                {

                    some.Remove(item);

                }

            }

        }
    }
}
 