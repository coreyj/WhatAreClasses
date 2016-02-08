using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatAreClasses
{
    /**
     * This class models rational numbers, more commonly known as fractions, providing
     * basic properties and computational methods.
     *
     * I spent way too long on this.
     */
    class Fraction
    {
        #region Properties
        private int _numerator;
        public int Numerator
        {
            get
            {
                return _numerator;
            }
            set
            {
                inSimplifestForm = false;
                _numerator = value;
            }
        }

        private int _denominator;
        public int Denominator
        {
            get
            {
                return _denominator;
            }
            set
            {
                if (value != 0)
                {
                    if (value < 0)
                    {
                        Numerator *= -1;
                    }

                    inSimplifestForm = false;
                    _denominator = value;
                }
                else
                {
                    throw new DivideByZeroException();
                }
            }
        }

        private bool inSimplifestForm;
        private Fraction _simplified;
        public Fraction Simplified
        {
            get
            {
                if (inSimplifestForm)
                {
                    return _simplified;
                }
                else 
                {
                    int gcd = 0;
                    int n = Math.Abs(Numerator < Denominator ? Numerator : Denominator);

                    for (int i = 1; i < n; i++)
                    {
                        if (Numerator % i == 0 && Denominator % i == 0)
                        {
                            gcd = i;
                        }
                    }

                    if (gcd != 0)
                    {
                        var f = new Fraction
                        {
                            Numerator = this.Numerator / gcd,
                            Denominator = this.Denominator / gcd
                        };

                        _simplified = f;
                        return f;
                    }
                    else
                    {
                        inSimplifestForm = true;
                        return this;
                    }
                }
            }
        }
        #endregion

        #region Constructors
        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
            inSimplifestForm = true;
        }

        public Fraction(Fraction f)
        {
            this.Numerator = f.Numerator;
            this.Denominator = f.Denominator;
            inSimplifestForm = false;
        }

        public Fraction(int num)
        {
            Numerator = num;
            Denominator = num;
            inSimplifestForm = false;
        }
        #endregion

        #region Methods
        public void Set(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public double Evaluate()
        {
            return (double) Numerator / Denominator;
        }

        public Fraction Reciprocal()
        {
            var f = new Fraction
            {
                Numerator = this.Denominator,
                Denominator = this.Numerator
            };

            return f;
        }
        #endregion

        #region Unnecessary Math Methods
        public Fraction Add(int num)
        {
            var f = new Fraction
            {
                Numerator = this.Numerator + (num * this.Denominator),
                Denominator = this.Denominator
            };

            return f.Simplified;
        }

        public Fraction Add(Fraction frac)
        {
            var f = new Fraction
            {
                Numerator = (this.Numerator * frac.Denominator) + (frac.Numerator * this.Denominator),
                Denominator = this.Denominator * frac.Denominator
            };

            return f.Simplified;
        }
        #endregion

        #region Operator Overloads
        public static Fraction operator +(Fraction frac, int num)
        {
            var f = new Fraction
            {
                Numerator = frac.Numerator + (num * frac.Denominator),
                Denominator = frac.Denominator
            };

            return f.Simplified;
        }

        public static Fraction operator -(Fraction frac, int num)
        {
            var f = new Fraction
            {
                Numerator = frac.Numerator - (num * frac.Denominator),
                Denominator = frac.Denominator
            };

            return f.Simplified;
        }

        public static Fraction operator *(Fraction frac, int num)
        {
            var f = new Fraction
            {
                Numerator = frac.Numerator * num,
                Denominator = frac.Denominator * num
            };

            return f;
        }

        public static Fraction operator /(Fraction frac, int num)
        {
            var f = new Fraction
            {
                Numerator = frac.Numerator,
                Denominator = frac.Denominator * num
            };

            return f;
        }

        public static Fraction operator +(Fraction frac1, Fraction frac2)
        {
            var f = new Fraction
            {
                Numerator = (frac1.Numerator * frac2.Denominator) + (frac2.Numerator * frac1.Denominator),
                Denominator = frac1.Denominator * frac2.Denominator
            };

            return f.Simplified;
        }

        public static Fraction operator -(Fraction frac1, Fraction frac2)
        {
            var f = new Fraction
            {
                Numerator = (frac1.Numerator * frac2.Denominator) - (frac2.Numerator * frac1.Denominator),
                Denominator = frac1.Denominator * frac2.Denominator
            };

            return f.Simplified;
        }

        public static Fraction operator *(Fraction frac1, Fraction frac2)
        {
            var f = new Fraction
            {
                Numerator = frac1.Numerator * frac2.Numerator,
                Denominator = frac1.Denominator * frac2.Denominator
            };

            return f;
        }

        public static Fraction operator /(Fraction frac1, Fraction frac2)
        {
            var f = new Fraction
            {
                Numerator = frac1.Numerator * frac2.Denominator,
                Denominator = frac1.Denominator * frac2.Numerator
            };

            return f;
        }
        #endregion

        #region Override Methods
        public override string ToString()
        {
            return Numerator.ToString() + "/" + Denominator.ToString();
        }

        public override bool Equals(object obj)
        {
            if ( obj != null && obj is Fraction )
            {
                var f1 = obj as Fraction;
                f1 = f1.Simplified;

                var f2 = this.Simplified;
                
                return (f1.Numerator == f2.Numerator && f1.Denominator == f2.Denominator);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int nhash = Numerator.GetHashCode();
            int dhash = Denominator.GetHashCode();
            return (nhash + dhash)/dhash;
        }
        #endregion
    }
}
