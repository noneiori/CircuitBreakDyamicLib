﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitBreakDyamicLib
{
    public abstract class TimeProvider
    {
        private static TimeProvider current =
            DefaultTimeProvider.Instance;

        public static TimeProvider Current
        {
            get { return TimeProvider.current; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                TimeProvider.current = value;
            }
        }

        public abstract DateTime UtcNow { get; }

        public static void ResetToDefault()
        {
            TimeProvider.current = DefaultTimeProvider.Instance;
        }
    }
}
