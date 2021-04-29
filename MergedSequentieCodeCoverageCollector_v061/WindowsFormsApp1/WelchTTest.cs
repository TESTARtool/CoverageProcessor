using System;
using System.Collections;

class WelchTTest
  {
    // shortcut to use a NewLine (\R\N)
    static string nl = Environment.NewLine;
    static double p_Value;


    // Return the P-Value
    public static double getPValue()
    {
        return p_Value;
    }


    // Intialize the test values
    public static string initTTest(ArrayList alOne, ArrayList alTwo)
    {
        // Declare the Arrays to be used for the T-Test
        double[] x = new double[alOne.Count-1]; 
        double[] y = new double[alTwo.Count-1];

        // Store the values of the received ArrayLists with the sample data in an Array
        for (int i = 0; i < x.Length; ++i)
        { //iterate over the elements of the list
            x[i] = Double.Parse(alOne[i+1].ToString()); //store each element as a double in the array
        }

        // Store the values of the received ArrayLists with the sample data in an Array
        for (int i = 0; i < y.Length; ++i)
        { //iterate over the elements of the list
            y[i] = Double.Parse(alTwo[i+1].ToString()); //store each element as a double in the array
        }
        
        string tekst = "Begin Welch's t-test "+ nl + "" +
            "(this implementation of the test is based on ACM algorithms #209 and #395 by the Association for Computing Machinery.)" + nl;

        tekst += "The first sample is:" + nl;
        tekst += ShowValues(x, 0);

        tekst += "The second sample is:" + nl;
        tekst += ShowValues(y, 0);





        tekst += "Starting Welch's t-test." + nl;
        // Start the Test
        tekst += TTest(x, y) + nl;

        tekst += "End t-test." + nl;

        return tekst;
    } 


    // Show the sample data in the TextArea
    static string ShowValues(double[] v, int dec)
    {
        string tekst = "";
        for (int i = 0; i < v.Length; ++i)
            tekst += (v[i].ToString("F" + dec) + " ");
        tekst += nl;
        return tekst;
    }


    // The implementation of the Welch T_Test for two samples
    public static string TTest(double[] x, double[] y)
    {
      double sumX = 0.0; // calculate means
      double sumY = 0.0;

      for (int i = 0; i < x.Length; ++i)
        sumX += x[i];

      for (int i = 0; i < y.Length; ++i)
        sumY += y[i];

      int n1 = x.Length;
      int n2 = y.Length;
      double meanX = sumX / n1;
      double meanY = sumY / n2;

      double sumXminusMeanSquared = 0.0; // calculate (sample) variances
      double sumYminusMeanSquared = 0.0;

      for (int i = 0; i < n1; ++i)
        sumXminusMeanSquared += (x[i] - meanX) * (x[i] - meanX);

      for (int i = 0; i < n2; ++i)
        sumYminusMeanSquared += (y[i] - meanY) * (y[i] - meanY);

      double varX = sumXminusMeanSquared / (n1 - 1);
      double varY = sumYminusMeanSquared / (n2 - 1);

      // t statistic
      double top = (meanX - meanY);
      double bot = Math.Sqrt((varX / n1) + (varY / n2));
      double t = top / bot;
      

      // df 
      double num = ((varX / n1) + (varY / n2)) *
        ((varX / n1) + (varY / n2));
      double denomLeft = ((varX / n1) * (varX / n1)) / (n1 - 1);
      double denomRight = ((varY / n2) * (varY / n2)) / (n2 - 1);
      double denom = denomLeft + denomRight;
      double df = num / denom;

      double p = Student(t, df); // cumulative two-tail density

        string tekst = "";

        tekst += "mean of Sample 1 = " + meanX.ToString("F2") + nl;
        tekst += "mean of Sample 2 = " + meanY.ToString("F2") + nl;
        tekst += "t = " + t.ToString("F4") + nl;
        tekst += "df = " + df.ToString("F3") + nl;
        tekst += "p-value = " + p.ToString("F5") + nl;

        tekst += nl + Explain();

        p_Value = p;

        return tekst;
    }


    // Show info about used T-Test
    public static string Explain()
    {
        string tekst = "The p-value is the probability that the two means are equal and the Ho hypotheses cannot be rejected." + nl +
            "If the p-value is very low, for example less than 0.05, then you can conclude there is statistcal evidence the two means are different." + nl +
            "In that case the Ho Hypotheses can be rejected." + nl +
            "But if the p-value isn't below the critical value of 5% (0.05) you cannot reject the Ho hypotheses because there's not enough evidence to say the means are different." + nl +
            "A red background indicates that the Ho cannot be rejected, " + nl +
            "A Green background indicates that there is statistical evidence that the Ho can be rejected.";
        return tekst;
    }


    // for large integer df or double df
    // adapted from ACM algorithm 395
    // returns 2-tail p-value
    public static double Student(double t, double df)
    {

      double n = df; // to sync with ACM parameter name
      double a, b, y;

      t = t * t;
      y = t / n;
      b = y + 1.0;
      if (y > 1.0E-6) y = Math.Log(b);
      a = n - 0.5;
      b = 48.0 * a * a;
      y = a * y;

      y = (((((-0.4 * y - 3.3) * y - 24.0) * y - 85.5) /
        (0.8 * y * y + 100.0 + b) + y + 3.0) / b + 1.0) *
        Math.Sqrt(y);
      return 2.0 * Gauss(-y); // ACM algorithm 209
    }


    // adapted from ACM algorithm 395
    // for small integer df, or int df with large t
    public static double Student(double t, int df)
    {
      int n = df; // to sync with ACM parameter name
      double a, b, y, z;

      z = 1.0;
      t = t * t;
      y = t / n;
      b = 1.0 + y;

      if (n >= 20 && t < n || n > 200) // moderate df and smallish t  ( df >= 20, t < df ) or very large df
      {
        double x = 1.0 * n; // make df a double
        return Student(t, x); // call double df version
      }

      if (n < 20 && t < 4.0)
      {
        a = Math.Sqrt(y);
        y = Math.Sqrt(y);
        if (n == 1)
          a = 0.0;
      }
      else
      {
        a = Math.Sqrt(b);
        y = a * n;
        for (int j = 2; a != z; j += 2)
        {
          z = a;
          y = y * (j - 1) / (b * j);
          a = a + y / (n + j);
        }
        n = n + 2;
        z = y = 0.0;
        a = -a;
      }

      int sanityCt = 0;
      while (true && sanityCt < 10000)
      {
        ++sanityCt;
        n = n - 2;
        if (n > 1)
        {
          a = (n - 1) / (b * n) * a + y;
          continue;
        }

        if (n == 0)
          a = a / Math.Sqrt(b);
        else // n == 1
          a = (Math.Atan(y) + a / b) * 0.63661977236; // 2/Pi

        return z - a;
      }

      return -1.0; // error
    } // end Student 


    // input = z-value (-inf to +inf)
    // output = p under Standard Normal curve from -inf to z
    // e.g., if z = 0.0, function returns 0.5000
    // ACM Algorithm #209
    public static double Gauss(double z)
    {
      double y; // 209 scratch variable
      double p; // result. called 'z' in 209
      double w; // 209 scratch variable

      if (z == 0.0)
        p = 0.0;
      else
      {
        y = Math.Abs(z) / 2;
        if (y >= 3.0)
        {
          p = 1.0;
        }
        else if (y < 1.0)
        {
          w = y * y;
          p = ((((((((0.000124818987 * w
            - 0.001075204047) * w + 0.005198775019) * w
            - 0.019198292004) * w + 0.059054035642) * w
            - 0.151968751364) * w + 0.319152932694) * w
            - 0.531923007300) * w + 0.797884560593) * y * 2.0;
        }
        else
        {
          y = y - 2.0;
          p = (((((((((((((-0.000045255659 * y
            + 0.000152529290) * y - 0.000019538132) * y
            - 0.000676904986) * y + 0.001390604284) * y
            - 0.000794620820) * y - 0.002034254874) * y
            + 0.006549791214) * y - 0.010557625006) * y
            + 0.011630447319) * y - 0.009279453341) * y
            + 0.005353579108) * y - 0.002141268741) * y
            + 0.000535310849) * y + 0.999936657524;
        }
      }

      if (z > 0.0)
        return (p + 1.0) / 2;
      else
        return (1.0 - p) / 2;
    } // end Gauss()

  } // end Program


