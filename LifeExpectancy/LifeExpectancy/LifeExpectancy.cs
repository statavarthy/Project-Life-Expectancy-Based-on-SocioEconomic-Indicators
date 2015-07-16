﻿///////////////////////////////////////////////////////////////////////
// LifeExpectancy.cs - Program for calculating Life Expectancy       //
// Language:    C#, .Net Framework 4.0                               //
// Application: Open Source Computing, Project, Summer 2015          //
// Author:      SMRUTI TATAVARTHY, COMP 412, Loyola University       //
//              statavarthy@luc.edu                                  //
///////////////////////////////////////////////////////////////////////
/*Summary
 * 
 * The aim of this project is to find the correlation between Life Expectancy
 * and socioeconomic Indicators like Poverty, Unemployment, Per Capita Income.
 * By finding correlation between these statistics, it is possbiel to determine
 * if unemployment, poverty and the per capita income of houselholds affects
 * life Expectancy.
 * 

 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project
{

    public class LifeExpectancy
    {

        static void Main(string[] args)
        {
            //bool flag = true;
            LifeExpectancy lf = new LifeExpectancy();
            lf.processData();
        }
        public Project.ParseData.correlation processData()
        {
            //File path where data is stored
            string filePath = "..\\..\\..\\..\\Data\\";    
            //File path where the life expectancy file is saved
            string lifeExpectancyFilePath = filePath + "LifeExpectancy_Chicago.csv";
            //File path where the Socio Economic indicators file is saved
            string SocioEconomicIndicatorsFilePath = filePath + "SocioEconomic_Indicators_Chicago.csv";
            
            ParseData pd = new ParseData();
            // Function call to parse Life Expectancy file
            Project.ParseData.lifeExpectancy[] lifeExpectancyData = pd.parselifeExpectancyData(lifeExpectancyFilePath);
                        
            // Function call to parse Socio Economic Indicators file
            Project.ParseData.SocioEconomicIndicators[] socioEconomicData = pd.parsesocioEconomicData(SocioEconomicIndicatorsFilePath);
                                   
            //Function call to find correlation between the data
            Project.ParseData.correlation corr = pd.CorrelationAnalysis(lifeExpectancyData, socioEconomicData);
            return corr;
            
            
        }
    }
}
