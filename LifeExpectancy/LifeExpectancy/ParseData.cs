////////////////////////////////////////////////////////////////////////
// ParseData.cs - Program for defining methods to parse different data//
//                and analyze them                                    //
// Language:    C#, .Net Framework 4.0                                //
// Application: Open Source Computing, Project, Summer 2015              //
// Author:      SMRUTI TATAVARTHY, COMP 412, Loyola University        //
//              statavarthy@luc.edu                                   //
////////////////////////////////////////////////////////////////////////
/*Summary
 * This program contain methods for parsing data.
 * The different methods help in populating the life Expectancy and 
 * and SocioEconomic Indicators
 * The Correlation Analysis method helps in calculating the correlation between 
 * the life Expectancy and SocioEconomic Indicators.
 * 
 
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;


namespace Project
{
    
    public class ParseData
    {
        //Structure for storing parsed data from life Expectancy file
        public struct lifeExpectancy
        {
            public string communityName;
            public string expectancy;
            public string expectancy_1990;
            public string expectancy_2000;
        };

        //Structure for storing parsed data from Socio Economic Indicators file
        public struct SocioEconomicIndicators
        {
            public string poverty;
            public string unemployment;
            public string perCapitaIncome;
            public string communityName;
            public string under18over65;
            public string noDiploma;
            public string housingCrowded;
        };

        public struct correlation
        {
            public double correlLifePoverty;
            public double correlLifeUnemp;
            public double correlLifePerCapita;
        };


        //Declaring structure of arrays for storing parsed data    
        lifeExpectancy[] lifeExpectancyData = new lifeExpectancy[78];       
        SocioEconomicIndicators[] socioeconomicData = new SocioEconomicIndicators[78];
        correlation correl;
        
        //counters for maintaining count of the records
        int lifeExpectancyCnt = 0;
        long SocioEconomicIndicatorsCnt = 0;        
       
        //Method for parsing the Life Expectancy File         
        public lifeExpectancy[] parselifeExpectancyData(String filePath)
        {
            int i = 0;                
                var reader = new StreamReader(File.OpenRead(@filePath));
                var line0 = reader.ReadLine();
                // Populating lifeExpectancy Data
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    lifeExpectancyData[i].communityName = values[1];
                    lifeExpectancyData[i].expectancy_1990 = values[2];
                    lifeExpectancyData[i].expectancy_2000 = values[5];
                    lifeExpectancyData[i].expectancy = values[8];                    
                    i++;
                }
                //counter for storing the number of entries in life expectancy file
                lifeExpectancyCnt = i;
                //Console.WriteLine("\n Life Expectancy Data");
                //for (int k = 0; k < lifeExpectancyCnt; k++)
                //{
                //    Console.WriteLine("{0},{1}", lifeExpectancyData[k].communityName, lifeExpectancyData[k].expectancy);
                //}
                    return lifeExpectancyData;
        }

        //Method for parsing the Socio Economic Indicators File         
        public SocioEconomicIndicators[] parsesocioEconomicData(String SocioEconomicIndicatorsFilePath)
        {
            long j = 0;
            long num = 0;                
                var reader1 = new StreamReader(File.OpenRead(SocioEconomicIndicatorsFilePath));
                var line0_new = reader1.ReadLine();
                // Populating Socio Economic Indicators Data
                while (!reader1.EndOfStream)
                {
                    var line = reader1.ReadLine();
                    var values = line.Split(',');
                    socioeconomicData[j].communityName = values[1];
                    socioeconomicData[j].unemployment = values[4];
                    socioeconomicData[j].poverty = values[3];
                    socioeconomicData[j].perCapitaIncome = values[7];
                    socioeconomicData[j].noDiploma = values[5];
                    socioeconomicData[j].under18over65 = values[6];
                    socioeconomicData[j].housingCrowded = values[2];
                    j++;
                    
                }
                //counter for storing the number of entries in life expectancy file
                SocioEconomicIndicatorsCnt = j;

            //Console.WriteLine("\n Socio Economic Indicators");

            //    for (int k = 0; k < SocioEconomicIndicatorsCnt; k++)
            //    {
            //        Console.WriteLine("{0} {1} {2}", socioeconomicData[k].perCapitaIncome, socioeconomicData[k].poverty, socioeconomicData[k].unemployment);
            //    }

                    return socioeconomicData;
        }

       
        //Method for Calculating the Correlation between Life Expectancy and Socio Economic Indicators        
        public correlation CorrelationAnalysis(lifeExpectancy[] lifeExpectancyData, SocioEconomicIndicators[] socioEconomicData)
        {
     

            double[] expectancy = new double[78];
            double[] poverty = new double[78];
            double[] unemployment = new double[78];
            double[] perCapitaIncome = new double[78];


            for (int k = 0; k < lifeExpectancyData.Length; k++)
            {
                expectancy[k] = Convert.ToDouble(lifeExpectancyData[k].expectancy);
            }
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                poverty[k] = Convert.ToDouble(socioEconomicData[k].poverty);
            }
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                unemployment[k] = Convert.ToDouble(socioEconomicData[k].unemployment);
            }
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                perCapitaIncome[k] = Convert.ToDouble(socioEconomicData[k].perCapitaIncome);
            }
            //Pearson Correlation for calculating correlation between life expectancies and different socioeconomic indicators            
                 correl.correlLifePoverty = Correlation.Pearson(expectancy, poverty);
                 correl.correlLifeUnemp = Correlation.Pearson(expectancy, unemployment);
                 correl.correlLifePerCapita = Correlation.Pearson(expectancy, perCapitaIncome);
                 
                 Console.WriteLine("\n Correlation between Life Expectancy and Poverty is  {0} ", correl.correlLifePoverty);
                 Console.WriteLine("\n Correlation between Life Expectancy and Unemployment is {0} ", correl.correlLifeUnemp);
                 Console.WriteLine("\n Correlation between Life Expectancy and Per Capita Income is {0} ", correl.correlLifePerCapita);
                 return correl;    
        }   
    }
}
